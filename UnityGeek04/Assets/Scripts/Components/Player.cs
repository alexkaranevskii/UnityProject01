using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Geek {
    public class Player : Unit
    {
        public override void Awake()
        {
            base.Awake();
        }
        public bool Touch()
        {
            return false;
        }

        public override void Move(float x, float y, float z)
        {
            if (_rb)
            {
                _rb.AddForce(new Vector3(x, y, z));
            }
        }

        // Метод получения урона
        public void Damage(int damage)
        {
            Debug.Log("Получили по носу");
            Health -= damage;
        }

        // Метод увеличения здоровья
        public void AddHealth(int _healValue)
        {
            Debug.Log("Получили бонус");
            Health += 10;
        }

        // Метод увеличения размера Player_а
        public void AddSize(float _addSize)
        {
            var scale = transform.localScale;
            scale.z = _addSize;
            scale.y = _addSize;
            scale.x = _addSize;
            transform.localScale = scale;
        }

        // Метод увеличения скорости Player_а
        public void AddSpeed(float _addSpeed)
        {
            var scale = transform.localScale;
            Speed = _addSpeed;

            transform.localScale = scale;
        }

        // Метод уменьшения размера Player_а
        public void SubtractSize(float _subtractSize)
        {
            var scale = transform.localScale;
            scale.z = _subtractSize;
            scale.y = _subtractSize;
            scale.x = _subtractSize;
            transform.localScale = scale;
        }

    }
}
