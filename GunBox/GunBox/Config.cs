﻿using GunBox.Models;
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

        public string IconLink { get; set; }

        public List<Box> Boxes { get; set; }

        public string DefaultGunBox { get; set; }

        public void LoadDefaults()
        {
            UseUconomy = false;
            UseEXP = true;

            CommandBox = "gunbox";
            CommandListBox = "listbox";
            IconLink = "link here";
            Boxes = new List<Box>
            {
                new Box("Test", 100, new List<Gun> { new Gun(97, 50, new List<string> { "p add {id} MVP" }, "[color=green]Your luck was bad, you won a Colt[/color]", false, "[color=red]{0} won a colt![/color]", false, 0, 0, 0, 0, 0, false, 0), new Gun(363, 40, new List<string>(), "[color=yellow]Your luck was good, you won Maplestrike[/color]", false, "[color=red]{0} won a maplestrike[/color]", false, 0, 0, 0, 0, 0, false, 0), new Gun(116, 10, new List<string>(), "[color=orange]Your luck was really good, you won a PDW[/color]", false, "[color=red]{0} won a pdw[/color]", false, 0, 0, 0, 0, 0, false, 0), new Gun(297, 1, new List<string>(), "[color=red]Your luck was god-like, you won a grizzly![/color]", true, "[color=red]{0} won a grizzly![/color]", false, 0, 0, 0, 0, 0, false, 0) })
            };

            DefaultGunBox = "gun";
        }
    }
}
