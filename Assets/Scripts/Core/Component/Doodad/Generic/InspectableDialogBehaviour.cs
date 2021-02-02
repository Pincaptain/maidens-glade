using System.Collections.Generic;
using Core.Component.UI;
using UnityEngine;

namespace Core.Component.Doodad.Generic
{
    public class InspectableDialogBehaviour : InspectableBehaviour
    {
        [SerializeField] private List<string> dialog;

        private CommonUIBehaviour m_CommonUIBehaviour;

        private void Start()
        {
            m_CommonUIBehaviour = CommonUIBehaviour.Instance;
        }

        public override void OnInspect()
        {
            foreach (var line in dialog)
            {
                m_CommonUIBehaviour.EnqueueDialog(line);
            }
        }
    }
}