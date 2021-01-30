using System.Collections;
using Core.Component.Doodad;
using UnityEngine;

namespace Game.Event
{
    public class ScrewEffect : UsableBehaviour
    {
        private bool m_IsRotating;
        private float m_RotationDuration;

        private void Start()
        {
            m_IsRotating = false;
            m_RotationDuration = 1f;
        }

        public override void OnUse()
        {
            if (m_IsRotating) return;
            
            StartCoroutine(PerformRotation(m_RotationDuration));
        }

        private IEnumerator PerformRotation(float duration)
        {
            var startRotation = transform.eulerAngles.y;
            var endRotation = startRotation + 360f;
            var time = 0f;

            while (time < duration)
            {
                time += Time.deltaTime;
                var yRotation = Mathf.Lerp(startRotation, endRotation, time / duration) % 360f;
                transform.eulerAngles = new Vector3(transform.eulerAngles.x, yRotation, transform.eulerAngles.z);
                yield return null;
            }

            m_IsRotating = false;
        }
    }
}