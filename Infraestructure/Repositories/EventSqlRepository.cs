using System;
using System.Collections.Generic;
using System.Linq;
using GarbageDBTest.Domain.Entities;
using GarbageDBTest.Infraestructure.Data;

namespace GarbageDBTest.Infraestructure.Repositories
{
    public class EventSqlRepository
    {
        
        
        private readonly GarbageDBContext _eventcontext;

        public EventSqlRepository()
        {
            _eventcontext = new GarbageDBContext();
        }

        public IEnumerable<Event> GetAll()
        {
            // origen, Método, iterador
            var query = _eventcontext.Events.Select(e => e);
            return query;
        }

        public Event GetById(int id)
        {

            var query = _eventcontext.Events.FirstOrDefault(e => e.Id == id);
            

            return query;
        }

        public IEnumerable<Event> GetByFilter(Event events)
        {
            var query = _eventcontext.Events.Select(x => x);

            if (!string.IsNullOrEmpty(events.Name))
                query = query.Where(x => x.Name.Contains(events.Name));


            if (!string.IsNullOrEmpty(events.Ubication))
                query = query.Where(x => x.Ubication == events.Ubication);
            
            if (!string.IsNullOrEmpty(events.Sponsor))
                query = query.Where(x => x.Sponsor == events.Sponsor);
 

            return query;
        }
    }
}