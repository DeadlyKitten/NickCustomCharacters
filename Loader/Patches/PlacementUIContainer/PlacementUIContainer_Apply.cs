using System;
using System.Collections;
using System.Text;
using Nick;
using HarmonyLib;
using UnityEngine;
using Loader.Core;
using UnityEngine.UI;
using Loader.Data;
using SMU.Utilities;

namespace Loader.Patches
{
    [HarmonyPatch(typeof(PlacementUIContainer), "Apply")]
    class PlacementUIContainer_Apply
    {
        static void Postfix(PlacementUIContainer __instance, CharacterMetaData cmd)
        {
            if (CharacterManager.characters.TryGetValue(cmd.id, out var character))
            {
                SharedCoroutineStarter.StartCoroutine(SetImagesDelayed(__instance, cmd, character));
            }
        }

        static IEnumerator SetImagesDelayed(PlacementUIContainer __instance, CharacterMetaData cmd, CustomCharacter character)
        {
            yield return null;

            var backgroundPath = "PlayerStats/PortraitMask/CharacterBackground";
            var portraitPath = $"PlayerStats/PortraitMask/CharacterRenderVisualizer/Characters/{cmd.id}";

            var background = __instance.transform.Find(backgroundPath).GetComponent<RawImage>();
            background.texture = character.PlayerSlotBackground.texture;
            background.enabled = true;

            var portrait = __instance.transform.Find(portraitPath).GetComponent<RawImage>();
            portrait.enabled = true;

            // Do this because they're getting flipped back to disabled
            // Not pretty but it works!
            yield return new WaitUntil(() => !background.enabled || !portrait.enabled);

            background.enabled = true;
            portrait.enabled = true;
        }
    }
}
