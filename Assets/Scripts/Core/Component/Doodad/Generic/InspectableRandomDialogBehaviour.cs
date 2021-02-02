using System.Collections.Generic;
using Core.Component.UI;
using UnityEngine;
using Random = System.Random;

namespace Core.Component.Doodad.Generic
{
    public class InspectableRandomDialogBehaviour : InspectableBehaviour
    {
        [SerializeField] private List<string> options;
        [SerializeField] private int count = 1;

        private CommonUIBehaviour m_CommonUIBehaviour;

        private void Start()
        {
            m_CommonUIBehaviour = CommonUIBehaviour.Instance;
        }

        public override void OnInspect()
        {
            if (count > options.Count) return;
            
            var random = new Random();
            var temporaryOptions = new List<string>(options);

            for (var i = 0; i < count; i++)
            {
                var index = random.Next(0, temporaryOptions.Count);
                var option = temporaryOptions[index];
                    
                m_CommonUIBehaviour.EnqueueDialog(option);
                temporaryOptions.RemoveAt(index);
            }
        }
    }
}