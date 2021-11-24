using System;
using UnityEngine;

namespace Nick
{
    class GameAgentAttack : AttachedGameAgent
	{
		[SerializeField]
		private AtkPropBank[] atkPropLayers;

		[SerializeField]
		private Config config;

		[Serializable]
		public class Config
		{
			public float unIgnoreFrames;

			public float dmgmult = 1f;

			public float kbmult = 1f;
		}
	}
}
