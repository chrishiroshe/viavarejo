using Distance.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Distance.Domain.Interfaces
{
    public interface IDistanciaRepository : IRepositoryBase<Distancia>
    {
        Distancia BuscaDistanciasProximas(Distancia distancia);

        Distancia CriaDistancia(Distancia distancia);
    }
}
