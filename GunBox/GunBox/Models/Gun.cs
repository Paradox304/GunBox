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
        public List<string> Commands { get; set; }
        public string WinMessage { get; set; }
        public bool BroadcastWin { get; set; }
        public string BroadcastWinMessage { get; set; }
        public bool HasAttachments { get; set; }
        public ushort SightID { get; set; }
        public ushort TacticalID { get; set; }
        public ushort BarrelID { get; set; }
        public ushort MagazineID { get; set; }
        public ushort GripID { get; set; }

        public Gun()
        {

        }

        public Gun(ushort itemID, int weight, List<string> commands, string winMessage, bool broadcastWin, string broadcastWinMessage, bool hasAttachments, ushort sightID, ushort tacticalID, ushort barrelID, ushort magazineID, ushort gripID)
        {
            ItemID = itemID;
            Weight = weight;
            Commands = commands;
            WinMessage = winMessage;
            BroadcastWin = broadcastWin;
            BroadcastWinMessage = broadcastWinMessage;
            HasAttachments = hasAttachments;
            SightID = sightID;
            TacticalID = tacticalID;
            BarrelID = barrelID;
            MagazineID = magazineID;
            GripID = gripID;
        }
    }
}
