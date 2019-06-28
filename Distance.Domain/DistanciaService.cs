using Distance.Domain.Entities;
using Distance.Domain.Interfaces;
using Distance.Domain.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace Distance.Domain
{
    public class DistanciaService : ServiceBase<Distancia>, IDistanciaService
    {

        private readonly IDistanciaRepository _distanciaRepository;

        public DistanciaService(IDistanciaRepository distanciaRepository)
            : base(distanciaRepository)
        {
            _distanciaRepository = distanciaRepository;

        }
        /// <summary>
        /// Cria o registro de distancia
        /// </summary>
        public Distancia CriaDistancia(Distancia distancia)
        {
            try
            { 
                _distanciaRepository.CriaDistancia(distancia);
            }
            catch (Exception e)
            {
                //TODO: IMPLEMENT LOG
            }
            return null;
        }

        /// <summary>
        /// Busca as Distancias Proximas
        /// </summary>
        public Distancia BuscaDistanciasProximas(Distancia distancia)
        {
            try
            {  
                distancia = _distanciaRepository.BuscaDistanciasProximas(distancia);
                return distancia;
            }
            catch (Exception e)
            {
                //TODO: IMPLEMENT LOG
            }
            return null;
        }
    }
}



