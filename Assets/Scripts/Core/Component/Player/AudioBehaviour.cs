using UnityEngine;

namespace Core.Component.Player
{
    public class AudioBehaviour : MonoBehaviour
    {
        public static AudioBehaviour Instance { get; private set; }

        private AudioSource m_AudioSource;
        
        public void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
            else
            {
                Destroy(this);
            }
        }

        private void Start()
        {
            m_AudioSource = GetComponent<AudioSource>();
        }

        public void Play(AudioClip audioClip)
        {
            m_AudioSource.clip = audioClip;
            m_AudioSource.Play();
        }

        public void Repeat()
        {
            m_AudioSource.Play();
        }
    }
}