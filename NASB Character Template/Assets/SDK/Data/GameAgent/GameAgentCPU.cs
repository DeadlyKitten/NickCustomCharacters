using UnityEngine;

namespace Nick
{
    public class GameAgentCPU : AttachedGameAgent
    {
        [SerializeField]
        private CPUMovesetData moveset;

        public MVMovesetData modelViewerData;
    }
}