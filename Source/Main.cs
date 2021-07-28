using HarmonyLib;
using RimWorld;
using Verse;

namespace JustIgnoreMePassing
{
	[StaticConstructorOnStartup]
	public static class JustIgnoreMePassing
	{
		static JustIgnoreMePassing()
		{
			var harmony = new Harmony("net.pardeike.rimworld.mod.just-ignore-me-passing");
			harmony.PatchAll();
		}
	}

	[HarmonyPatch(typeof(GenConstruct), nameof(GenConstruct.BlocksConstruction))]
	static class GenConstruct_BlocksConstruction_Patch
	{
		public static bool Prefix(ref bool __result, Thing t)
		{
			if (t is Pawn)
			{
				__result = false;
				return false;
			}
			return true;
		}
	}
}
