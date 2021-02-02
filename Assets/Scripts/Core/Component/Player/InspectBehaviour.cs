using System.Diagnostics.CodeAnalysis;
using Core.Component.Doodad;
using Core.Component.UI;
using UnityEngine;

namespace Core.Component.Player
{
    public class InspectBehaviour : MonoBehaviour
    {
        private Camera m_MainCamera;
        private CommonUIBehaviour m_CommonUIBehaviour;

        private void Start()
        {
            m_MainCamera = Camera.main;
            m_CommonUIBehaviour = CommonUIBehaviour.Instance;
        }

        private void Update()
        {
            Inspect();
        }

        [SuppressMessage("ReSharper", "InvertIf")]
        private void Inspect()
        {
            const float rayLength = 2f;
            var rayOrigin = new Vector3(0.5f, 0.5f, 0);
            var ray = m_MainCamera.ViewportPointToRay(rayOrigin);

            if (Physics.Raycast(ray, out var hit, rayLength))
            {
                var other = hit.collider.gameObject;

                if (other.TryGetComponent<InspectableBehaviour>(out var inspectableBehaviour))
                {
                    ShowUI(other.name);

                    if (Input.GetKeyDown(Controls.Inspect))
                    {
                        inspectableBehaviour.OnInspect();
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
            m_CommonUIBehaviour.ToggleInspectText(true);
            m_CommonUIBehaviour.ShowNameText(gameObjectName);
        }

        private void HideUI()
        {
            m_CommonUIBehaviour.ToggleInspectText(false);
            m_CommonUIBehaviour.HideNameText();
        }
    }
}