using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

namespace Geek { 

    public abstract class Unit : MonoBehaviour
    {

        public const int MaxHealth = 100;
        public int score = 0;
        public Transform _transform;
        public Rigidbody _rb;
        private float _size;
        private string Name { get; set;}
        private Collider _collider;

        //private Renderer _renderer
        [SerializeField] public Renderer _fillTarget;
        [SerializeField] public Material matBlink;
        [SerializeField] public Material matDefault;


        [SerializeField] private float _speed = 5f;
        [SerializeField] private int _health;

        private bool _isDead;


        // Событие - изменение здоровья 
        public event Action<int> PlayerHealthChanged;

        public int Health
        {
            get
            {
                return _health;
            }

            set
            {
               // if (value <= 100 && value >= 0)
               // {
                    //_health = value;
                    _health = Mathf.Clamp(value ,0, 100);  // Устанваливаем порог health
                    PlayerHealthChanged?.Invoke(Health);
               // }
               
            }
        }


        public bool IsDead
        {
            get
            {
                return _isDead;
            }
            set
            {
                _isDead = value;
            }
        }

        public float Size
        {
            get
            {
                return _size;
            }

            set
            {
                if (value <= 2.0f && value >= 0.0f)
                {
                    _size = value;
                }
                else
                {
                    _size = 2.0f;
                    Debug.Log("Бонус использован напрасно, размер на максимуме");
                }
            }
        }


      //  private void Start()
     //   {
     //       _health = MaxHealth;
     //  }
        public float Speed { get => _speed; set => _speed = value; }

        public virtual void Awake()
        {
            if (!TryGetComponent<Transform>(out _transform))
            {
                Debug.Log("Не найден компонент Transform");
            }

            if (!TryGetComponent<Rigidbody>(out _rb))
            {
                Debug.Log("Не найден компонент Rigidbody");
            }

           //  matBlink = Resources.Load("PlayerBlink", typeof(Material)) as Material;
           //  matDefault = Resources.Load("PlayerDefault", typeof(Material)) as Material;

           // _fillTarget.material = matDefault;

             _health = MaxHealth;
             _isDead = false;
             Health = _health;
             Size = _size;
             IsDead = _isDead;
             Speed = _speed;
           
        }

     //   public abstract void ChangeMaterial(Material material);
    

        public abstract void Move(float x, float y, float z);

    }
}


