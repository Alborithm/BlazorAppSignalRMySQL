using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using BlazorSignalRApp.Shared;

namespace BlazorSignalRApp.Shared.Helpers
{
    public class CharacterService
    {
        public Task<List<Characters>> GetFixedCharacterAsync()
        {
            List<Characters> chars = new List<Characters>();

            chars.Add(new Characters(){
                Id = 1,
                CharName = "Gerardo",
                Class = "Programer",
                IsAlive = true,
                Proficiency = 1.00f,
                Race = "Chingon"
            });

            chars.Add(new Characters(){
                Id = 2,
                CharName = "Martha",
                Class = "Sexy",
                IsAlive = true,
                Proficiency = 1.10f,
                Race = "Trucha"
            });

            
            
            return Task.FromResult(chars);
        }

        public async Task<List<Characters>> GetCharacterAsync()
        {
            List<Characters> chars = new List<Characters>();

            using (var httpClient = new HttpClient())
            {
                httpClient.BaseAddress = new Uri("http://localhost:5000/");
                httpClient.DefaultRequestHeaders.Accept.Clear();
                httpClient.DefaultRequestHeaders.Accept.Add(
                    new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json")
                );

                using (var response = await httpClient.GetAsync("api/Characters"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    chars = JsonConvert.DeserializeObject<List<Characters>>(apiResponse);
                }
            }

            return chars;
        }

        public async Task<List<Characters>> GetCharactersStatsAsync()
        {
            List<Characters> chars = new List<Characters>();

            using (var httpClient = new HttpClient())
            {
                httpClient.BaseAddress = new Uri("http://localhost:5000/");
                httpClient.DefaultRequestHeaders.Accept.Clear();
                httpClient.DefaultRequestHeaders.Accept.Add(
                    new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json")
                );

                using (var response = await httpClient.GetAsync("api/Characters/Stats"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    chars = JsonConvert.DeserializeObject<List<Characters>>(apiResponse);
                }
            }

            return chars;
        }


    }
}