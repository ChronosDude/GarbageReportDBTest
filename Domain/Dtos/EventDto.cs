using System;
using System.Collections.Generic;

namespace GarbageDBTest.Domain.Dtos
{
    public record EventDto(string Name, DateTime? Date, string Time, string Ubication, string Sponsor);
}