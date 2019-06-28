using Distance.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Distance.Domain.Interfaces
{
    public interface ICalculoHistoricoLogRepository: IRepositoryBase<CalculoHistoricoLog>
    {
        void CriaLogDistancia(IEnumerable<CalculoHistoricoLog> calculoHistoricoLogs);
    }
}
