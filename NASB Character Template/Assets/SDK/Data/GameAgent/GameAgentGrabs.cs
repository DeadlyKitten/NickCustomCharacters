using System;
using UnityEngine;

namespace Nick
{
    class GameAgentGrabs : AttachedGameAgent
    {
		[SerializeField]
		private Config config = new Config();

		[SerializeField]
		private string GrabbedEscapedStateId;

		[Serializable]
		public class Config
		{
			public bool hardSyncPos;

			public bool allowGrabEscape;

			public void CopyFrom(Config other)
			{
				hardSyncPos = other.hardSyncPos;
				allowGrabEscape = other.allowGrabEscape;
			}
		}
	}
}
