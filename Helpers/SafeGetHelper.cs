using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace FacturacionDigital_SIGECE.Helpers
{
    public static class SafeGetHelper
    {

        public static T SafeGet<T>(SqlDataReader rd, string columnName, T defaultValue = default)
        {
            try
            {
                int ordinal = rd.GetOrdinal(columnName);     // lanza si no existe

                if (rd.IsDBNull(ordinal))
                    return defaultValue;

                object val = rd.GetValue(ordinal);

                // Tratar "" o espacios como NULL
                if (val is string s && string.IsNullOrWhiteSpace(s))
                    return defaultValue;

                Type targetType = typeof(T);
                Type? underlying = Nullable.GetUnderlyingType(targetType);

                // Enums
                if ((underlying ?? targetType).IsEnum)
                {
                    Type enumType = underlying ?? targetType;
                    if (val is string es && !string.IsNullOrWhiteSpace(es))
                        return (T)Enum.Parse(enumType, es, ignoreCase: true);

                    object num = Convert.ChangeType(val, Enum.GetUnderlyingType(enumType), CultureInfo.InvariantCulture);
                    object boxed = Enum.ToObject(enumType, num);
                    if (underlying != null)  // Nullable<Enum>
                    {
                        var conv = TypeDescriptor.GetConverter(typeof(Nullable<>).MakeGenericType(enumType));
                        return (T)conv.ConvertFrom(boxed)!;
                    }
                    return (T)boxed;
                }

                // Guid
                if ((underlying ?? targetType) == typeof(Guid))
                {
                    Guid g = val is Guid gg ? gg : Guid.Parse(val.ToString()!);
                    if (underlying != null) return (T)(object)(Guid?)g;
                    return (T)(object)g;
                }

                // bool con "0"/"1"
                if ((underlying ?? targetType) == typeof(bool) && val is string bs)
                {
                    if (bs == "1") { if (underlying != null) return (T)(object)(bool?)true; return (T)(object)true; }
                    if (bs == "0") { if (underlying != null) return (T)(object)(bool?)false; return (T)(object)false; }
                }

                // Convertir usando el tipo subyacente si es Nullable<T>
                if (underlying != null)
                {
                    object converted = Convert.ChangeType(val, underlying, CultureInfo.InvariantCulture);
                    // construir Nullable<T> desde el valor convertido
                    return (T)Activator.CreateInstance(typeof(Nullable<>).MakeGenericType(underlying), converted)!;
                }

                return (T)Convert.ChangeType(val, targetType, CultureInfo.InvariantCulture);
            }
            catch (IndexOutOfRangeException)
            {
                throw new Exception($"La columna '{columnName}' no existe en el SP.");
            }
            catch (FormatException)
            {
                // Si el formato es inválido (p. ej. '' -> int), devuelve el default
                return defaultValue;
            }
            catch (InvalidCastException)
            {
                return defaultValue;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al leer la columna '{columnName}': {ex.Message}");
            }
        }

    }
}
