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
using System.Net.Http.Json;
using System.Globalization;

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
        public ActionResult<IEnumerable<Availability>> GetAvailability()
        {
            List<Availability> availabilityList;


            using(MySqlConnection con = new MySqlConnection(_connectionString.MySQL))
            {
                var output = con.Query<Availability>("CALL SpGetAvailabilityTable();");

                availabilityList = output.AsList();
            }

            if (availabilityList.Count != 0)
            {
                return Ok(availabilityList);
            }
            else
            {
                var response = new HttpResponseMessage(HttpStatusCode.NotFound);
                response.ReasonPhrase = "Request unsuccesful";
                return NotFound("Procedure call did not return a value");
            }
        }

        // GET: api/oee/Availability/TimeFilter
        [HttpGet("timeFilter")]
        public ActionResult<IEnumerable<Availability>> GetAvailabilityTimeFilter(
            [FromBody]FromToTime fromToTime
        )
        {
            List<Availability> availabilityList;

            if (fromToTime.From >= fromToTime.To)
            {
                var response = new HttpResponseMessage(HttpStatusCode.BadRequest);
                response.ReasonPhrase = "Request unsuccesful";
                return NotFound("'To' value must be higher than 'From' value");
            }



            using(MySqlConnection con = new MySqlConnection(_connectionString.MySQL))
            {
                var output = con.Query<Availability>("CALL SpGetAvailabilityTableByTime(" +
                    String.Format("{0}, ", ParseDateToMySqlTimestampFunc(fromToTime.From)) +
                    String.Format("{0});", ParseDateToMySqlTimestampFunc(fromToTime.To)));

                availabilityList = output.AsList();
            }

            if (availabilityList.Count != 0)
            {
                return Ok(availabilityList);
            }
            else
            {
                var response = new HttpResponseMessage(HttpStatusCode.NotFound);
                response.ReasonPhrase = "Request unsuccesful";
                return NotFound("Procedure call did not return a value");
            }
        }

        // GET: api/oee/Availability/1/10
        [HttpGet("{lineId}/{opNumber}")]
        public ActionResult<IEnumerable<Availability>> GetAvailabilityOfOperation(int lineId, int opNumber)
        {
            List<Availability> availabilityList;


            using(MySqlConnection con = new MySqlConnection(_connectionString.MySQL))
            {
                var output = con.Query<Availability>(
                    $"CALL SpGetAvailabilityTableOfOperation({lineId}, {opNumber});");

                availabilityList = output.AsList();
            }

            if (availabilityList.Count != 0)
            {
                return Ok(availabilityList);
            }
            else
            {
                var response = new HttpResponseMessage(HttpStatusCode.NotFound);
                response.ReasonPhrase = "Request unsuccesful";
                return NotFound("Entity with Line Id = \'" + lineId.ToString() + 
                    "\' and Operation number = \'" + opNumber.ToString() + "\' not found");
            }
        }

        // GET: api/oee/Availability/1/10/TimeFilter
        [HttpGet("{lineId}/{opNumber}/timeFilter")]
        public ActionResult<IEnumerable<Availability>> GetAvailabilityOfOperationTimeFilter(
            int lineId, int opNumber ,[FromBody]FromToTime fromToTime
        )
        {
            List<Availability> availabilityList;

            if (fromToTime.From >= fromToTime.To)
            {
                var response = new HttpResponseMessage(HttpStatusCode.BadRequest);
                response.ReasonPhrase = "Request unsuccesful";
                return NotFound("'To' value must be higher than 'From' value");
            }



            using(MySqlConnection con = new MySqlConnection(_connectionString.MySQL))
            {
                var output = con.Query<Availability>("CALL SpGetAvailabilityTableOfOperationByTime(" +
                    $"{lineId}, {opNumber}, " +
                    String.Format("{0}, ", ParseDateToMySqlTimestampFunc(fromToTime.From)) +
                    String.Format("{0});", ParseDateToMySqlTimestampFunc(fromToTime.To)));

                availabilityList = output.AsList();
            }

            if (availabilityList.Count != 0)
            {
                return Ok(availabilityList);
            }
            else
            {
                var response = new HttpResponseMessage(HttpStatusCode.NotFound);
                response.ReasonPhrase = "Request unsuccesful";
                return NotFound("Procedure call did not return a value");
            }
        }

        // GET: api/oee/Availability/1/10/20140302T0003Z/20140302T1603Z
        [HttpGet("{lineId}/{opNumber}/{fromTimeString}/{toTimeString}")]
        public ActionResult<IEnumerable<Availability>> GetAvailabilityOfOperationTimeRane(
            int lineId, int opNumber ,string fromTimeString, string toTimeString
        )
        {
            List<Availability> availabilityList;

            FromToTime fromToTime = new FromToTime(fromTimeString, toTimeString);

            if (fromToTime.From >= fromToTime.To)
            {
                var response = new HttpResponseMessage(HttpStatusCode.BadRequest);
                response.ReasonPhrase = "Request unsuccesful";
                return NotFound("'To' value must be higher than 'From' value");
            }



            using(MySqlConnection con = new MySqlConnection(_connectionString.MySQL))
            {
                var output = con.Query<Availability>("CALL SpGetAvailabilityTableOfOperationByTime(" +
                    $"{lineId}, {opNumber}, " +
                    String.Format("{0}, ", ParseDateToMySqlTimestampFunc(fromToTime.From)) +
                    String.Format("{0});", ParseDateToMySqlTimestampFunc(fromToTime.To)));

                availabilityList = output.AsList();
            }

            if (availabilityList.Count != 0)
            {
                return Ok(availabilityList);
            }
            else
            {
                var response = new HttpResponseMessage(HttpStatusCode.NotFound);
                response.ReasonPhrase = "Request unsuccesful";
                return NotFound("Procedure call did not return a value");
            }
        }

        private string ParseDateToMySqlTimestampFunc(DateTime time)
        {
            string output = $"TIMESTAMP('{time.Year}-{time.Month}-{time.Day} {time.Hour}:{time.Minute}:{time.Second}')";
            return output;
        }

        [HttpPost]
        public HttpResponseMessage PostAvailabilityChange([FromBody]Availability operation)
        {
            // TODO get the Id of the newly created item, posible solution is to get it by a 
            // stored procedure on MySQL
            try
            {
                Availability NewestAvailability = GetActualAvailability(operation.OpNumber, operation.LineId);

                // string query = CreateInsertAvailabilityQuery(operation.OpNumber, operation.LineId, !NewestAvailability.Available, DateTime.UtcNow, 0);

                string query = $"CALL SpWriteAvailabilityTemp({operation.OpNumber},{operation.LineId},{!NewestAvailability.Available},{ParseDateToMySqlTimestampFunc(DateTime.UtcNow)},1)";

                using(MySqlConnection con = new MySqlConnection(_connectionString.MySQL))
                {
                    con.Execute(query);
                }

                // RealTime realTimeData = new RealTime()
                // {
                //     OperationNumber = operation.OperationNumber,
                //     OperationLine = operation.OperationLine,
                //     Available = !NewestAvailability.Available,
                //     FailCode = 0
                // };



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

                string uri = Microsoft.AspNetCore.Http.Extensions.UriHelper.GetEncodedUrl(Request);
                response.Headers.Location = 
                //    new Uri(Microsoft.AspNetCore.Http.Extensions.UriHelper.GetDisplayUrl(Request));
                //    builder.Uri;
                    new Uri(Microsoft.AspNetCore.Http.Extensions.UriHelper.GetEncodedUrl(Request));

                // using (HttpClient http = new HttpClient())
                // {
                //     http.PutAsJsonAsync
                //         ((uri + $"/{realTimeData.OperationLine}/{realTimeData.OperationNumber}"),
                //         realTimeData);
                // }

                _hubContext.Clients.All.SendAsync("ReceiveMessage");                
                
                return response;
            }
            catch (Exception ex)
            {
                var response = new HttpResponseMessage(HttpStatusCode.BadRequest);
                response.ReasonPhrase = ex.Message;

                return response;
            }
        }
