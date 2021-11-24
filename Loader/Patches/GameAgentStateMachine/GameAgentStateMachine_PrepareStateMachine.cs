using HarmonyLib;
using Loader.Core;
using Loader.Utils;
using Nick;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Loader.Patches
{
    [HarmonyPatch(typeof(GameAgentStateMachine), "PrepareStateMachine")]
    class GameAgentStateMachine_PrepareStateMachine
    {
        static void Prefix(ref GameAgentStateMachine __instance, bool recycled, ref TextAsset[] ___stateLayers, GameAgent ___agent)
        {
            if (!recycled)
            {
                if (CharacterManager.characters.Keys.Contains(___agent.GameUniqueIdentifier))
                {
                    var assetLoader = __instance.gameObject.GetComponent<GameAssetLoader>();
                    if (assetLoader)
                    {
                        var toInsert = new List<TextAsset>();

                        if (assetLoader.blastzoneKOBase) toInsert.Add(DefaultAssetGrabber.blastzoneKOBase);
                        if (assetLoader.grabbableBase) toInsert.Add(DefaultAssetGrabber.grabbableBase);
                        if (assetLoader.launchableBase) toInsert.Add(DefaultAssetGrabber.launchableBase);
                        if (assetLoader.characterBase) toInsert.Add(DefaultAssetGrabber.characterBase);

                        ___stateLayers = toInsert.Concat(___stateLayers).ToArray();
                    }
                }
            }
        }
    }
}
