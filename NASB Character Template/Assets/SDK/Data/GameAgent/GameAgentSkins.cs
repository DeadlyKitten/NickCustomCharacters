using UnityEngine;

namespace Nick
{
    class GameAgentSkins : AttachedGameAgent
	{
		[SerializeField]
		private SkinObjectSwitch[] switchObjects;

		[SerializeField]
		private SkinTextureSwitch[] switchTextures;

		[SerializeField]
		private SkinMeshSwitch[] switchMeshes;
	}
}
