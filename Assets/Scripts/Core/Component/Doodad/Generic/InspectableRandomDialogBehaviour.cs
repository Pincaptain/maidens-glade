using System.Collections;
using System.Collections.Generic;
using Core.Manager;
using UnityEngine;
using Random = System.Random;

namespace Core.Component.Doodad.Generic
{
    public class InspectableRandomDialogBehaviour : InspectableBehaviour
    {
        [SerializeField] private List<string> options;
        [SerializeField] private int count = 1;
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

            if (count <= options.Count)
            {
                var random = new Random();
                var temporaryOptions = new List<string>(options);
                
                for (var i = 0; i < count; i++)
                {
                    var index = random.Next(0, temporaryOptions.Count);
                    var option = temporaryOptions[index];
                    
                    m_InterfaceManager.ChangeDialogText(option);
                    temporaryOptions.RemoveAt(index);
                    
                    yield return new WaitForSeconds(delay);
                }
            }

            m_InterfaceManager.ClearDialogText();
            m_InProgress = false;
        }
    }
}