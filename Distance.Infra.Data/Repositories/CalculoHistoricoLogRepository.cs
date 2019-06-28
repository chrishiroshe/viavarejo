using Distance.Domain.Entities;
using Distance.Domain.Interfaces;
using Distance.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Distance.Infra.Data.Repositories
{
    public class CalculoHistoricoLogRepository : RepositoryBase<CalculoHistoricoLog>, ICalculoHistoricoLogRepository
    {
        #region Variaveis 

        protected new readonly DistanceContext  _context;

        #endregion Variaves 

        #region Construtor

        /// <summary>
        /// Constructor Context
        /// </summary>
        /// <param name="context">context</param>
        public CalculoHistoricoLogRepository(DistanceContext context) : base(context)
        {
            _context = context;
        }

        #endregion Construtor

        #region metodos

        /// <summary>
        /// Cria uma logs distancia
        /// </summary>
        /// <returns>Distancia</returns>
        public void CriaLogDistancia(IEnumerable<CalculoHistoricoLog> calculoHistoricoLogs )
        {
            if (calculoHistoricoLogs != null && calculoHistoricoLogs.Count() > 0)
            {
                    _context.Set<CalculoHistoricoLog>().AddRange(calculoHistoricoLogs);
                    _context.SaveChanges();
            }
        }

        #endregion metodos

    }
}
