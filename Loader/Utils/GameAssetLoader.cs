using UnityEngine;

namespace Loader.Utils
{
    class GameAssetLoader : MonoBehaviour
    {
        [Header("State Layers")]
        public bool blastzoneKOBase = true;
        public bool grabbableBase = true;
        public bool launchableBase = true;
        public bool characterBase = true;

        [Header("Data Layers")]
        public bool Data_blastzoneKOBase = true;
        public bool Data_grabbableBase = true;
        public bool Data_launchableBase = true;
        public bool Data_characterBase = true;

        [Header("Spawn FX Layers")]
        public bool FX_common = true;
        public bool FX_characterBase = true;

        [Header("SFX Layers")]
        public bool SFX_common = true;
        public bool SFX_characterBase = true;
    }
}
