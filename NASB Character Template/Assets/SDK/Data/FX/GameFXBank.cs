using System;
using UnityEngine;

namespace Nick
{
    public class GameFXBank : MonoBehaviour
    {
        [SerializeField]
        private Entry[] entries;

        [Serializable]
        public class Entry
        {
            public string id = string.Empty;

            public GameFX fx;
        }
    }
}