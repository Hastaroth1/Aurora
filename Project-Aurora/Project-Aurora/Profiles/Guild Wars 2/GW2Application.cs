using Aurora.Settings;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Text;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using Aurora.Profiles.Guild_Wars_2.GSI;

namespace Aurora.Profiles.Guild_Wars_2
{
    public class GW2 : Application
    {
        public GW2()
            : base(new LightEventConfig
            {
                Name = "Guild Wars 2", ID = "GW2", ProcessNames = new string[] {"gw2.exe", "gw2-64.exe"},
                SettingsType = typeof(FirstTimeApplicationSettings), ProfileType = typeof(GW2Profile),
                OverviewControlType = typeof(Control_GW2), GameStateType = typeof(GameState_GW2),
                Event = new GameEvent_GW2(), IconURI = "Resources/gw2_48x48.png"
            })
        {
            Config.ExtraAvailableLayers.Add("WrapperLights");
        }
    }
}