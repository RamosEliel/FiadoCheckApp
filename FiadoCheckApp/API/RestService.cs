using FiadoCheckApp.API.ResponseModels;
using Newtonsoft.Json;
using System.Text;

namespace FiadoCheckApp.API
{ 
    public class RestService
    {
        private readonly HttpClient _client;

        public RestService()
        {
            _client = new HttpClient();
        }

        public async Task<string> GetResource(string resourceUrl)
        {
            HttpResponseMessage response = await _client.GetAsync(resourceUrl);

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsStringAsync();
            }
            else
            {
                throw new Exception($"Error al obtener la respuesta: {response.StatusCode}");
            }
        }

    }
}
