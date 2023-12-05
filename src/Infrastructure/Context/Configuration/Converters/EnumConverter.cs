using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Infrastructure.Context.Configuration.Converters;

public class EnumConverter<TEnum> : ValueConverter<TEnum, string>
    where TEnum : struct, Enum
{
    public EnumConverter()
        : base(d => d.ToString(), d => Enum.Parse<TEnum>(d)) { }
}
