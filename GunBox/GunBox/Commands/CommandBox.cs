using GunBox.Models;
using Rocket.API;
using Rocket.Core;
using Rocket.Unturned.Player;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GunBox.Commands
{
    class CommandBox : IRocketCommand
    {
        public AllowedCaller AllowedCaller => AllowedCaller.Player;

        public string Name => Plugin.Instance.Configuration.Instance.CommandBox;

        public string Help => "Open a gun box and get a random gun";

        public string Syntax => $"/{Plugin.Instance.Configuration.Instance.CommandBox} (Box Name)";

        public List<string> Aliases => new List<string>();

        public List<string> Permissions => new List<string>();

        public void Execute(IRocketPlayer caller, string[] command)
        {
            UnturnedPlayer player = caller as UnturnedPlayer;

            if (command.Length != 1)
            {
                Utility.Say(caller, Plugin.Instance.Translate("Wrong_Usage").ToRich());
                return;
            }

            var Config = Plugin.Instance.Configuration.Instance;
            Box box = Config.Boxes.FirstOrDefault(k => k.Name.ToLower() == command[0].ToLower());

            if (box == null)
            {
                Utility.Say(caller, Plugin.Instance.Translate("Box_Not_Found", command[0]).ToRich());
                return;
            }

            int balance = 0;
            if (Config.UseUconomy == true)
            {
                balance = (int)UconomyHelper.GetBalance(player.CSteamID.ToString());
            } else if (Config.UseEXP == true)
            {
                balance = (int)player.Player.skills.experience;
            }

            if (balance < box.Price)
            {
                Utility.Say(caller, Plugin.Instance.Translate("Not_Enough_Balance", box.Price).ToRich());
                return;
            }

            if (Config.UseUconomy == true)
            {
                UconomyHelper.DecreaseBalance(box.Price, player.CSteamID.ToString());
            } else if (Config.UseEXP == true)
            {
                player.Player.skills.ServerSetExperience((uint)(balance - box.Price));
            }

            Gun gun = box.GetRandomGun();

            player.Player.inventory.forceAddItem(new SDG.Unturned.Item(gun.ItemID, true), true);
            ConsolePlayer ply = new ConsolePlayer();
            foreach (string comm in gun.Commands)
            {
                R.Commands.Execute(ply, comm.Replace("{id}", player.CSteamID.ToString()));
            }
            Utility.Say(caller, gun.WinMessage.ToRich());
        }
    }
}
