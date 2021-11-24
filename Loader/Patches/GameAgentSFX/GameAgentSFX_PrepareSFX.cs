using HarmonyLib;
using Loader.Core;
using Loader.Utils;
using Nick;
using SMU.Reflection;
using System.Collections.Generic;
using System.Linq;

namespace Loader.Patches
{
    [HarmonyPatch(typeof(GameAgentSFX), "PrepareSFX")]
    class GameAgentSFX_PrepareSFX
    {
        static void Prefix(ref GameAgentSFX __instance, GameAgent ___agent)
        {
            if (CharacterManager.characters.Keys.Contains(___agent.GameUniqueIdentifier))
            {
                var assetLoader = __instance.gameObject.GetComponent<GameAssetLoader>();
                if (assetLoader)
                {
                    var toInsert = new List<GameSFXBank>();

                    if (assetLoader.SFX_common) toInsert.Add(DefaultAssetGrabber.SFX_common);
                    if (assetLoader.SFX_characterBase) toInsert.Add(DefaultAssetGrabber.SFX_characterBase);

                    var sfxLayers = __instance.GetField<GameAgentSFX, GameSFXBank[]>("sfxLayers");
                    __instance.SetField("sfxLayers", toInsert.Concat(sfxLayers).ToArray());
                }
            }
        }
    }
}
