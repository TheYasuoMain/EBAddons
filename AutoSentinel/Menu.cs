using System.Linq;
using EloBuddy.SDK;
using EloBuddy.SDK.Menu;
using EloBuddy.SDK.Menu.Values;
using EloBuddy;

namespace AutoSentinel
{
    public class Config
    {
        public static Menu MenuMain { get; private set; }


        public static void Initialize()
        {
            //Chat message :)
            Chat.Print("AutoSentinel initialized, Have fun!");

            //Initialize the menu
            MenuMain = MainMenu.AddMenu("AutoSentinel", "AutoSentinel");
            MenuMain.AddGroupLabel("Welcome to AutoSentinel!");
            MenuMain.AddGroupLabel("Thanks to Monstertje for script template!");
            MenuMain.AddGroupLabel("Thanks to Hellsing for basically all the code!");

            //Misc
            Misc.Initialize();

        }

        public static class Misc
        {
            private static Menu Menu { get; set; }

            static Misc()
            {
                Menu = Config.MenuMain.AddSubMenu("Settings");

                Menu.AddGroupLabel("Settings");

                // Initialize other misc features
                Sentinel.Initialize();
            }

            public static void Initialize()
            {
            }

            public static class Sentinel
            {
                private static readonly CheckBox _enabled;
                private static readonly CheckBox _noMode;
                private static readonly CheckBox _alert;
                private static readonly Slider _mana;

                private static readonly CheckBox _baron;
                private static readonly CheckBox _dragon;
                private static readonly CheckBox _mid;
                private static readonly CheckBox _blue;
                private static readonly CheckBox _red;

                public static bool Enabled
                {
                    get { return _enabled.CurrentValue; }
                }
                public static bool NoModeOnly
                {
                    get { return _noMode.CurrentValue; }
                }
                public static bool Alert
                {
                    get { return _alert.CurrentValue; }
                }
                public static int Mana
                {
                    get { return _mana.CurrentValue; }
                }

                public static bool SendBaron
                {
                    get { return _baron.CurrentValue; }
                }
                public static bool SendDragon
                {
                    get { return _dragon.CurrentValue; }
                }
                public static bool SendMid
                {
                    get { return _mid.CurrentValue; }
                }
                public static bool SendBlue
                {
                    get { return _blue.CurrentValue; }
                }
                public static bool SendRed
                {
                    get { return _red.CurrentValue; }
                }

                static Sentinel()
                {
                    Menu.AddGroupLabel("Sentinel (W) usage. Ported from Hellsings Kalista by TheYasuoMain!");


                    {
                        _enabled = Menu.Add("enabled", new CheckBox("Enabled"));
                        _noMode = Menu.Add("noMode", new CheckBox("Only use when no mode active"));
                        _alert = Menu.Add("alert", new CheckBox("Alert when sentinel is taking damage"));
                        _mana = Menu.Add("mana", new Slider("Minimum mana available when casting W ({0}%)", 40));

                        Menu.AddLabel("Send to the following locations (no specific order):");
                        (_baron = Menu.Add("baron", new CheckBox("Baron"))).OnValueChange += OnValueChange;
                        (_dragon = Menu.Add("dragon", new CheckBox("Dragon"))).OnValueChange += OnValueChange;
                        (_mid = Menu.Add("mid", new CheckBox("Mid lane brush"))).OnValueChange += OnValueChange;
                        (_blue = Menu.Add("blue", new CheckBox("Blue buff"))).OnValueChange += OnValueChange;
                        (_red = Menu.Add("red", new CheckBox("Red buff"))).OnValueChange += OnValueChange;
                        SentinelManager.RecalculateOpenLocations();
                    }
                }

                private static void OnValueChange(ValueBase<bool> sender, ValueBase<bool>.ValueChangeArgs args)
                {
                    SentinelManager.RecalculateOpenLocations();
                }
                public static void Initialize()
                {
                }
            }
        }
    }
}







