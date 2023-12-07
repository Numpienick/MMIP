using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace MMIP.Infrastructure.Context.Configuration.Converters;

internal class DateTimeOffsetConverter : ValueConverter<DateTimeOffset, DateTimeOffset>
{
    public DateTimeOffsetConverter()
        : base(d => d.ToUniversalTime(), d => d.ToUniversalTime()) { }
}
