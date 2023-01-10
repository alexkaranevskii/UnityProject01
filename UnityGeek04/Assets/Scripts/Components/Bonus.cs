using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Random = UnityEngine.Random;

namespace Geek{ 

    public abstract class Bonus : MonoBehaviour, IExecute, ITouch, IFly, IRotation
    {

        public float t = 0;       // Время от которого будет считаться синус
        public float Amp = 0.20f; // Амплитуда движения 
        public float Freg = 0.25f;    // Частота колебаний
        public float Offset = 0;  // Сдвиг
        public Vector3 StartPos;  // Начальное положение


        public AudioClip[] sound;
        public AudioSource a;

        private bool _isInteractable;
        protected Color _color;
        private Renderer _renderer;
        private Collider _collider;


        Player player;

        public float _heightFly;  

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
                Debug.Log("Не найден компонент Renderer у какого то бонуса");
            }

            if (!TryGetComponent<Collider>(out _collider))
            {
                Debug.Log("Не найден компонент Collider у какого то бонуса");
            }

            IsInteractable = true;
            _color = Random.ColorHSV();
            _renderer.sharedMaterial.color = _color;
            StartPos = transform.position;   // Запоминаем позицию
        }


        // Метод определяющий, кто попал в зону взаимодейстия коллайдера Бонуса, проверяет наличие других коллайдерорв
        // для этого мы прокидываем ему Collider other
        private void OnTriggerEnter(Collider other)
        {
            // проверка, если в компонентах есть Player то playerComponent = true
            var playerComponent = other.GetComponent<Player>(); 

            if (playerComponent)
            {
                Interaction(playerComponent);
            }
        }
        // Bonus у нас воздействует на игрока, мы передаем ему Player
        // в качестве аргумента в метод прокидываем Player player
        // далее в наследниках мы должеы соблюдать сигнатуру метода
        protected abstract void Interaction(Player player);
         
        public abstract void Update();

        // Метод движения вверх - вниз
        public abstract void Fly();

        // Метод вращения
        public abstract void Rotate();
    }
}
