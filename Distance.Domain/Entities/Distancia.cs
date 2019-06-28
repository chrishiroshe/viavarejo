using System;
using System.Collections.Generic;
using System.Text;

namespace Distance.Domain.Entities
{
    public class Distancia
    {
        #region properties
        // ID
        public int Id { get; set; }
        // Nome
        public int Longitude { get; set; }

        public int Latitude { get; set; }

        public string Nome { get; set; }

        public virtual List<CalculoHistoricoLog> CalculoHistoricoLogs { get; set; }

        #endregion
    }
}
