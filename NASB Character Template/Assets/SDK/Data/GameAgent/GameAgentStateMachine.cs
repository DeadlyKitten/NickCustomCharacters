using UnityEngine;

namespace Nick
{
    class GameAgentStateMachine : AttachedGameAgent
    {
        [SerializeField]
        private TextAsset[] stateLayers;

        [SerializeField]
        private string[] tagsDefault;
    }
}
