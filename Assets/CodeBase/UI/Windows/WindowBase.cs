using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace CodeBase.UI
{
    public abstract class WindowBase : MonoBehaviour
    {
        public Button CloseButton;

        private void Awake()
        {
            OnAwake();
        }

        protected virtual void OnAwake()
        {
            CloseButton.onClick.AddListener(() => Destroy(gameObject));
        }
    }
}