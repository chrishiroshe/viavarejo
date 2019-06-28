using Distance.Domain.Entities;
using Distance.Domain.Interfaces;
using Distance.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Distance.Infra.Data.Repositories
{
    public class DistanciaRepository : RepositoryBase<Distancia>, IDistanciaRepository
    {
        #region Variaveis 

        protected new readonly DistanceContext _context;

        #endregion Variaves 

        #region Construtor

        /// <summary>
        /// Constructor Context
        /// </summary>
        /// <param name="context">context</param>
        public DistanciaRepository(DistanceContext context) : base(context)
        {
            _context = context;
        }

        #endregion Construtor

        #region metodos


        /// <summary>
        /// Busca Distancias proximas
        /// </summary>
        /// <returns></returns>
        public Distancia BuscaDistanciasProximas(Distancia distancia)
        {
            IList<Distancia> lstDistancia = new List<Distancia>();

            using (_context)
            {
                using (var transaction = _context.Database.BeginTransaction())
                {
                    distancia = CriaDistancia(distancia);
                    if (distancia.Id > 0)
                    {
                        lstDistancia = _context.Distancia.Where(s => s.Id != distancia.Id).
                        OrderBy(s => s.Latitude - distancia.Latitude).
                        OrderBy(s => s.Longitude - s.Longitude).Take(3).ToList();

                        //Cria log 
                        if (lstDistancia != null && lstDistancia.Count > 0)
                        {
                            distancia.CalculoHistoricoLogs = new List<CalculoHistoricoLog>();
                            List<CalculoHistoricoLog> listCalculoLog = new List<CalculoHistoricoLog>();
                            foreach (var distanciaDestino in lstDistancia)
                            {

                                listCalculoLog.Add(new CalculoHistoricoLog()
                                {   
                                    DistanciaOrigemId = distancia.Id,
                                    LatitudeOrigem = distancia.Latitude,
                                    LongitudeOrigem = distancia.Longitude,
                                    LogData = DateTime.Now,
                                    DistanciaDestinoId = distanciaDestino.Id,
                                    LatitudeDestino = distanciaDestino.Latitude,
                                    LongitudeDestino = distanciaDestino.Longitude,
                                    NomeAmigo = distanciaDestino.Nome
                                }); 
                            }
                            distancia.CalculoHistoricoLogs = listCalculoLog;
                            CalculoHistoricoLogRepository calculoRepository = new CalculoHistoricoLogRepository(_context);
                            calculoRepository.CriaLogDistancia(distancia.CalculoHistoricoLogs);
                        }
                    }
                    transaction.Commit();
                }
            }
            return distancia;
           
        }

        /// <summary>
        /// Cria uma distancia
        /// </summary>
        /// <returns>Distancia</returns>
        public Distancia CriaDistancia(Distancia distancia)
        {
            var ret = _context.Distancia.Where(c => (c.Latitude == distancia.Latitude && c.Longitude == distancia.Longitude));
            if (ret == null || ret.Count() == 0 )
            {
                var retNome = _context.Distancia.Where(c => c.Nome == distancia.Nome);
                if (retNome != null || retNome.Count() > 0)
                {
                    distancia = retNome.FirstOrDefault<Distancia>();
                }
                else
                {
                    _context.Set<Distancia>().Add(distancia);
                    _context.SaveChanges();
                }
            }
           
            return distancia;
        }

        #endregion metodos

    }
}
