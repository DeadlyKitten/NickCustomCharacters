using System;
using UnityEngine;

namespace Nick
{
    [CreateAssetMenu(fileName = "AgentDataLayer", menuName = "ScriptableObjects/AgentDataLayer", order = 1)]
    public class AgentDataLayer : ScriptableObject
    {
		[Serializable]
		public class FloatData
		{
			public string id;

			public float valueDefault;
		}

		[Serializable]
		public class TimerData
		{
			public string id;

			public float timerDefault;

			public float rateDefault = 1f;
		}

		[Serializable]
		public class StringData
		{
			public string id;

			public string stringDefault;
		}

		public FloatData[] floatData;

		public TimerData[] timerData;

		public StringData[] stringData;
	}
}