using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Geek { 

    public abstract class Unit : MonoBehaviour
    {

        public Transform _transform;
        public Rigidbody _rb;
        private float _size;

        private float _speed = 5f;
        [SerializeField] private int _health;
        private bool _isDead;

        public int Health
        {
            get
            {
                return _health;
            }

            set
            {
                if (value <= 100 && value >= 0)
                {
                    _health = value;
                }
                else
                    if (value <= 0)
                {
                    _isDead = true;
                }
                else
                {
                    _health = 100;
                    Debug.Log("Вонус использован напрасно, жизнь на максимуме");
                }
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
             _isDead = false;

             Health = _health;
             Size = _size;
             IsDead = _isDead; 
        }

        public abstract void Move(float x, float y, float z);


    }
}
