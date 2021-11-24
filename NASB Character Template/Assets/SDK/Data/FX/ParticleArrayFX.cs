using UnityEngine;

namespace Nick
{
    class ParticleArrayFX : GameFX
    {
		public ParticleSystem[] particlesystems;

		public bool doneOnLength;

		public float warmup;

		public bool randomWarmup;

		public float randomWarmUpLength;

		public bool randomSeed;

		public bool clearOnRestart = true;

		public float loopedExtraTime = 2f;
	}
}
