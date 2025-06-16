using Newtonsoft.Json;
using FiadoCheckApp.API.ResponseModels;
using System.Text;

namespace FiadoCheckApp.API
{
    class Auth
    {
        private static readonly HttpClient client = new HttpClient();

        public async Task<UsuariosResponse> AuthorizeAsync(string nombreUsuario, string password)
        {
            var loginData = new
            {
                email = nombreUsuario,
                clave = password
            };

            string jsonContent = JsonConvert.SerializeObject(loginData);

            var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

            HttpResponseMessage response = await client.PostAsync(Constants.BaseUrl + Constants.Users, content);

            if (response.IsSuccessStatusCode)
            {
                string jsonResponse = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<UsuariosResponse>(jsonResponse);
            }
            else
            {
                return new UsuariosResponse { Message = "Failed to authenticate." };
            }
        }

    }
}
