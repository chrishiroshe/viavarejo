using Distance.Domain.Entities;
using Distance.Domain.Interfaces;
using Distance.Domain.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace Distance.Domain
{
    public class CalculoHistoricoLogService : ServiceBase<CalculoHistoricoLog>, ICalculoHistoricoLogService
    {
        private readonly ICalculoHistoricoLogRepository _calculoHistoricoRepository;

        public CalculoHistoricoLogService(ICalculoHistoricoLogRepository calculoHistoricoRepository)
            : base(calculoHistoricoRepository)
        {
            _calculoHistoricoRepository = calculoHistoricoRepository;

        }
        /// <summary>
        /// Create o log de distancia
        /// </summary>
        public void CriaLogDistancia(IList<CalculoHistoricoLog> calculoHistoricoLogs)
        {
            try
            {
               // List<CalculoHistoricoLog> listaCalculoHistoricoLogs = new List<CalculoHistoricoLog>();
               // listaCalculoHistoricoLogs.
                _calculoHistoricoRepository.CriaLogDistancia(calculoHistoricoLogs);
            }
            catch (Exception e)
            {
            //TODO: IMPLEMENT LOG
            }
        }
    }
}
    
