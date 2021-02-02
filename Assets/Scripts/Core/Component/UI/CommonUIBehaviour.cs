using System.Collections;
using System.Collections.Generic;
using Core.Component.Player;
using TMPro;
using UnityEngine;

namespace Core.Component.UI
{
    public class CommonUIBehaviour : MonoBehaviour
    {
        public static CommonUIBehaviour Instance { get; private set; }
        
        private TMP_Text m_NotificationText;
        private TMP_Text m_NameText;
        private TMP_Text m_DialogText;
        private TMP_Text m_DragText;
        private TMP_Text m_InspectText;
        private TMP_Text m_ObtainText;
        private TMP_Text m_UseText;
        
        private Queue<string> m_Notifications;
        private bool m_IsNotifying;

        private Queue<string> m_Dialog;
        private bool m_IsTalking;

        private void Awake()
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
            m_NotificationText = GameObject.Find("NotificationText").GetComponent<TMP_Text>();
            m_NameText = GameObject.Find("NameText").GetComponent<TMP_Text>();
            m_DialogText = GameObject.Find("DialogText").GetComponent<TMP_Text>();
            m_DragText = GameObject.Find("DragText").GetComponent<TMP_Text>();
            m_InspectText = GameObject.Find("InspectText").GetComponent<TMP_Text>();
            m_UseText = GameObject.Find("UseText").GetComponent<TMP_Text>();
            m_ObtainText = GameObject.Find("ObtainText").GetComponent<TMP_Text>();
            
            m_Notifications = new Queue<string>();
            m_IsNotifying = false;

            m_Dialog = new Queue<string>();
            m_IsTalking = false;
        }
        
        public void ToggleObtainText(bool on)
        {
            var text = on ? $"Obtain ({Controls.Obtain.ToString()})" : string.Empty;
            m_ObtainText.text = text;
        }

        public void ToggleInspectText(bool on)
        {
            var text = on ? $"Inspect ({Controls.Inspect.ToString()})" : string.Empty;
            m_InspectText.text = text;
        }

        public void ToggleUseText(bool on)
        {
            var text = on ? $"Use ({Controls.Use.ToString()})" : string.Empty;
            m_UseText.text = text;
        }

        public void ToggleDragText(bool on)
        {
            var text = on ? $"Drag ({Controls.Drag.ToString()})" : string.Empty;
            m_DragText.text = text;
        }
        
        public void ShowNameText(string n)
        {
            m_NameText.text = n;
        }

        public void HideNameText()
        {
            m_NameText.text = string.Empty;
        }

        public void EnqueueDialog(string dialog)
        {
            m_Dialog.Enqueue(dialog);

            if (!m_IsTalking)
            {
                StartCoroutine(DialogCoroutine());
            }
        }

        private IEnumerator DialogCoroutine()
        {
            m_IsTalking = true;

            while (m_Dialog.Count != 0)
            {
                var dialog = m_Dialog.Dequeue();
                m_DialogText.text = dialog;

                yield return new WaitForSeconds(2f);

                m_DialogText.text = string.Empty;

                yield return new WaitForSeconds(0.5f);
            }

            m_IsTalking = false;
        }

        public void EnqueueNotification(string notification)
        {
            m_Notifications.Enqueue(notification);

            if (!m_IsNotifying)
            {
                StartCoroutine(NotificationsCoroutine());
            }
        }

        private IEnumerator NotificationsCoroutine()
        {
            m_IsNotifying = true;

            while (m_Notifications.Count != 0)
            {
                var notification = m_Notifications.Dequeue();
                m_NotificationText.text = notification;

                yield return new WaitForSeconds(1f);

                m_NotificationText.text = string.Empty;

                yield return new WaitForSeconds(0.5f);
            }

            m_IsNotifying = false;
        }
    }
}