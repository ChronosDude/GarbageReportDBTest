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
                Name: events.Name==null?string.Empty:events.Name,
                Date: events.Date==null?events.Date:DateTime.Now,
                Time: events.Time==null?string.Empty:events.Name,
                Ubication:events.Ubication==null?string.Empty:events.Ubication,
                Sponsor: events.Sponsor==null?string.Empty:events.Name
            );
        }

        private Event DtoToObject(EventFilterDto dto)
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
        public IActionResult GetById(int id)
        {
            var repository = new EventSqlRepository();
            var events = repository.GetById(id);
            var respuesta = ObjectToDto(events);
            return Ok(respuesta);
        }

        [HttpGet]
        [Route("Filtros")]
        public IActionResult GetByFilter([FromBody]EventFilterDto dto)
        {
            var person = DtoToObject(dto);
            
            var repository = new EventSqlRepository();


            var personas = repository.GetByFilter(person);
            var respuesta= personas.Select(x=>ObjectToDto(x));
            
            return Ok(respuesta);
        }
    }
}