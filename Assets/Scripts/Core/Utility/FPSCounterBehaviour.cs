using TMPro;
using UnityEngine;

namespace Core.Utility
{
    public class FPSCounterBehaviour : MonoBehaviour
    {
        private TMP_Text m_FPSText;
        private float m_Timer;

        private const float RefreshRate = 1f;

        private void Start()
        {
            m_FPSText = GameObject.Find("FPSText").GetComponent<TMP_Text>();
            m_Timer = 0f;
        }

        private void Update()
        {
            FPS();
        }

        private void FPS()
        {
            if (!(Time.unscaledTime > m_Timer)) return;
            
            var fps = (int) (1f / Time.unscaledDeltaTime);
            
            m_FPSText.text = $"{fps} FPS";
            m_Timer = Time.unscaledTime + RefreshRate;
        }
    }
}