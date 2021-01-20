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

        public DateTime SeasonStartDate { get; set; }

        public DateTime SeasonEndDate { get; set; }

        //Can be used to check if the product should be activated
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
