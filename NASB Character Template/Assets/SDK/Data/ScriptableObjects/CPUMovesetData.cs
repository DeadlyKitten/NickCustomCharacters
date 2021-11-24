using System;
using System.Collections.Generic;
using UnityEngine;

namespace Nick
{
	[CreateAssetMenu(fileName = "CPUMovesetData", menuName = "ScriptableObjects/CPUMovesetData")]
	public class CPUMovesetData : ScriptableObject
	{
		public float characterHeight = 5f;

		public float characterWidth = 3f;

		public float characterCenterHeight = 2.5f;
	}
}
