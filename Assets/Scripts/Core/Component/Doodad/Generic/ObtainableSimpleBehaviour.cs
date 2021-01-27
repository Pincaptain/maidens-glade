using System;
using Core.Component.Inventory;
using Core.Manager;
using UnityEngine;

namespace Core.Component.Doodad.Generic
{
    public class ObtainableSimpleBehaviour : ObtainableBehaviour
    {
        [SerializeField] private AudioClip obtainAudioClip;

        public override void OnObtain()
        {
            InventoryBehaviour.Instance.AddObtainable(obtainable);
            AudioManager.Instance.Play(obtainAudioClip);
            
            Destroy(gameObject);
        }
    }
}