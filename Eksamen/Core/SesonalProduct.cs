using System;
using System.Collections.Generic;
using System.Text;

namespace Eksamen.Core
{
    public class SesonalProduct : Product
    {
        public SesonalProduct(int id, string name, decimal price, bool active, bool canBeBoughOnCredit, DateTime startDate, DateTime endDate) : base(id, name, price, active, canBeBoughOnCredit)
        {
            SeasonEndDate = endDate;
            SeasonStartDate = startDate;
        }

        private DateTime _seasonStartDate;
        public DateTime SeasonStartDate { get; set; }

        private DateTime _seasonEndDate;
        public DateTime SeasonEndDate { get; set; }

        public bool IsSeasonActive()
        {
            if (SeasonStartDate.CompareTo(DateTime.Now) < 0 && SeasonEndDate.CompareTo(DateTime.Now) > 0)
            {
                Active = true;
            }
            else
            {
                Active = false;
            }

            return Active;
        }

    }
}
