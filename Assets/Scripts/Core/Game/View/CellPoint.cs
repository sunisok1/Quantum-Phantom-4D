using UnityEngine;

namespace Core.Game.View
{
    [RequireComponent(typeof(MeshRenderer))]
    public class CellPoint : MonoBehaviour
    {
        private MeshRenderer meshRenderer;

        private bool walkable;

        private void Awake()
        {
            meshRenderer = GetComponent<MeshRenderer>();
        }

        public void SetColor(Color color)
        {
            meshRenderer.material.color = color;
        }
    }
}