using Rocket.API;
using Rocket.Unturned.Player;
using SDG.Unturned;
using UnityEngine;

namespace GunBox
{
    public static class Utility
    {
        public static string ToRich(this string value)
        {
            return value.Replace('[', '<').Replace(']', '>').Replace("osqb", "[").Replace("csqb", "]");
        }

        public static void Say(IRocketPlayer target, string message)
        {
            if (target is UnturnedPlayer player)
                ChatManager.serverSendMessage(message, Color.green, toPlayer: player.SteamPlayer(),
                    useRichTextFormatting: true);
        }
    }
}
