using Core.Component.Inventory;
using UnityEngine;
using AudioBehaviour = Core.Component.Player.AudioBehaviour;

namespace Core.Component.Doodad.Generic
{
    public class ObtainableSimpleBehaviour : ObtainableBehaviour
    {
        [SerializeField] private AudioClip obtainAudioClip;

        public override void OnObtain()
        {
            InventoryBehaviour.Instance.AddObtainable(obtainable);
            AudioBehaviour.Instance.Play(obtainAudioClip);

            Destroy(gameObject);
        }
    }
}