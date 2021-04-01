﻿using BepInEx;
using HarmonyLib;
using JotunnLib;
using JotunnLib.Managers;
using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace ExampleMob
{
    [BepInPlugin("dickdangerjustice.ExampleMob", "Example Mob", "1.0.0")]
    [BepInDependency(JotunnLib.JotunnLib.ModGuid)]
    public class Mod : BaseUnityPlugin
    {
        private void Awake()
        {
            PrefabManager.Instance.PrefabRegister += RegisterPrefabs;
        }

        private void RegisterPrefabs(object sender, EventArgs e)
        {
            var boar2Bundle = AssetBundleHelper.GetAssetBundleFromResources("boar2");
            var boar2 = boar2Bundle.LoadAsset<GameObject>("Assets/CustomItems/Boar2/Boar2.prefab");

            // when this is fixed, the call should be:
            // PrefabManager.Instance.RegisterPrefab(swordBlock, "SwordBlock");
            AccessTools.Method(typeof(PrefabManager), "RegisterPrefab", new Type[] { typeof(GameObject), typeof(string) }).Invoke(PrefabManager.Instance, new object[] { boar2, "Boar2" });
        }
    }
}
