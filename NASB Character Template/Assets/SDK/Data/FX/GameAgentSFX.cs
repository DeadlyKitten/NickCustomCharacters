using UnityEngine;

namespace Nick
{
    public class GameAgentSFX : AttachedGameAgent
    {
        [SerializeField]
        private GameSFXBank[] sfxLayers;

        [SerializeField]
        private SFXTimelineBank[] sfxTimelineLayers;
    }
}