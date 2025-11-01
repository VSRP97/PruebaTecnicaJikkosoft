using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace LibraryManager.Infrastructure.TypesHandler
{
    internal class EnumTypeHandler<T> : SqlMapper.TypeHandler<T> where T : struct, Enum
    {
        public override T Parse(object value)
        {
            if (Enum.TryParse<T>(value.ToString(), out var result))
                return (T)result;

            return default;
        }

        public override void SetValue(IDbDataParameter parameter, T value)
        {
            parameter.Value = value.ToString();
        }
    }
}
