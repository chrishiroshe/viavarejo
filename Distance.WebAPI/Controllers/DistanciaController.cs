using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Distance.Domain.Entities;
using Distance.Domain.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;


namespace Distance.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("CorsPolicy")]
    [Authorize]
   
    public class DistanciaController : ControllerBase
    {
        private readonly IDistanciaService _distanciaService;
        public DistanciaController(IDistanciaService distanciaService)
        {
            _distanciaService = distanciaService;
        }
        /// <summary>
        /// Busca Distancias e implementa logs
        /// </summary>
        /// <param name="course">Course Json</param>
        [HttpPost("BuscaDistancias/")]
 
        public JsonResult BuscaDistancias(Distancia distancia)
        {
            // IList<>
            try
            {
                if (!String.IsNullOrEmpty(distancia.Nome))
                    distancia = _distanciaService.BuscaDistanciasProximas(distancia);
            }
            catch (Exception e)
            {
                //TODO: IMPLEMENT LOG AND ERRO TREATMENT
                //return Json(distancia);
            }
            return new JsonResult(distancia); 
        }
        
    }
}
