using System;
using UnityEngine;

namespace Nick
{
    public class GameAgentMovement : AttachedGameAgent
	{
		[SerializeField]
		private Config config;

		[SerializeField]
		private GameStage.MovementConfig moveconfig;

		public Vector2 moveVel;

		public float slideX;

		[SerializeField]
		private string grabEdgeStateId = "edge-grab";

		[SerializeField]
		private Transform[] sizeBones;



		[Serializable]
		public class Config
		{
			public float increaseMoveDT;

			public float increaseMoveDTFalloff;

			public float allowCtrl;

			public bool rootPosReset = true;

			public bool forceNextFloorCheck;

			public bool checkFloorFromMid = true;

			public bool extendFloorCheckToMid;

			public float checkFloorThickness = 0.75f;

			public float fallSpeed = 30f;

			public float fallSpeedMultiplier = 1f;

			public float gravity = 100f;

			public float antigravity = 100f;

			[Tooltip("Additional modifier for floor speed, rarely used")]
			public float floorFriction = 1f;

			[Tooltip("How fast an agent will reach their maximum ground speed")]
			public float floorAcc = 100f;

			[Tooltip("How fast an agent can reverse their momentum on the ground")]
			public float floorDec = 100f;

			[Tooltip("How fast an agent's ground speed returns to zero without horizontal input")]
			public float floorBrake = 100f;

			[Tooltip("An agent's maximum ground speed")]
			public float floorSpeed = 30f;

			[Tooltip("How fast an agent will slow down to their maximum ground speed when exceeded")]
			public float floorDecay = 100f;

			[Tooltip("Additional modifier for air speed, rarely used")]
			public float airFriction = 1f;

			[Tooltip("How fast an agent will reach their maximum air speed")]
			public float airAcc = 100f;

			[Tooltip("How fast an agent can reverse their momentum in the air")]
			public float airDec = 100f;

			[Tooltip("How fast an agent's air speed returns to zero without horizontal input")]
			public float airBrake = 100f;

			[Tooltip("An agent's maximum air speed")]
			public float airSpeed = 30f;

			[Tooltip("How fast an agent will slow down to their maximum air speed when exceeded")]
			public float airDecay = 100f;

			public float xSpeedMultiplier = 1f;

			public Vector2 rootMotionMult = Vector2.one;

			public bool resizeCollision = true;

			public float minColH = 0.5f;

			public float minColW = 0.5f;

			public float extendBottom;

			public bool bottomCollisionWorldPos;

			public bool crowdPushing;

			public float crowdPushRadius = 1f;

			public float crowdPushWeight = 100f;

			public float crowdPushMaxDistPerFrame = 1f;

			public bool crowdPushingFromLedge;

			public bool grabEdge;

			public float grabEdgeExtendFwd = 1f;

			public float grabEdgeExtendBack = 1f;

			public float grabEdgeExtendUp = 1f;

			public float grabEdgeExtendDown;

			public bool disableCollision;

			public bool disableMovement;

			public bool disableSink;
		}
		}
}
