using UnityEngine;

namespace Core.Component.Player
{
    public class ZoomBehaviour : MonoBehaviour
    {
        [SerializeField] private int maxZoom = 35;
        [SerializeField] private float smoothness = 5f;
        
        private Camera m_Camera;
        private bool m_IsZooming;
        
        private const int NormalZoom = 60;

        private void Start()
        {
            m_Camera = Camera.main;
            m_IsZooming = false;
        }

        private void Update()
        {
            Zoom();
        }

        private void Zoom()
        {
            if (Input.GetMouseButtonDown(1))
            {
                m_IsZooming = true;
            }
            else if (Input.GetMouseButtonUp(1))
            {
                m_IsZooming = false;
            }
            
            m_Camera.fieldOfView = Mathf.Lerp(m_Camera.fieldOfView, m_IsZooming ? maxZoom : NormalZoom,
                Time.deltaTime * smoothness);
        }
    }
}