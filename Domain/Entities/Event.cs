using System;
using System.Collections.Generic;

#nullable disable

namespace GarbageDBTest.Domain.Entities
{
    public partial class Event
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public DateTime? Date { get; set; }
        public string Time { get; set; }
        public string Ubication { get; set; }
        public string Geoubication { get; set; }
        public int? RequiredPersons { get; set; }
        public string Features { get; set; }
        public string Sponsor { get; set; }
    }
}
