using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FiadoCheckApp.API.ResponseModels
{
    class DeudasResponse
    {
        public int idDeuda { get; set; }
        public float monto { get; set; }
        public DateTime fechaCreacion { get; set; }
        public string descripcion { get; set; }
        public string estadoDeuda { get; set; }
        public int idCliente { get; set; }

        public Color color { get; set; }   
    }
}
