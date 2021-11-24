using System;
using UnityEngine;

namespace Nick
{
	[CreateAssetMenu(fileName = "AgentColorLayer", menuName = "ScriptableObjects/AgentColorLayer", order = 1)]
	public class AgentColorLayer : ScriptableObject
	{
		[Serializable]
		public class TimeGradient
		{
			public string id;

			public Gradient gradient;

			public float time = 1f;
		}

		public TimeGradient[] entries;
	}
}