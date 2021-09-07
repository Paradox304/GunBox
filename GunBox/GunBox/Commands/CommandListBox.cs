using Rocket.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GunBox.Commands
{
    class CommandListBox : IRocketCommand
    {
        public AllowedCaller AllowedCaller => AllowedCaller.Player;

        public string Name => Plugin.Instance.Configuration.Instance.CommandListBox;

        public string Help => "List all the boxes available to be bought and their price";

        public string Syntax => $"/{Plugin.Instance.Configuration.Instance.CommandListBox}";

        public List<string> Aliases => new List<string>();

        public List<string> Permissions => new List<string>();

        public void Execute(IRocketPlayer caller, string[] command)
        {
            var Config = Plugin.Instance.Configuration.Instance;

            if (Config.Boxes.Count == 0)
            {
                Utility.Say(caller, Plugin.Instance.Translate("No_Boxes").ToRich());
                return;
            }

            Utility.Say(caller, Plugin.Instance.Translate("Boxes").ToRich());
            int i = 1;
            foreach (var box in Config.Boxes)
            {
                Utility.Say(caller, Plugin.Instance.Translate("Box_Line", i, box.Name, box.Price).ToRich());
                i++;
            }
        }
    }
}
