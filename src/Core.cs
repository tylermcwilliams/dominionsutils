using Vintagestory.API.Client;
using Vintagestory.API.Common;
using Vintagestory.API.Common.Entities;
using Vintagestory.API.Config;
using Vintagestory.API.Datastructures;
using Vintagestory.API.Server;
using Vintagestory.ServerMods;

[assembly: ModInfo("dominionsutils",
    Description = "Utils mod for Dominions Server",
    Authors = new[] { "archpriest" }
    )
]

namespace dominions.utils
{
    class Core : ModSystem
    {
        ICoreClientAPI capi;
        ICoreServerAPI sapi;

        public override double ExecuteOrder()
        {
            return 0;
        }

        public override void StartClientSide(ICoreClientAPI api)
        {
            capi = api;
            base.StartClientSide(api);
        }

        public override void StartServerSide(ICoreServerAPI api)
        {
            sapi = api;

            SetWorldSettings();
            RegisterServerEvents();

            base.StartServerSide(api);
        }

        void RegisterServerEvents()
        {

        }

        private void SetWorldSettings()
        {
            sapi.World.Config.SetBool("allowMap", false);
            sapi.World.Config.SetBool("allowCoordinateHud", false);
            sapi.World.Config.SetBool("allowLandClaiming", false);
            sapi.World.Config.SetBool("temporalStability", false);
            sapi.World.Config.SetString("temporalStorms", "off");
            sapi.World.Config.SetString("creatureStrength", "0.6");
            sapi.World.Config.SetBool("microblockChiseling", true);
            sapi.World.Config.SetString("playerHungerSpeed", "0.3");
            sapi.World.Config.SetString("blockGravity", "sandgravelsoil");
            sapi.World.Config.SetString("foodSpoilSpeed", "1.2");
            sapi.World.Config.SetString("toolMiningSpeed", "0.1");
            sapi.World.Config.SetString("toolDurability", "2");

            TerraGenConfig.geoProvMapScale = 128;
        }
    }
}
