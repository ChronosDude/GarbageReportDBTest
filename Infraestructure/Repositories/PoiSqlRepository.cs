using System;
using System.Collections.Generic;
using System.Linq;
using GarbageDBTest.Domain.Entities;
using GarbageDBTest.Infraestructure.Data;

namespace GarbageDBTest.Infraestructure.Repositories
{
    public class PoiSqlRepository
    {
        private readonly GarbageDBContext _context;

        public PoiSqlRepository()
        {
            _context = new GarbageDBContext();
        }

        public IEnumerable<Poi> GetAll()
        {
            // origen, Método, iterador
            var query = _context.Pois.Select(e => e);
            return query;
        }

        public IEnumerable<Poi> MostrarYSaltar(int mostrar, int saltar)
        {
            var show = mostrar;
            var skip = saltar;

            var query = _context.Pois.Select(p=>p).Skip(skip).Take(show);

            return query;
        }
    }
}