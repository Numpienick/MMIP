using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace MMIP.Infrastructure.Context.Configuration.Converters;

public class DateTimeConverter : ValueConverter<DateTime, DateTimeOffset>
{
    public DateTimeConverter()
        : base(d => new DateTimeOffset(d).ToUniversalTime(), d => d.DateTime) { }
}
