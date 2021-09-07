using Rocket.API.Collections;
using Rocket.Core.Logging;
using Rocket.Core.Plugins;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GunBox
{
    public class Plugin : RocketPlugin<Config>
    {
        public override void LoadPlugin()
        {
            Instance = this;
            base.LoadPlugin();
        }

        protected override void Load()
        {
            Logger.Log("GunBox has been loaded");
            Logger.Log($"If you want a version with unboxing UI and everything, buy it here: https://imperialplugins.com/Unturned/Products/ParadoxUnboxing");
        }

        protected override void Unload()
        {
            Logger.Log("GunBox has been unloaded");
        }

        public override TranslationList DefaultTranslations => new TranslationList()
        {
            { "Wrong_Usage", "[color=red]Correct Usage: {0}[/color]" },
            { "Box_Not_Found", "[color=red]Box with name {0} not found[/color]" },
            { "Not_Enough_Balance", "[color=red]That box costs {0}, you don't have enough money[/color]" },
            { "No_Boxes", "[color=red]There are no boxes available to be bought[/color]" },
            { "Boxes", "[color=green]Boxes Available:[/color]" },
            { "Box_Line", "[color=green]{0}. {1} (${2})[/color]" }
        };

        public static Plugin Instance { get; set; }
    }
}
