using HarmonyLib;
using Loader.Core;
using Nick;
using System.Linq;
using UnityEngine;

namespace Loader.Patches
{
    [HarmonyPatch(typeof(CharacterSelectScreen), "MenuOpen")]
    class CharacterSelectScreen_MenuOpen
    {
        static void Postfix(CharacterSelectScreen __instance)
        {
            var customCharCount = CharacterManager.characters.Keys.Count();

            var characterSlots = __instance.transform.Find("Canvas/MainContainer/CharacterSlots");
            characterSlots.Translate(Vector3.left * Mathf.CeilToInt((float)customCharCount / 3.0f) * 100);
        }
    }
}
