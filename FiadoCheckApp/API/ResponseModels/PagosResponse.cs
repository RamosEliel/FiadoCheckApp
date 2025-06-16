using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FiadoCheckApp.API.ResponseModels
{
    class PagosResponse
    {
        public int idPago { get; set; }
        public required float monto { get; set; }
        public required DateTime fechaPago { get; set; }
        public required int idDeuda { get; set; }
        public required string metodoPago { get; set; }
    }
}
