using System;
using UnityEngine;

namespace Nick
{
    class GameAgentCombat : AttachedGameAgent
	{
		[Serializable]
		public class Config
		{
			public float weight;

			public bool getgrabbed;

			public int grabinvulnerability;

			public float blockPush;

			public int blockHoldVertical;

			public int blockHoldHorizontal;

			public bool checkBlastzones;

			public bool checkTopBlastzone;

			public bool alwaysLaunch;

			public bool preventHitstunTurn;

			public bool preventLaunches;	
		}

		[SerializeField]
		private Config config;

		[SerializeField]
		private GameAgentCombatIds ids = new GameAgentCombatIds();

		[SerializeField]
		private float addDamage;

		[SerializeField]
		private bool clampDamageTaken;

		[SerializeField]
		private float clampDamageTakenAt;

		[SerializeField]
		private CombatFate.HitInWorld.SpecialCase specialCase;

		[SerializeField]
		private float criticalDamage = 150f;

		[SerializeField]
		private float criticalRespawnMaxDamage = 100f;

		[SerializeField]
		private float criticalRespawnHeal = 30f;

		[SerializeField]
		private bool isProjectile;
	}
}
