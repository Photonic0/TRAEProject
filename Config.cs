using Newtonsoft.Json;
using System.ComponentModel;
using Terraria.Localization;
using Terraria.ModLoader.Config;

namespace TRAEProject
{
    [Label("Bame's Config Settings")]
    class ServerConfig : ModConfig
    {
        [JsonIgnore]
        public const string ConfigName = "Server";

        public override bool Autoload(ref string name)
        {
            name = ConfigName;
            return base.Autoload(ref name);
        }

        public override ConfigScope Mode => ConfigScope.ServerSide;

        public static ServerConfig Instance;

        public override bool AcceptClientChanges(ModConfig pendingConfig, int whoAmI, ref string message)
        {
            message = Language.GetTextValue("Mods.Bame.Config.ServerBlocked");
            return false;
        }

        [Label("Mechanical Boss Changes")]
        [Tooltip("AI and stat reworks to the these three bosses. Disabling this will NOT also disable their Expert Mode stat growth as they get defeated")]
        [DefaultValue(true)]
        public bool MechChanges;
        [Label("Duke Fishron Changes")]
        [Tooltip("Significant buffs to Duke Fishron to make him a boss worthy of Post-Golem")]
        [DefaultValue(true)]
        public bool DukeBuffs;
    }

}
