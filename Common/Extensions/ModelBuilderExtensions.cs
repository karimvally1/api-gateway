using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Common.Extensions
{
    public static class ModelBuilderExtensions
    {
        public static void SeedEnumValues<T, TEnum>(this ModelBuilder mb, Func<TEnum, T> converter)
        where T : class => Enum.GetValues(typeof(TEnum))
                .Cast<object>()
                .Select(value => converter((TEnum)value))
                .ToList()
                .ForEach(instance => mb.Entity<T>().HasData(instance));
    }
}
