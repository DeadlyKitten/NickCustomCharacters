using System;
using UnityEngine;

namespace Nick
{
    internal class SkinObjectSwitch : MonoBehaviour
    {
        public GameObject go;

        public bool state = true;

        public SkinValid[] valids;

		[Serializable]
		public class SkinValid
		{
			public string skinId;

			public bool allColors;

			public int[] colors;
		}
	}
}