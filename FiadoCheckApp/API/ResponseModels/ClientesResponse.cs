using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FiadoCheckApp.API.ResponseModels
{
    class ClientesResponse
    {
        public int idCliente { get; set; }
        public required String nombreCliente { get; set; }
        public required String direccion { get; set; }
        public required String telefono { get; set; }
        public required String email { get; set; }
        public DateTime fechaRegistro { get; set; }
    }
}
