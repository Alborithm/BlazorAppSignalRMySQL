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

namespace BlazorSignalRApp.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OeeController : ControllerBase
    {
        private readonly ConnectionString _connectionString;
        private readonly IHubContext<OeeHub> _hubContext;

        public OeeController(ConnectionString connectionString, IHubContext<OeeHub> hubContext)
        {
            _connectionString = connectionString;
            _hubContext = hubContext;
        }

        // GET: api/Characters
        [HttpGet]
        public IEnumerable<Characters> GetOee()
        {
            List<Characters> CharactersOutput = new List<Characters>();
            using(MySqlConnection con = new MySqlConnection(_connectionString.MySQL))
            {
                var output = con.Query<Characters>("SELECT * FROM Characters");

                CharactersOutput = output.AsList();
            }
            
            return CharactersOutput;
        }

        // GET: api/oee/realtime
        [HttpGet("realtime")]
        public ActionResult<List<RealTime>> GetAvailabilityRealTime()
        {
            List<RealTime> realTimes;

            try
            {
                using(MySqlConnection con = new MySqlConnection(_connectionString.MySQL))
                {
                    string query = "CALL SpGetCurrentAvailabilityAll();";

                    realTimes = con.Query<RealTime>(query).AsList();
                }
                if  (realTimes != null)
                {
                    return Ok(realTimes);
                }
                else
                {
                    var response = new HttpResponseMessage(HttpStatusCode.NotFound);
                    response.ReasonPhrase = "No table found";
                    return NotFound("Table OeeRealTime not found");
                }
            }
            catch (System.Exception ex)
            {
                throw;
            }
        }

        // GET: api/oee/realtimeByTime
        [HttpGet("realtimeByTime")]
        public ActionResult<List<RealTime>> GetAvailabilityRealTimeByTime(
            [FromBody]FromToDates times
        )
        {
            List<RealTime> realTimes;

            try
            {
                using(MySqlConnection con = new MySqlConnection(_connectionString.MySQL))
                {
                    string query = "CALL SpGetCurrentAvailabilityAll();";

                    realTimes = con.Query<RealTime>(query).AsList();
                }
                if  (realTimes != null)
                {
                    return Ok(realTimes);
                }
                else
                {
                    var response = new HttpResponseMessage(HttpStatusCode.NotFound);
                    response.ReasonPhrase = "No table found";
                    return NotFound("Table OeeRealTime not found");
                }
            }
            catch (System.Exception ex)
            {
                throw;
            }
        }

        [HttpPut("{lineId}/{opNumber}")]
        public HttpResponseMessage PutRealTimeDataOnOperation(int lineId, int OpNumber)
        {
            string query = $"CALL SpUpdateOeeRealTimeFromEntity({OpNumber},{lineId});";

            try
            {
                using(MySqlConnection con = new MySqlConnection(_connectionString.MySQL))
                {
                    con.Execute(query);
                }

                var response = new HttpResponseMessage(HttpStatusCode.OK);

                _hubContext.Clients.All.SendAsync("ReceiveMessage");                
                
                return response;
                
            }
            catch (System.Exception ex)
            {
                var response = new HttpResponseMessage(HttpStatusCode.BadRequest);
                response.ReasonPhrase = ex.Message;

                throw;
            }
        }

        [HttpPut]
        public HttpResponseMessage PutRealTimeDataOnAll()
        {
            string query = $"CALL SpUpdateOeeRealTimeFromEntity({1},{10}); \n" +
                $"CALL SpUpdateOeeRealTimeFromEntity({1},{20}); \n" +
                $"CALL SpUpdateOeeRealTimeFromEntity({2},{10}); ";

            try
            {
                using(MySqlConnection con = new MySqlConnection(_connectionString.MySQL))
                {
                    con.Execute(query);
                }

                var response = new HttpResponseMessage(HttpStatusCode.OK);

                _hubContext.Clients.All.SendAsync("ReceiveMessage");                
                
                return response;
                
            }
            catch (System.Exception ex)
            {
                var response = new HttpResponseMessage(HttpStatusCode.BadRequest);
                response.ReasonPhrase = ex.Message;

                throw;
            }
        }

        public class FromToDates
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
            
        }
    }
}