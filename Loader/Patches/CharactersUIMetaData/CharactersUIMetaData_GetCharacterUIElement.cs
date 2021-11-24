using HarmonyLib;
using Loader.Core;

namespace CustomCharacterLoader.Patches
{
    [HarmonyPatch(typeof(CharactersUIMetaData), "GetCharacterUIElement")]
    class CharactersUIMetaData_GetCharacterUIElement
    {
        static void Postfix(string id, ref CharactersUIMetaData.CharacterUIElements __result)
        {
            if (__result == null && CharacterManager.characters.TryGetValue(id, out var character))
            {
                __result = character.UIElements;
            }
        }
    }
}
