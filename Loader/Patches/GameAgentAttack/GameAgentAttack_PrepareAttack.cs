using HarmonyLib;
using Loader.Core;
using Loader.Utils;
using Nick;
using System.Collections.Generic;
using System.Linq;

namespace Loader.Patches
{
    [HarmonyPatch(typeof(GameAgentAttack), "PrepareAttack")]
    class GameAgentAttack_PrepareAttack
    {
        static void Prefix(ref GameAgentData __instance, ref AtkPropBank[] ___atkPropLayers, GameAgent ___agent)
        {
            if (CharacterManager.characters.Keys.Contains(___agent.GameUniqueIdentifier))
            {
                var assetLoader = __instance.gameObject.GetComponent<GameAssetLoader>();
                if (assetLoader)
                {
                    var toInsert = new List<AtkPropBank>();

                    if (assetLoader.Atk_characterBase) toInsert.Add(DefaultAssetGrabber.Atk_characterBase);

                    ___atkPropLayers = toInsert.Concat(___atkPropLayers).ToArray();
                }
            }
        }
    }
}
