using System;
using EloBuddy;
using System.Linq;
using EloBuddy.SDK;
using EloBuddy.SDK.Menu;
using EloBuddy.SDK.Menu.Values;


namespace AutoSentinel
{
    public static class initialize
    {
        public static void OnLoadingComplete(EventArgs args)
        {
            if (Game.MapId == GameMapId.SummonersRift)
            {
                if (Player.Instance.ChampionName != "Kalista") return;
                Config.Initialize();
    
            }
        }

    }
}
