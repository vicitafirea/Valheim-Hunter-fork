﻿using HarmonyLib;
using UnityEngine;

namespace GrapplingHook
{
    [HarmonyPatch(typeof(ZNetScene), "Awake")]
    public static class ZNetScene_Awake_Patch
    {
        public static bool Prefix(ZNetScene __instance)
        {
            Setup.TryRegisterPrefabs(__instance);
            return true;
        }
    }
}
