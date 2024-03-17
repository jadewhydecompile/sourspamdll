using System;
using HarmonyLib;

// Token: 0x02000002 RID: 2
[HarmonyPatch(typeof(kick))]
[HarmonyPatch("OnTriggerEnter")]
public static class KickPatch
{
	// Token: 0x06000001 RID: 1 RVA: 0x00002050 File Offset: 0x00000250
	private static bool Prefix()
	{
		return false;
	}
}
