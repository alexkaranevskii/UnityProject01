using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Geek { 

    public abstract class Unit : MonoBehaviour
    {
        public Transform _transform;
        public Rigidbody _rb;

        private float _speed = 5f;
        private int _health;
        private bool _isDead;

        public int Health
        {
            get
            {
                return _health;
            }

            set
            {
                if (value <= 100  && value >= 0)
                {
                    _health = value;
                }
                else
                {
                    _health = 100;
                    Debug.Log("Неправильное число");
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
        }

        public abstract void Move(float x, float y, float z); 
       
    }
}
