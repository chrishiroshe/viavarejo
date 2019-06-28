using Distance.Domain.Entities;
using Distance.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Distance.Domain.Services
{
    public interface IDistanciaService
    {
        Distancia BuscaDistanciasProximas(Distancia distancia);

        Distancia CriaDistancia(Distancia distancia);
    }
}