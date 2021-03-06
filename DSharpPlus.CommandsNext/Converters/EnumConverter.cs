﻿using System;
using System.Reflection;
using System.Threading.Tasks;
using DSharpPlus.Entities;

namespace DSharpPlus.CommandsNext.Converters
{
#if NETSTANDARD1_1
    public class EnumConverter<T> : IArgumentConverter<T> where T : struct, IComparable, IFormattable
#else
    public class EnumConverter<T> : IArgumentConverter<T> where T : struct, IComparable, IConvertible, IFormattable
#endif
    {
        public Task<Optional<T>> ConvertAsync(string value, CommandContext ctx)
        {
            var t = typeof(T);
            var ti = t.GetTypeInfo();
            if (!ti.IsEnum)
                throw new InvalidOperationException("Cannot convert non-enum value to an enum.");

            if (Enum.TryParse<T>(value, !ctx.Config.CaseSensitive, out T ev))
                return Task.FromResult(Optional<T>.FromValue(ev));

            return Task.FromResult(Optional<T>.FromNoValue());
        }
    }
}
