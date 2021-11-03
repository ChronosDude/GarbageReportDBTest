using System;
using System.Collections.Generic;
using System.Linq;
using GarbageDBTest.Domain.Entities;
using GarbageDBTest.Infraestructure.Data;

namespace GarbageDBTest.Infraestructure.Repositories
{
    public class UserSqlRepository
    {
        private readonly GarbageDBContext _context;

        public UserSqlRepository()
        {
            _context = new GarbageDBContext();
        }

        public IEnumerable<User> GetAll()
        {
            // origen, Método, iterador
            var query = _context.Users.Select(e => e);
            return query;
        }

        public IEnumerable<User> MostrarYSaltar(int mostrar, int saltar)
        {
            var show = mostrar;
            var skip = saltar;

            var query = _context.Users.Select(p=>p).Skip(skip).Take(show);

            return query;
        }

        public int Count()
        {
            var result = _context.Users.Count();

            return result;
        }
    }
}