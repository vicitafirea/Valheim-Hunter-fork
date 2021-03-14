﻿using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace GrapplingHook
{
    [HarmonyPatch(typeof(Localization), "SetupLanguage")]
    public static class Localization_SetupLanguage_Patch
    {
        public static void Postfix(Localization __instance)
        {
            var addWord = typeof(Localization).GetMethod("AddWord", BindingFlags.NonPublic | BindingFlags.Instance);
            addWord.Invoke(__instance, new object[] { "item_grappling_hook", "Grappling Hook" });
            addWord.Invoke(__instance, new object[] { "se_grappled_name", "Grappled" });
        }
    }
}
