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
    }
}