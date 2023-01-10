using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Random = UnityEngine.Random;

namespace Geek{ 

    public abstract class Bonus : MonoBehaviour, IExecute, ITouch, IFly, IRotation
    {

        public float t = 0;       // ����� �� �������� ����� ��������� �����
        public float Amp = 0.20f; // ��������� �������� 
        public float Freg = 0.25f;    // ������� ���������
        public float Offset = 0;  // �����
        public Vector3 StartPos;  // ��������� ���������


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
                Debug.Log("�� ������ ��������� Renderer � ������ �� ������");
            }

            if (!TryGetComponent<Collider>(out _collider))
            {
                Debug.Log("�� ������ ��������� Collider � ������ �� ������");
            }

            IsInteractable = true;
            _color = Random.ColorHSV();
            _renderer.sharedMaterial.color = _color;
            StartPos = transform.position;   // ���������� �������
        }


        // ����� ������������, ��� ����� � ���� ������������� ���������� ������, ��������� ������� ������ ������������
        // ��� ����� �� ����������� ��� Collider other
        private void OnTriggerEnter(Collider other)
        {
            // ��������, ���� � ����������� ���� Player �� playerComponent = true
            var playerComponent = other.GetComponent<Player>(); 

            if (playerComponent)
            {
                Interaction(playerComponent);
            }
        }
        // Bonus � ��� ������������ �� ������, �� �������� ��� Player
        // � �������� ��������� � ����� ����������� Player player
        // ����� � ����������� �� ������ ��������� ��������� ������
        protected abstract void Interaction(Player player);
         
        public abstract void Update();

        // ����� �������� ����� - ����
        public abstract void Fly();

        // ����� ��������
        public abstract void Rotate();
    }
}
