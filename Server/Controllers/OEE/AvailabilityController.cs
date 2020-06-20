using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MySqlConnector;
using Dapper;
using BlazorSignalRApp.Shared;
using BlazorSignalRApp.Server.Helpers;
using Microsoft.AspNetCore.SignalR;
using BlazorSignalRApp.Server.Hubs;
using BlazorSignalRApp.Shared.Models.OEE;
using System.Net.Http;
using System.Net;

namespace BlazorSignalRApp.Server.Controllers
{
    [Route("api/oee/[controller]")]
    [ApiController]
    public class AvailabilityController : ControllerBase
    {
        private readonly ConnectionString _connectionString;
        private readonly IHubContext<OeeHub> _hubContext;

        public AvailabilityController(ConnectionString connectionString, IHubContext<OeeHub> hubContext)
        {
            _connectionString = connectionString;
            _hubContext = hubContext;
        }

        // GET: api/oee/Availability
        [HttpGet]
        public IEnumerable<Availability> GetAvailability()
        {
            List<Availability> CharactersOutput = new List<Availability>();
            using(MySqlConnection con = new MySqlConnection(_connectionString.MySQL))
            {
                var output = con.Query<Availability>("SELECT * FROM Availability");

                CharactersOutput = output.AsList();
            }
            
            return CharactersOutput;
        }

        // GET: api/oee/Availability/1/10
        [HttpGet("{id}/{op}")]
        public ActionResult<Availability> GetAvailabilityOfOp(int id, int op)
        {
            // Method taken from: 
            // https://docs.microsoft.com/en-us/aspnet/core/web-api/action-return-types?view=aspnetcore-3.0
            
            Availability entity = GetActualAvailability(op, id);
            if  (entity != null)
            {
                return Ok(entity);
            }
            else
            {
                var response = new HttpResponseMessage(HttpStatusCode.NotFound);
                response.ReasonPhrase = "Machine not found";
                return NotFound("Entity with Line Id = \'" + id.ToString() + 
                    "\' and Operation number = \'" + op.ToString() + "\' not found");
            }

            //return entity;
        }

        [HttpGet("realtime")]
        //[Route("api/oee/availability/realtime")]
        public ActionResult<List<Availability>> GetAvailabilityRealTime([FromBody]Availability[] operations)
        {
            return NotFound();
        }

        [HttpPost]
        public HttpResponseMessage PostAvailabilityChange([FromBody]Availability operation)
        {
            // TODO get the Id of the newly created item, posible solution is to get it by a 
            // stored procedure on MySQL
            try
            {
                Availability NewestAvailability = GetActualAvailability(operation.OperationNumber, operation.OperationLine);

                string query = CreateInsertQuery(operation.OperationNumber, operation.OperationLine, !NewestAvailability.Available, DateTime.UtcNow, 0);

                using(MySqlConnection con = new MySqlConnection(_connectionString.MySQL))
                {
                    con.Execute(query);
                }

                _hubContext.Clients.All.SendAsync("ReceiveMessage");                

                var response = new HttpResponseMessage(HttpStatusCode.Created);
                
                // Method 1, GetDisplayUrl() not recomended for using on headers or body
                // https://docs.microsoft.com/ru-ru/dotnet/api/microsoft.aspnetcore.http.extensions.urihelper.getdisplayurl?view=aspnetcore-2.2
                // new Uri(Microsoft.AspNetCore.Http.Extensions.UriHelper.GetDisplayUrl(Request));
                
                // Method 2, Uri Builder
                // https://stackoverflow.com/questions/31617345/what-is-the-asp-net-core-mvc-equivalent-to-request-requesturi
                // var builder = new UriBuilder();
                // builder.Scheme = Request.Scheme;
                // builder.Host = Request.Host.Value;
                // builder.Host = Request.Host.Host;
                // // this might be wrong
                // builder.Port = Request.Host.Port.Value;
                // builder.Path = Request.Path;
                // builder.Query = Request.QueryString.ToUriComponent();

                response.Headers.Location = 
                //    new Uri(Microsoft.AspNetCore.Http.Extensions.UriHelper.GetDisplayUrl(Request));
                //    builder.Uri;
                    new Uri(Microsoft.AspNetCore.Http.Extensions.UriHelper.GetEncodedUrl(Request));

                return response;
            }
            catch (Exception ex)
            {
                var response = new HttpResponseMessage(HttpStatusCode.BadRequest);
                response.ReasonPhrase = ex.Message;

                return response;
            }
        }

        private Availability GetActualAvailability(int operation, int line)
        {
            string query = "SELECT * FROM `MessureDB`.`Availability` " +
                $"WHERE (`OperationNumber`={operation} AND `OperationLine`={line})" +
                "ORDER BY `EventTime` DESC LIMIT 1";

            using(MySqlConnection con = new MySqlConnection(_connectionString.MySQL))
            {
                return con.Query<Availability>(query).FirstOrDefault();
            }
            
            throw new NotImplementedException();
        }

        private string CreateInsertQuery(int operation, int line, bool available, DateTime eventTime, int code)
        {
            // ToDo add conditional for the nullable code (when it is zero)
            string query = "INSERT INTO `MessureDB`.`Availability` " +
                "(`OperationNumber`, `OperationLine`, `Available`, `EventTime`) " +
                "VALUES " +
                $"({operation}, {line}, {available}, {DateToMySqlString(eventTime)})";
            
            
            return query;
        }

        private string DateToMySqlString(DateTime eventTime)
        {
            // output format STR_TO_DATE("2017,8,14 10:50:10", "%Y,%m,%e %H:%i:%s"

            string output = $"STR_TO_DATE(\"{eventTime.Year},{eventTime.Month},{eventTime.Day} " +
                $"{eventTime.Hour}:{eventTime.Minute}:{eventTime.Second}\", " +
                "\"%Y,%m,%e %H:%i:%s\")";
            
            return output;
        }

        private string CreateSelectAllQueryFromOperations(Availability[] operations)
        {
            string output = "SELECT * FROM `MessureDB`.`Availability` " +
                "WHERE ( `OperationNumber` = ";

            int i = 0;
            foreach (Availability operation in operations)
            {
                output += $"{operation.OperationNumber} AND ";
            }
        }
    }
}