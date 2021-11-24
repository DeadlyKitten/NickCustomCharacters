using System;
using UnityEngine;

namespace Nick
{
    [Serializable]
	public class TrackTransform
	{
		public Transform track;

		public Vector3 localoffset = Vector3.zero;

		public Vector3 worldoffset = Vector3.zero;
	}
}
