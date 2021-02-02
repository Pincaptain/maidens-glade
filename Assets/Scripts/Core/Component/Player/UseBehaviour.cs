using System.Diagnostics.CodeAnalysis;
using Core.Component.Doodad;
using Core.Component.UI;
using UnityEngine;

namespace Core.Component.Player
{
    public class UseBehaviour : MonoBehaviour
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
            Use();
        }

        [SuppressMessage("ReSharper", "InvertIf")]
        private void Use()
        {
            const float rayLength = 2f;
            var rayOrigin = new Vector3(0.5f, 0.5f, 0);
            var ray = m_MainCamera.ViewportPointToRay(rayOrigin);

            if (Physics.Raycast(ray, out var hit, rayLength))
            {
                var other = hit.collider.gameObject;

                if (other.TryGetComponent<UsableBehaviour>(out var usableBehaviour))
                {
                    ShowUI(other.name);

                    if (Input.GetKeyDown(Controls.Use))
                    {
                        usableBehaviour.OnUse();
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
            m_CommonUIBehaviour.ToggleUseText(true);
            m_CommonUIBehaviour.ShowNameText(gameObjectName);
        }

        private void HideUI()
        {
            m_CommonUIBehaviour.ToggleUseText(false);
            m_CommonUIBehaviour.HideNameText();
        }
    }
}