using System;
using UnityEngine;

namespace Nick
{
    [Serializable]
    public class FXHandler
    {
        [SerializeField]
        private Transform spawnParent;

        [SerializeField]
        private GameFXBank localFX;

        [SerializeField]
        private GameFXBank[] spawnFXLayers;

        public SpawnType spawn;

        public enum SpawnType
        {
            SpawnEverything,
            SpawnImportant,
            SpawnUnimportant
        }
    }
}