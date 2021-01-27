using System.Diagnostics.CodeAnalysis;
using Core.Component.Doodad;
using Core.Manager;
using UnityEngine;

namespace Core.Component.Player
{
    public class ObtainBehaviour : MonoBehaviour
    {
        private Camera m_MainCamera;
        private InterfaceManager m_InterfaceManager;

        private void Start()
        {
            m_MainCamera = Camera.main;
            m_InterfaceManager = InterfaceManager.Instance;
        }

        private void Update()
        {
            Obtain();
        }

        [SuppressMessage("ReSharper", "InvertIf")]
        private void Obtain()
        {
            const float rayLength = 2f;
            var rayOrigin = new Vector3(0.5f, 0.5f, 0);
            var ray = m_MainCamera.ViewportPointToRay(rayOrigin);

            if (Physics.Raycast(ray, out var hit, rayLength))
            {
                var other = hit.collider.gameObject;

                if (other.TryGetComponent<ObtainableBehaviour>(out var obtainableBehaviour))
                {
                    ShowUI(other.name);

                    if (Input.GetKeyDown(Controls.Obtain))
                    {
                        obtainableBehaviour.OnObtain();
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
            m_InterfaceManager.ToggleObtainText(true);
            m_InterfaceManager.ShowNameText(gameObjectName);
        }

        private void HideUI()
        {
            m_InterfaceManager.ToggleObtainText(false);
            m_InterfaceManager.HideNameText();
        }
    }
}