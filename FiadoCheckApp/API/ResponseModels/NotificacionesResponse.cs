using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FiadoCheckApp.API.ResponseModels
{
    class NotificacionesReposnse
    {
        public int idnotificacion { get; set; }
        public required string categoria { get; set; }
        public required string descripcion { get; set; }
        public required DateTime fechaNotificacion { get; set; }
        public required int idUsuario { get; set; }
        public required int idDeuda { get; set; }

    }
}
