using UnityEngine;

namespace Nick
{
    public class MaterialTinter : MonoBehaviour
    {
        public Renderer tintRenderer;

        public int tintMaterial;

        public string tintMaterialColor = "_TintColor";

        public Color tintWithColor = Color.clear;
    }
}