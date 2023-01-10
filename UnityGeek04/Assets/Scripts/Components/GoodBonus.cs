using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Geek
{
    public class GoodBonus : Bonus
    {
        [SerializeField] private int _healValue;
        [SerializeField] private int _addSpeed;


        public override void Awake()
        {
            base.Awake();
        }

        public override void Update()
        {
            Fly();
        }
        protected override void Interaction(Player player)
        {
            Debug.Log("�������� ������� �������� ������");
            playSong();
            // ������ ������ � Player ���, ������� �������.
            player.AddHealth(_healValue); 
            player.AddSize(0.9f);
            player.AddSpeed(10.0f);
            player.ChangeColorForDamage();
            IsInteractable = false;
        }

        public void playSong()
        {
            a.clip = sound[0];
            a.Play();
        }

        // ����� �������� ����� - ����
        public override void Fly()
        {
            // ��������� �������� ������ ����� ����
            t = t + Time.deltaTime;
            Offset = Amp * Mathf.Sin(t * Freg);
            transform.position = StartPos + new Vector3(0, Offset, 0);
        }

        public override void Rotate()
        {

        }
    }
}
