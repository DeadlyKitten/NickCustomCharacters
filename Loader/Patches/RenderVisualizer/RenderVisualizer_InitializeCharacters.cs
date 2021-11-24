using HarmonyLib;
using Loader.Core;
using UnityEngine;

namespace CustomCharacterLoader.Patches
{
    [HarmonyPatch(typeof(RenderVisualizer), "InitializeCharacters")]
    class RenderVisualizer_InitializeCharacters
    {
        static void Prefix(RenderVisualizer __instance, Transform ___charactersParent)
        {
            var go = ___charactersParent.GetChild(0).gameObject;

            foreach (var character in CharacterManager.characters.Values)
            {
                if (___charactersParent.Find(character.id)) continue;

                var instance = Object.Instantiate(go, go.transform.position, go.transform.rotation, ___charactersParent);
                instance.name = character.id;
                instance.GetComponent<RenderImage>().CharacterMetaData = character.meta;
            }
        }
    }
}
