using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace Nick
{
    class GameAgentColors : AttachedGameAgent
    {
        [SerializeField]
        private AgentColorLayer[] colorLayers;

        [SerializeField]
        private MaterialTinter[] materialTinters;
    }
}
