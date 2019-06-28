using Distance.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Distance.Domain.Services
{
    public interface ICalculoHistoricoLogService
    {
        void CriaLogDistancia(IList<CalculoHistoricoLog> CalculoHistoricoLogs);
    }
}
