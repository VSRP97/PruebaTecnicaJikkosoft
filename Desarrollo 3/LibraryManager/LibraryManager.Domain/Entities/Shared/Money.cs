using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManager.Domain.Entities.Shared
{
    public sealed record Money(
        decimal Amount)
    {
        public static implicit operator decimal(Money money) => money.Amount;
        public static implicit operator Money(decimal amount) => new(amount);

        public override string ToString() => Amount.ToString("C0", CultureInfo.GetCultureInfo("es-CO"));
    }
}
