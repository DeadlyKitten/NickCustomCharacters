using HarmonyLib;
using Loader.Core;
using UnityEngine.UI;

namespace CustomCharacterLoader.Patches
{
    [HarmonyPatch(typeof(RenderImage), "ToggleShow")]
    class RenderVisualizer_ToggleShow
    {
        static void Postfix(RenderImage __instance, ref bool ___seekingTexture, ref RawImage ___rawImage, ref bool ___usesPath)
        {
            if (__instance.CharacterMetaData && ___usesPath)
            {
                if (CharacterManager.characters.TryGetValue(__instance.CharacterMetaData.id, out var character))
                {
                    ___seekingTexture = false;
                    ___rawImage.texture = character.SmallPortrait.texture;
                    ___rawImage.enabled = true;
                }
            }
        }
    }
}
