using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryDomain
{
    public class FineCalculator
    {
        private readonly decimal _finePerDay;
        public FineCalculator(decimal finePerDay)
        {
            this._finePerDay = finePerDay;
        }

        public decimal CalculateFine(int daysLate)
        {
            return this._finePerDay * daysLate;
        }
    }
}
