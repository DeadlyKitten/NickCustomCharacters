using System;
using System.Collections.Generic;
using UnityEngine;

namespace Nick
{
	[CreateAssetMenu(fileName = "MVMovesetData", menuName = "ScriptableObjects/MVMovesetData")]
	public class MVMovesetData : ScriptableObject
	{
		[Serializable]
		public class Move
		{
			[Serializable]
			public class DataEntry
			{
				public string Name;

				public int Value;
			}

			[Serializable]
			public class Input
			{
				public int atFrame;

				public int dir = 5;

				public bool attack;

				public bool strong;

				public bool special;

				public bool jump;

				public bool defend;

				public bool fun;

				public bool taunt;
			}

			public string name;

			public string fromState = "idle";

			public Vector2 customPosition = new Vector2(0f, 0f);

			public bool reset;

			public string specialState = "";

			public string customCall = "";

			public bool useOpponent;

			public Vector2 opponentOffset = new Vector2(3f, 0f);

			public string opponentMove = "";

			public int selfDamage;

			public int opponentDamage;

			public string customDataName = "";

			public float customDataValue;

			public List<Input> inputs;
		}

		public MVMovesetData baseMoves;

		public string weakestSinglehitMove = "jab";

		public List<Move> moves;
	}
}