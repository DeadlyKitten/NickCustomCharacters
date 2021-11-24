using UnityEngine;

namespace Loader.Utils
{
    public class ShaderSwapper : MonoBehaviour
    {
        [SerializeField]
        private int materialIndex;

        [SerializeField]
        private string shaderName;

        [SerializeField]
        private bool doProjector;

#if PLUGIN
        void Start()
        {
            if (shaderName == null) return;

            var renderer = GetComponent<Renderer>();

            Projector projector = null;
            if (doProjector)
                projector = GetComponent<Projector>();

            var shader = Shader.Find(shaderName);

            if (shader)
            {
                if (renderer)
                    renderer.materials[materialIndex].shader = shader;
                if (projector && materialIndex == 0)
                    projector.material.shader = shader;
            }
            else
                Plugin.LogWarning($"Shader with name \"{shaderName}\" not found!");
        }
#endif
    }
}