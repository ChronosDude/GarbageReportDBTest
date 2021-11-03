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
    public class EventController : ControllerBase
    {
        [HttpGet]
        [Route("")]
        public IActionResult GetAll() //metodo que obtiene todos los valores de la base pero solo mostrando los que definimos en el dto
        {
            var repository = new EventSqlRepository();
            var persons = repository.GetAll();
            var respuesta = persons.Select(x=>ObjectToDto(x));
            return Ok(respuesta);
        }

        private EventDto ObjectToDto(Event events) //con esto le asignamos a nuestro dto los valores que le corresponden
        {
            return new EventDto(
                Name: events.Name,
                Date: events.Date,
                Time: events.Time,
                Ubication:events.Ubication,
                Sponsor: events.Sponsor
            );
        }

        private Event DtoToObject(EventFilterDto dto) //convertimos un filtrado en un objeto(evento) completo para poder trabajar con el, pero asignando los valores proporconados y dejando null los demas 
        {
            if(string.IsNullOrEmpty(dto.Name) && string.IsNullOrEmpty(dto.Ubication) && string.IsNullOrEmpty(dto.Sponsor))
            {
            return null;
            }

            var newevent = new Event{
                Id=0,
                Name= dto.Name,
                Date= DateTime.Now,
                Time= string.Empty,
                Ubication= dto.Ubication,
                Geoubication= string.Empty,
                RequiredPersons=0,
                Features= string.Empty,
                Sponsor= dto.Sponsor
                

            };
            return newevent;
        }



        [HttpGet]
        [Route("{id:int}")]
        public IActionResult GetById(int id)//obtenemos un resultado por id
        {
            var repository = new EventSqlRepository();
            var events = repository.GetById(id);
            var respuesta = ObjectToDto(events);
            return Ok(respuesta);
        }

        [HttpGet]
        [Route("Filtros")] //podemos aplicar filtros de busqueda ya que usamos el dto de filtrado, podmeos filtrar por nombre, ubicacion o sponsor
        public IActionResult GetByFilter([FromBody]EventFilterDto dto)
        {
            var events = DtoToObject(dto);
            
            var repository = new EventSqlRepository();


            var eventos = repository.GetByFilter(events);
            var respuesta= eventos.Select(x=>ObjectToDto(x));
            
            return Ok(respuesta);
        }
    }
}