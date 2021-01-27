using System.Collections;
using System.Collections.Generic;
using Core.Manager;
using UnityEngine;

namespace Core.Component.Doodad.Generic
{
    public class InspectableDialogBehaviour : InspectableBehaviour
    {
        [SerializeField] private List<string> dialog;
        [SerializeField] private float delay = 2f;

        private InterfaceManager m_InterfaceManager;
        private bool m_InProgress;

        private void Start()
        {
            m_InterfaceManager = InterfaceManager.Instance;
            m_InProgress = false;
        }

        public override void OnInspect()
        {
            if (!m_InProgress)
            {
                StartCoroutine(Dialog());
            }
        }

        private IEnumerator Dialog()
        {
            m_InProgress = true;
            
            foreach (var line in dialog)
            {
                m_InterfaceManager.ChangeDialogText(line);
                yield return new WaitForSeconds(delay);
            }
            
            m_InterfaceManager.ClearDialogText();
            m_InProgress = false;
        }
    }
}