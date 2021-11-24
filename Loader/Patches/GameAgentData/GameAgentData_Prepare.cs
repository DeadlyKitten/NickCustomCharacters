using HarmonyLib;
using Loader.Core;
using Loader.Utils;
using Nick;
using System.Collections.Generic;
using System.Linq;

namespace Loader.Patches
{
    [HarmonyPatch(typeof(GameAgentData), "PrepareData")]
    class GameAgentData_Prepare
    {
        static void Prefix(ref GameAgentData __instance, ref AgentDataLayer[] ___dataLayers, GameAgent ___agent)
        {
            if (CharacterManager.characters.Keys.Contains(___agent.GameUniqueIdentifier))
            {
                var assetLoader = __instance.gameObject.GetComponent<GameAssetLoader>();
                if (assetLoader)
                {
                    var toInsert = new List<AgentDataLayer>();

                    if (assetLoader.Data_blastzoneKOBase) toInsert.Add(DefaultAssetGrabber.Data_blastzoneKOBase);
                    if (assetLoader.Data_grabbableBase) toInsert.Add(DefaultAssetGrabber.Data_grabbableBase);
                    if (assetLoader.Data_launchableBase) toInsert.Add(DefaultAssetGrabber.Data_launchableBase);
                    if (assetLoader.Data_characterBase) toInsert.Add(DefaultAssetGrabber.Data_characterBase);

                    ___dataLayers = toInsert.Concat(___dataLayers).ToArray();
                }
            }
        }
    }
}
