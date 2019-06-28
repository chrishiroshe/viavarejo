using System;
using System.Collections.Generic;
using System.Text;

namespace Distance.Domain.Entities
{
    public class CalculoHistoricoLog
    {
        public int Id { get; set; }
        // Nome
        public int LongitudeOrigem { get; set; }

        public int LatitudeOrigem { get; set; }

        public int LongitudeDestino { get; set; }

        public int LatitudeDestino { get; set; }

        public int Distancia { get; set; }

        public DateTime LogData { get; set; }

        public int DistanciaOrigemId { get; set; }

        public int DistanciaDestinoId { get; set; }

        public string NomeAmigo { get; set; }
    }
}