// To be erased, implementing new version
/*
        // GET: api/oee/Availability/1/10
        [HttpGet("{lineId}/{op}")]
        public ActionResult<Availability> GetAvailabilityOfOp(int lineId, int op)
        {
            // Method taken from: 
            // https://docs.microsoft.com/en-us/aspnet/core/web-api/action-return-types?view=aspnetcore-3.0
            
            Availability entity = GetActualAvailability(op, lineId);
            if  (entity != null)
            {
                return Ok(entity);
            }
            else
            {
                var response = new HttpResponseMessage(HttpStatusCode.NotFound);
                response.ReasonPhrase = "Machine not found";
                return NotFound("Entity with Line Id = \'" + lineId.ToString() + 
                    "\' and Operation number = \'" + op.ToString() + "\' not found");
            }

            //return entity;
        }
*/
        
// Post and Put methods not needed right now
/*
        [HttpPost]
        public HttpResponseMessage PostAvailabilityChange([FromBody]Availability operation)
        {
            // TODO get the Id of the newly created item, posible solution is to get it by a 
            // stored procedure on MySQL
            try
            {
                Availability NewestAvailability = GetActualAvailability(operation.OperationNumber, operation.OperationLine);

                string query = CreateInsertAvailabilityQuery(operation.OperationNumber, operation.OperationLine, !NewestAvailability.Available, DateTime.UtcNow, 0);

                using(MySqlConnection con = new MySqlConnection(_connectionString.MySQL))
                {
                    con.Execute(query);
                }

                // RealTime realTimeData = new RealTime()
                // {
                //     OperationNumber = operation.OperationNumber,
                //     OperationLine = operation.OperationLine,
                //     Available = !NewestAvailability.Available,
                //     FailCode = 0
                // };



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

                string uri = Microsoft.AspNetCore.Http.Extensions.UriHelper.GetEncodedUrl(Request);
                response.Headers.Location = 
                //    new Uri(Microsoft.AspNetCore.Http.Extensions.UriHelper.GetDisplayUrl(Request));
                //    builder.Uri;
                    new Uri(Microsoft.AspNetCore.Http.Extensions.UriHelper.GetEncodedUrl(Request));

                // using (HttpClient http = new HttpClient())
                // {
                //     http.PutAsJsonAsync
                //         ((uri + $"/{realTimeData.OperationLine}/{realTimeData.OperationNumber}"),
                //         realTimeData);
                // }

                _hubContext.Clients.All.SendAsync("ReceiveMessage");                
                
                return response;
            }
            catch (Exception ex)
            {
                var response = new HttpResponseMessage(HttpStatusCode.BadRequest);
                response.ReasonPhrase = ex.Message;

                return response;
            }
        }

        [HttpPut("{line}/{op}")]
        public void UpdateAvailabilityOnRealTime(
            [FromBody]RealTime realTime, [FromRoute]int line, [FromRoute]int op)
        {
            // string query = "UPDATE `MessureDB`.`OeeRealTime` " +
            //     "SET " +
            //     $"`Available` = {realTime.Available}, " +
            //     $"`FailCode` = {realTime.FailCode} " +
            //     $"WHERE `OperationNumber` = {realTime.OperationNumber} " +
            //     $"AND `OperationLine` = {realTime.OperationLine};";

            string query = "CALL SpUpdateOrInsertOeeRealTime(" +
                $"{op}, " +
                $"{line}, " +
                $"{realTime.Available}, " +
                $"{realTime.FailCode})";

            using (MySqlConnection con = new MySqlConnection(_connectionString.MySQL))
            {
                con.Execute(query);
            }


        }
*/
        private Availability GetActualAvailability(int operation, int line)
        {
            string query = "SELECT * FROM `MessureDB`.`Availability` " +
                $"WHERE (`OperationNumber`={operation} AND `OperationLine`={line})" +
                "ORDER BY `EventTime` DESC LIMIT 1";

            using(MySqlConnection con = new MySqlConnection(_connectionString.MySQL))
            {
                return con.Query<Availability>(query).FirstOrDefault();
            }

        }

        private string CreateInsertAvailabilityQuery(int operation, int line, bool available, DateTime eventTime, int code)
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

        public class FromToTime
        {
            private DateTime _from;
            public DateTime From
            {
                get { return _from; }
                set { _from = value; }
            }
            
            private DateTime _to;
            public DateTime To
            {
                get { return _to; }
                set { _to = value; }
            }

            public FromToTime()
            {

            }

            public FromToTime(string fromTime, string toTime)
            {
                this.From = BuildDateTimeFromYAFormat(fromTime);
                this.To = BuildDateTimeFromYAFormat(toTime);
            }

            // Build datetime with a string with forma yyyyMMddTHHmmZ example. 20200702T2104Z
            private DateTime BuildDateTimeFromYAFormat(string dateString)
            {
                System.Text.RegularExpressions.Regex r = new System.Text.RegularExpressions.Regex(@"^\d{4}\d{2}\d{2}T\d{2}\d{2}Z$");
                if (!r.IsMatch(dateString))
                {
                    throw new FormatException(
                        string.Format("{0} is not the correct format. Should be yyyyMMddTHHmmZ", dateString)); 
                }
                //Gets Time Valeu on UTC
                //DateTime dt = DateTime.ParseExact(dateString, "yyyyMMddThhmmZ", CultureInfo.InvariantCulture, DateTimeStyles.AssumeUniversal);
                
                //GetsTime value local
                DateTime dt = DateTime.ParseExact(dateString, "yyyyMMddTHHmmZ", CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind);

                return dt;
            }
        }
    }
}