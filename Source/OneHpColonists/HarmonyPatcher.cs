using HarmonyLib;
using Verse;

namespace OneHpColonists;

[StaticConstructorOnStartup]
public class HarmonyPatcher
{
    static HarmonyPatcher()
    {
        var harmony = new Harmony("rimworld.mod.me.onehpcolonists");
        harmony.PatchAll();
    }
}

[HarmonyPatch(typeof(DamageWorker_AddInjury), "ApplyToPawn")]
public static class Patch
{
    public static void Postfix(DamageInfo dinfo, Pawn pawn, ref DamageWorker.DamageResult __result)
    {
        if (pawn.IsColonist && !__result.deflected)
        {
            pawn.Kill(dinfo);
        }
    }
}