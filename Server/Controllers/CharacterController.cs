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
    public class CharactersController : ControllerBase
    {
        private readonly ConnectionString _connectionString;
        private readonly IHubContext<BroadcastHub> _hubContext;

        public CharactersController(ConnectionString connectionString, IHubContext<BroadcastHub> hubContext)
        {
            _connectionString = connectionString;
            _hubContext = hubContext;
        }

        // GET: api/Characters
        [HttpGet]
        public IEnumerable<Characters> GetCharacters()
        {
            List<Characters> CharactersOutput = new List<Characters>();
            using(MySqlConnection con = new MySqlConnection(_connectionString.MySQL))
            {
                var output = con.Query<Characters>("SELECT * FROM Characters");

                CharactersOutput = output.AsList();
            }
            
            return CharactersOutput;
        }
        
        // GET: api/Characters/5
        [HttpGet("{id}")]
        public Characters GetCharacters(int id)
        {
            Characters character = new Characters();

            using(MySqlConnection con = new MySqlConnection(_connectionString.MySQL))
            {
                string query = string.Format("SELECT * FROM Characters WHERE Id = {0};", id);

                var output = con.Query<Characters>(query);

                character = output.FirstOrDefault();
            }

            if (character == null)
            {
                return new Characters();
            }

            return character;
        }

        // POST: api/Characters
        [HttpPost]
        public void PostCharacters(Characters characters)
        {
            string query = $"" +
                "INSERT INTO `Characters`" +
                "(`Id`, `CharName`, `Class`, `Race`, `IsAlive`, `Proficiency`)" +
                "VALUES" +
                ($"({characters.Id},") +
                ("\"" + $"{characters.CharName}" + "\",") +
                ("\"" + $"{characters.Class}" + "\",") +
                ("\"" + $"{characters.Race}" + "\",") +
                ($"{characters.IsAlive},") +
                ($"{characters.Proficiency})");
            using(MySqlConnection con = new MySqlConnection(_connectionString.MySQL))
            {
                // con.Query(query);
                con.Execute(query);
            }

            _hubContext.Clients.All.SendAsync("ReceiveMessage");
        }
    }
}