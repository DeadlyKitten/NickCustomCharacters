using UnityEngine;

namespace Nick
{
    class TweenFX : UpdateMe
    {
		public EliasEase.Ease ease;

		public bool customTween;

		public AnimationCurve customCurve;

		public float elapsedMult = 1f;

		public bool clamp;

		public float clampLength = 1f;

		public float loopLength;
	}
}
