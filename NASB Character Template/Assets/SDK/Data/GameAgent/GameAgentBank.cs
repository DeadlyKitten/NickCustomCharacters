using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Nick
{
    [CreateAssetMenu(fileName = "GameAgentBank", menuName = "ScriptableObjects/GameAgentBank", order = 1)]
    public class GameAgentBank : ScriptableObject
    {
		[Serializable]
		public class IdAgent
		{
			public string id;

			public GameAgent ga;
		}

		public IdAgent[] ags;
	}
}
