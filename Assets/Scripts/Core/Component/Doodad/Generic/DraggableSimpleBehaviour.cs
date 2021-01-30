using UnityEngine;

namespace Core.Component.Doodad.Generic
{
    public class DraggableSimpleBehaviour : DraggableBehaviour
    {
        private Camera m_MainCamera;
        private const float GrabDistance = 2f;

        private void Start()
        {
            m_MainCamera = Camera.main;
        }

        public override void OnDrag()
        {
            var mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, GrabDistance);
            var gameObjectPosition = m_MainCamera.ScreenToWorldPoint(mousePosition);

            transform.position = gameObjectPosition;
        }
    }
}