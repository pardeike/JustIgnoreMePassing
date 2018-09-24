using Harmony;
using RimWorld;
using System.Reflection;
using Verse;

namespace JustIgnoreMePassing
{
	[StaticConstructorOnStartup]
	public static class JustIgnoreMePassing
	{
		static JustIgnoreMePassing()
		{
			var harmony = HarmonyInstance.Create("net.pardeike.rimworld.mod.just-ignore-me-passing");
			harmony.PatchAll(Assembly.GetExecutingAssembly());
		}
	}

	[HarmonyPatch(typeof(Game))]
	[HarmonyPatch("FinalizeInit")]
	static class Game_FinalizeInit_Patch
	{
		static void Postfix()
		{
			ModCounter.Trigger();
		}
	}

	[HarmonyPatch(typeof(GenConstruct))]
	[HarmonyPatch("BlocksConstruction")]
	static class GenConstruct_BlocksConstruction_Patch
	{
		static bool Prefix(ref bool __result, Thing constructible, Thing t)
		{
			//if (constructible.OccupiedRect().Area > 1)
			//	return true;

			if (t is Pawn)
			{
				__result = false;
				return false;
			}
			return true;
		}
	}
}