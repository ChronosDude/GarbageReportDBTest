using System;
using System.Collections.Generic;

#nullable disable

namespace GarbageDBTest.Domain.Entities
{
    public partial class User
    {
        public int? Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
    }
}
