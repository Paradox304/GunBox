using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GunBox.Models
{
    public class Gun
    {
        public ushort ItemID { get; set; }
        public int Weight { get; set; }
        public string WinMessage { get; set; }

        public Gun()
        {

        }

        public Gun(ushort itemID, int weight, string winMessage)
        {
            ItemID = itemID;
            Weight = weight;
            WinMessage = winMessage;
        }
    }
}
