using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FiadoCheckApp.API.ResponseModels
{
    class UsuariosResponse
    {
        public int idUsuario { get; set; }
        public string nombreUsuario { get; set; }
        public string password { get; set; }
        public int rol { get; set; }
        public int idCliente { get; set; }

        public string Message { get; set; }
    }
}
