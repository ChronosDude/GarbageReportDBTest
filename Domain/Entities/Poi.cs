using System;
using System.Collections.Generic;

#nullable disable

namespace GarbageDBTest.Domain.Entities
{
    public partial class Poi
    {
        public int? Id { get; set; }
        public DateTime? Date { get; set; }
        public string Reason { get; set; }
        public string Description { get; set; }
        public string Geoubication { get; set; }
        public string Colony { get; set; }
    }
}
