using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Policy;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Xml.Linq;
using Newtonsoft.Json;

namespace Genlogin-CSharp
{
    internal class Genlogin
    {
        private string apiKey = "";
        private readonly string LOCAL_URL = "http://localhost:55550/profiles";
        // Create a class constructor with a parameter
        public Genlogin(string apiKey)
        {
            this.apiKey = apiKey;
        }
        public async Task<object> GetProfilesAsync(int limit, int offset)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                try
                {
                    HttpResponseMessage response = await httpClient.GetAsync(LOCAL_URL + $"?offset={offset}&limit={limit}");
                    string responseBody = await response.Content.ReadAsStringAsync();
                    return responseBody;

                }
                catch (Exception ex)
                {
                    return $"An error occurred: {ex.Message}";
                }
            }
        }

        public async Task<object> GetProfileByIdAsync(int id)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                try
                {
                    HttpResponseMessage response = await httpClient.GetAsync(LOCAL_URL + $"/{id}");
                    string responseBody = await response.Content.ReadAsStringAsync();
                    return responseBody;

                }
                catch (Exception ex)
                {
                    return $"An error occurred: {ex.Message}";
                }
            }
        }

        public async Task<object> GetWsEndpointAsync(int id)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                try
                {
                    HttpResponseMessage response = await httpClient.GetAsync(LOCAL_URL + $"/{id}/ws-endpoint");
                    string responseBody = await response.Content.ReadAsStringAsync();
                    return responseBody;

                }
                catch (Exception ex)
                {
                    return $"An error occurred: {ex.Message}";
                }
            }
        }

        public async Task<object> startProifileAsync(int id)
        {
            using (HttpClient httpClient = new HttpClient())

                try
                {
                    HttpResponseMessage response = await httpClient.GetAsync(LOCAL_URL + $"/{id}/start");
                    string responseBody = await response.Content.ReadAsStringAsync();
                    return responseBody;

                }
                catch (Exception ex)
                {
                    return $"An error occurred: {ex.Message}";
                }

        }

        public async Task<object> stopProifileAsync(int id)
        {
            using (HttpClient httpClient = new HttpClient())

                try
                {
                    HttpResponseMessage response = await httpClient.GetAsync(LOCAL_URL + $"/{id}/stop");
                    string responseBody = await response.Content.ReadAsStringAsync();
                    return responseBody;

                }
                catch (Exception ex)
                {
                    return $"An error occurred: {ex.Message}";
                }

        }

        public async Task<object> runningProifileAsync()
        {
            using (HttpClient httpClient = new HttpClient())

                try
                {
                    HttpResponseMessage response = await httpClient.GetAsync(LOCAL_URL + $"/running");
                    string responseBody = await response.Content.ReadAsStringAsync();
                    return responseBody;

                }
                catch (Exception ex)
                {
                    return $"An error occurred: {ex.Message}";
                }

        }

    }
}
