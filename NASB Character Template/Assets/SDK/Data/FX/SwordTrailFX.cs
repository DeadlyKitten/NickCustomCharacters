using UnityEngine;

namespace Nick
{
    public class SwordTrailFX : GameFX
    {
        public TrackTransform track_a;

        public TrackTransform track_b;

		public float time = 1f;

		public float pointsPerSecond = 300f;

		public bool addPointsPerSecond;

		public float biasCurve;

		public bool remain;

		public bool cometShaped;

		public float cometTime;

		public AnimationCurve cometCurve;

		public float frameCurving;

		public bool dragEnd;

		public bool staticTime;

		public SwordTrailOffsetting swordTrailOffsetting;

		public Gradient gradient_a;

		public Gradient gradient_b;

		public bool stretchGradients;

		public Gradient gradient_lifetime;

		public MeshFilter trail_Filter;
	}
}
