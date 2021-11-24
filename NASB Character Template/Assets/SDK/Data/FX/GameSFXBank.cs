using System;
using UnityEngine;

namespace Nick
{
    internal class GameSFXBank : MonoBehaviour
    {
		[Serializable]
		public class SFXEntry
		{
			public string id;

			public GameSFX sfx;
		}

		public SFXEntry[] entries;
	}
}