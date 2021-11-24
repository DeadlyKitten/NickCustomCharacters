using System;
using UnityEngine;

namespace Nick
{
    class GameAgentCameraInfo : AttachedGameAgent
	{
		[Serializable]
		public class Config
		{
			public bool activeInclude;

			public bool dontIncludeVertical;

			public float centerRadius;

			public bool trackLastGrounded;

			public float addXMovement;

			public float addYUpMovement;

			public float addYDownMovement;

			public bool clampAddYDownByFloor;

			public float addUp;

			public float addDown;

			public float addRight;

			public float addLeft;

			public bool includeRespawnPoint;

			public float includeLaunchDestination;

			public bool moveResultsCamToFixedPos;
		}

		[SerializeField]
		private Config baseconfig;
	}
}
