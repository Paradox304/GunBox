using GunBox.Models;
using Rocket.API;
using Rocket.Core;
using Rocket.Unturned.Player;
using SDG.Unturned;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

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

            var Config = Plugin.Instance.Configuration.Instance;
            Box box = Config.Boxes.FirstOrDefault(k => k.Name.ToLower() == (command.Length == 0 ? Config.DefaultGunBox : command[0].ToLower()));

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
            var item = new Item(gun.ItemID, true);
            if (gun.HasAttachments)
            {
                if (gun.SightID != 0)
                {
                    var bytes = BitConverter.GetBytes(gun.SightID);
                    item.state[0] = bytes[0];
                    item.state[1] = bytes[1];
                }
                if (gun.GripID != 0)
                {
                    var bytes = BitConverter.GetBytes(gun.GripID);
                    item.state[4] = bytes[0];
                    item.state[5] = bytes[1];
                }
                if (gun.TacticalID != 0)
                {
                    var bytes = BitConverter.GetBytes(gun.TacticalID);
                    item.state[2] = bytes[0];
                    item.state[3] = bytes[1];
                }
                if (gun.MagazineID != 0)
                {
                    var bytes = BitConverter.GetBytes(gun.MagazineID);
                    item.state[8] = bytes[0];
                    item.state[9] = bytes[1];
                    var asset = Assets.find(EAssetType.ITEM, gun.MagazineID) as ItemMagazineAsset;
                    item.state[10] = asset.amount;
                }
                if (gun.BarrelID != 0)
                {
                    var bytes = BitConverter.GetBytes(gun.BarrelID);
                    item.state[6] = bytes[0];
                    item.state[7] = bytes[1];
                }

            }

            player.Player.inventory.forceAddItem(item, true);
            ConsolePlayer ply = new ConsolePlayer();
            foreach (string comm in gun.Commands)
            {
                R.Commands.Execute(ply, comm.Replace("{id}", player.CSteamID.ToString()));
            }
            Utility.Say(caller, gun.WinMessage.ToRich());
            if (gun.BroadcastWin)
            {
                ChatManager.serverSendMessage(gun.BroadcastWinMessage.ToRich().Replace("{name}", player.CharacterName), Color.white, useRichTextFormatting: true, iconURL: Config.IconLink);
            }

            if (gun.SendEffect)
            {
                EffectManager.sendEffectReliable(gun.EffectID, 10000f, player.Position);
            }
        }
    }
}
