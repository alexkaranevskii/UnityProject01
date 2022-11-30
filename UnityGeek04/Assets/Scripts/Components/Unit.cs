using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Geek { 

    public abstract class Unit : MonoBehaviour
    {
        public Transform _transform;
        public Rigidbody _rb;

        private float speed = 5f;
        private int _health;
        private bool _isDead;

        public virtual void Awake()
        {

        }
       
    }
}
