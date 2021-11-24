using System;
using UnityEngine;

namespace Nick
{
    [CreateAssetMenu(fileName = "SkinData", menuName = "ScriptableObjects/SkinData", order = 1)]
	public class SkinData : ScriptableObject
    {
        public string skinId;

		[SerializeField]
		private MeshSwitch[] meshSwitches;

		[SerializeField]
		private TextureSwitch[] textureSwitches;

		[Serializable]
		public struct MeshSwitch
		{
			public string id;

			public Mesh[] meshes;
		}

		[Serializable]
		public struct TextureSwitch
		{
			public string id;

			public Texture2D[] textures;
		}
	}
}
