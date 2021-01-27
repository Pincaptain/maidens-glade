using System.Diagnostics.CodeAnalysis;
using UnityEngine;

namespace Core.Component.Doodad.Generic
{
    public class DraggableSimpleBehaviour : DraggableBehaviour
    {
        private Camera m_MainCamera;

        private void Start()
        {
            m_MainCamera = Camera.main;
        }

        public override void OnDrag()
        {
            var mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y,
                -m_MainCamera.transform.position.z + transform.position.z + 1f);
            var gameObjectPosition = m_MainCamera.ScreenToWorldPoint(mousePosition);

            transform.position = gameObjectPosition;
        }
    }
}