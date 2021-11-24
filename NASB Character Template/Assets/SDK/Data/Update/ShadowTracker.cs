using UnityEngine;

namespace Nick
{
    class ShadowTracker : UpdateMe
    {
		[SerializeField]
		private TrackTransformMB tracker;

		[SerializeField]
		private GameObject matchActiveState;

		[SerializeField]
		private Transform matchObjPosY;
	}
}
