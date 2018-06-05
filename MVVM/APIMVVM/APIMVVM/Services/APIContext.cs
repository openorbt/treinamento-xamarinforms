using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using APIMVVM.Models;
using Newtonsoft.Json;
using Xamarin.Forms;

[assembly: Dependency(typeof(APIMVVM.Services.APIContext))]
namespace APIMVVM.Services
{
    public class APIContext : IAPIContext
    {
        public readonly HttpClient _client;
        private static string BASEADDRESS = "http://includeapi.azurewebsites.net";

        public APIContext()
        {
            _client = new HttpClient()
            {
                BaseAddress = new Uri(BASEADDRESS)
            };

        }

        public async Task<List<Pessoa>> GetPessoas()
        {
            var response = await _client.GetAsync("/api/pessoas");

            if(response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<List<Pessoa>>(content);

                return result;
            }
            else
            {
                return new List<Pessoa>();
            }
        }

        public async Task AddPessoa(Pessoa p)
        {
            var json = JsonConvert.SerializeObject(p);
            var response = await _client.PostAsync("api/pessoas", 
                new StringContent(json, System.Text.Encoding.UTF8, "application/json"));
        }
    }
}
