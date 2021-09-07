using GunBox.Models;
using Rocket.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GunBox
{
    public class Config : IRocketPluginConfiguration
    {
        public bool UseUconomy { get; set; }
        public bool UseEXP { get; set; }

        public string CommandBox { get; set; }
        public string CommandListBox { get; set; }

        public List<Box> Boxes { get; set; }

        public void LoadDefaults()
        {
            UseUconomy = false;
            UseEXP = true;

            CommandBox = "gunbox";
            CommandListBox = "listbox";

            Boxes = new List<Box>
            {
                new Box("Test", 100, new List<Gun> { new Gun(97, 50, "[color=yellow]Your luck was bad, you won a Colt[/color]"), new Gun(363, 40, "[color=orange]Your luck was good, you won Maplestrike[/color]"), new Gun(116, 10, "Your luck was really good, you won a PDW"), new Gun(297, 1, "[color=red]Your luck was god-like, you won a grizzly![/color]") })
            };
        }
    }
}
