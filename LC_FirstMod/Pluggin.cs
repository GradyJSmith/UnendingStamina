using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BepInEx;
using BepInEx.Configuration;
using BepInEx.Logging;
using HarmonyLib;
using LC_FirstMod.Patches;

namespace UnendingStamina
{
    [BepInPlugin(modGUID, modName, modVersion)]

    public class UnendingStaminaBase : BaseUnityPlugin
    {
        //setup
        private const string modGUID = "GStar.UnendingStamina";
        private const string modName = "UnendingStamina";
        private const string modVersion = "1.0.0";

        private readonly Harmony harmony = new Harmony(modGUID);

        private static UnendingStaminaBase Instance;

        internal ManualLogSource mls;

        void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }

            mls = BepInEx.Logging.Logger.CreateLogSource(modGUID);

            mls.LogInfo("Unending stamina has been activated");

            harmony.PatchAll(typeof(UnendingStaminaBase));
            harmony.PatchAll(typeof(PlayerControllerBPatch));
        }
    }
}
