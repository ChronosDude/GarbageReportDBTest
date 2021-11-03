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
    public class UserController : ControllerBase
    {
        [HttpGet]
        [Route("")]
        public IActionResult GetAll() //metodo que obtiene todos los pois de la base mostando los elementos que definimos en el  DTO
        {
            var repository = new UserSqlRepository();
            var persons = repository.GetAll();
            var respuesta = persons.Select(x=>ObjectToDto(x));
            return Ok(respuesta);
        }
        private UserDto ObjectToDto(User users) //con esto le asignamos a nuestro dto los valores que le corresponden
        {
            return new UserDto(
                Username: users.Username,
                Name: users.Name
                
            );
        }

        [HttpGet]
        [Route("Contar")] //con la funcion contar sabemos cuantos usuarios tenemos registrados, lo podemos aplicar de igual manera con los resumenes de los puntos de interes
        public string CountUsers()
        {
            var repository = new UserSqlRepository();
            var conta = repository.Count();
            return ($"le numero total de usuarios registrados es: {conta}");
        }
    }
}
