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
            // init bonus point, material, height fly 
        }

        public override void Update()
        {
            // fly
            // flick
        }
        protected override void Interaction(Player player)
        {
            Debug.Log("�������� ������� �������� ������");
            playSong();
            // ������ ������ � Player ���, ������� �������.
            player.AddHealth(_healValue); 
            player.AddSize(0.9f);
            player.AddSpeed(10.0f);
            IsInteractable = false;
        }

        public void playSong()
        {
            a.clip = sound[0];
            a.Play();
        }

    }
}
