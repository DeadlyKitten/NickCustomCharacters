using HarmonyLib;
using Loader.Core;
using Loader.Utils;
using Nick;
using SMU.Reflection;
using System.Collections.Generic;
using System.Linq;

namespace Loader.Patches
{
    [HarmonyPatch(typeof(GameAgentFX), "PrepareFX")]
    class GameAgentFX_PrepareFX
    {
        static void Prefix(ref GameAgentFX __instance, GameAgent ___agent)
        {
            if (CharacterManager.characters.Keys.Contains(___agent.GameUniqueIdentifier))
            {
                var assetLoader = __instance.gameObject.GetComponent<GameAssetLoader>();
                if (assetLoader)
                {
                    var toInsert = new List<GameFXBank>();

                    if (assetLoader.FX_common) toInsert.Add(DefaultAssetGrabber.FX_common);
                    if (assetLoader.FX_characterBase) toInsert.Add(DefaultAssetGrabber.FX_characterBase);

                    var fxLayers = __instance.fx.GetField<FXHandler, GameFXBank[]>("spawnFXLayers");
                    __instance.fx.SetField("spawnFXLayers", toInsert.Concat(fxLayers).ToArray());
                }
            }
        }
    }
}
