using fr34kyn01535.Uconomy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GunBox
{
    public static class UconomyHelper
    {
        public static decimal GetBalance(string steamID)
        {
            return Uconomy.Instance.Database.GetBalance(steamID);
        }

        public static void DecreaseBalance(decimal amt, string steamID)
        {
            Uconomy.Instance.Database.IncreaseBalance(steamID, -amt);
        }
    }
}
