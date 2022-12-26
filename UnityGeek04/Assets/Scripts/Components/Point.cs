using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Geek
{
    public abstract class Point : MonoBehaviour, IExecute
    {

        public AudioClip[] sound;
        public AudioSource a;

        private bool _isInteractable;
        protected Color _color;
        private Renderer _renderer;
        private Collider _collider;
        public GameObject levelPanel;

        public bool IsInteractable
        {
            get => _isInteractable;

            set
            {
                _isInteractable = value;
                _renderer.enabled = value;
                _collider.enabled = value;
            }
        }

        public virtual void Awake()
        {
            if (!TryGetComponent<Renderer>(out _renderer))
            {
                Debug.Log("Не найден компонент Renderer");
            }

            if (!TryGetComponent<Collider>(out _collider))
            {
                Debug.Log("Не найден компонент Collider");
            }

            levelPanel.SetActive(false);

            IsInteractable = true;
           // _color = Random.ColorHSV();
           // _renderer.sharedMaterial.color = _color;
        }

        private void OnTriggerEnter(Collider other)
        {
            // проверка, если в компонентах есть Player то playerComponent = true
            var playerComponent = other.GetComponent<Player>();

            if (playerComponent)
            {
                Interaction(playerComponent);
                levelPanel.SetActive(true);
            }
        }

        protected abstract void Interaction(Player player);

        public abstract void Update();

    }

}
