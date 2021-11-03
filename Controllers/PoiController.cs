using Microsoft.AspNetCore.Mvc;
using System.Collections;
using GarbageDBTest.Infraestructure.Repositories;
using GarbageDBTest.Domain.Dtos;
using GarbageDBTest.Domain.Entities;
using System.Linq;
using System;

namespace Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PoiController : ControllerBase
    {
        [HttpGet]
        [Route("")]
        public IActionResult GetAll() //metodo que obtiene todos los pois de la base mostando TODOS sus elementos ya no le aplicamos ningun DTO
        {
            var repository = new PoiSqlRepository();
            var persons = repository.GetAll();
            var respuesta = persons.Select(x=>x);
            return Ok(respuesta);
        }

        [HttpGet]
        [Route("{mostrar}.{saltar}")] //con este metodo solo mostramos cierta cantidad de elementos despues de saltar otra cantidad dada. Puede sernos util al momentos de paginar resultados.
        public IActionResult MostrarYSaltar(int mostrar, int saltar)
        {
            var repository = new PoiSqlRepository();
            var listita = repository.MostrarYSaltar(mostrar,saltar);
            return Ok(listita);
        }

        
    }
}