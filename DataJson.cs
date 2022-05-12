using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MasActivosBot
{
    public class elems
    {
        //public string[] ids { get; set; }
        public string idinterno { get; set; }
        public string nombre { get; set; }
        public string documento { get; set; }
        public string deuda_total { get; set; }
        public string deuda_parcial { get; set; }
        public string nromedidor { get; set; }
        public string domicilio { get; set; }
        public string grupoyorden { get; set; }
        public string entidad { get; set; }
        public string maximo_horas_cancelacion { get; set; }

        //public deudores_ids(string id1, string id2, string id3)
        public elems(string idinterno, string nombre, string documento, string deuda_total, string deuda_parcial, string nromedidor, string domicilio, string grupoyorden, string entidad,string maximo_horas_cancelacion)
        {
            //this.ids = new string[] { "1", "12", "3" };
            this.idinterno = idinterno;
            this.nombre = nombre;
            this.documento = documento;
            this.deuda_total = deuda_total;
            this.deuda_parcial = deuda_parcial;
            this.nromedidor = nromedidor;
            this.domicilio = domicilio;
            this.grupoyorden = grupoyorden;
            this.entidad = entidad;
            this.maximo_horas_cancelacion = maximo_horas_cancelacion;
        }
    }
}