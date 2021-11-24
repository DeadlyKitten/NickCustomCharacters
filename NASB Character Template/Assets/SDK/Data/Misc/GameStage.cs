using System;

namespace Nick
{
    class GameStage
    {
		[Serializable]
		public class MovementConfig
		{
			public bool getParented;

			public bool leaveEdges;

			public bool passThrough;

			public bool fallThrough;

			public bool ignoreMovingStage;

			public bool bounce;

			public bool stop;

			public bool leaveParent;

			public float inheritParentVel;

			public StageLine.StageLayer ignoreStageLayer = StageLine.StageLayer.None;

			public float leaveEdgeRestrict;

			public bool simpleFreeMovement;

			public float simpleRadius;
		}
	}
}
