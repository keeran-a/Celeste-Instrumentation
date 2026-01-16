using HarmonyLib;
using Celeste;

namespace Instrumentation.Patches
{
	[HarmonyPatch(typeof(Player), "Update")]
	class Celeste_Player_Update_Patch
	{
		[HarmonyPostfix]
		static void Postfix(Player __instance)
		{
			InputsManager.Update();
		}
	}
}
