using UnityEngine;

namespace Nick
{
    public class GameAgentAnimation : AttachedGameAgent
    {
        [SerializeField]
        private Animation anim;

        [SerializeField]
        private string restoreAnimClip;
    }
}