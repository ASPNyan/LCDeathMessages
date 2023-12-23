using System.Diagnostics.CodeAnalysis;
using BepInEx;
using BepInEx.Logging;
using GameNetcodeStuff;
using HarmonyLib;
using Unity.Netcode;
using static LCDeathMessages.PluginInfo;

namespace LCDeathMessages;

[BepInPlugin(PLUGIN_GUID, PLUGIN_NAME, PLUGIN_VERSION)]
public class Plugin : BaseUnityPlugin
{
    public static StartOfRound RoundData => StartOfRound.Instance;
    [NotNull] public static ManualLogSource? Log { get; private set; }

    public static Plugin? Instance;
    private readonly Harmony _harmony = new(PLUGIN_GUID);
        
    private void Awake()
    {
        Instance ??= this;
        Logger.LogInfo("Started Death Messages Plugin Successfully.");
        _harmony.PatchAll(typeof(Plugin));
        Log = Logger;
    }

    // ReSharper disable once InconsistentNaming | Harmony requires double underscore prefix for injected values.
    [HarmonyPatch(typeof(PlayerControllerB), nameof(PlayerControllerB.KillPlayer)), HarmonyPostfix]
    private static void SendDeathMessage(PlayerControllerB __instance)
    {
        const string terrariaRed = "#E11919";
        
        if (!__instance.isPlayerDead) return;
        
        string deathMessage = DeathMessages.Get(__instance.causeOfDeath, __instance.playerUsername);
        string colored = $"<color={terrariaRed}>{deathMessage}</color>";
        
        HUDManager.Instance.AddTextToChatOnServer(colored);
    }
}