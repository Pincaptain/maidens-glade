using System;
using System.Diagnostics.CodeAnalysis;
using Core.Component.Doodad;
using Core.Manager;
using UnityEngine;

namespace Core.Component.Player
{
    public class DragBehaviour : MonoBehaviour
    {
        private Camera m_MainCamera;
        private InterfaceManager m_InterfaceManager;
        private bool m_IsDragging;
        private DraggableBehaviour m_DraggableBehaviour;

        private void Start()
        {
            m_MainCamera = Camera.main;
            m_InterfaceManager = InterfaceManager.Instance;
        }

        private void Update()
        {
            Drag();
        }

        [SuppressMessage("ReSharper", "InvertIf")]
        private void Drag()
        {
            const float rayLength = 2f;
            var rayOrigin = new Vector3(0.5f, 0.5f, 0);
            var ray = m_MainCamera.ViewportPointToRay(rayOrigin);
            
            if (m_IsDragging)
            {
                m_DraggableBehaviour.OnDrag();

                if (Input.GetKeyUp(Controls.Drag))
                {
                    m_IsDragging = false;
                }
            }

            if (Physics.Raycast(ray, out var hit, rayLength))
            {
                var other = hit.collider.gameObject;

                if (other.TryGetComponent(out m_DraggableBehaviour))
                {
                    ShowUI(other.name);

                    if (Input.GetKeyDown(Controls.Drag))
                    {
                        m_IsDragging = true;
                    }
                }
                else
                {
                    HideUI();
                }
            }
            else
            {
                HideUI();
            }
        }

        private void ShowUI(string gameObjectName)
        {
            m_InterfaceManager.ToggleDragText(true);
            m_InterfaceManager.ShowNameText(gameObjectName);
        }

        private void HideUI()
        {
            m_InterfaceManager.ToggleDragText(false);
            m_InterfaceManager.HideNameText();
        }
    }
}