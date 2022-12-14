using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using System.Linq;


namespace Geek
{
    public class BadBonus : Bonus
    {
        [SerializeField] private int _damage;

        public override void Awake()
        {
            base.Awake();
            // init bonus point, material, height fly 
        }

        public override void Update()
        {
            // Get Damage
        }

        protected override void Interaction(Player player)
        {
            Debug.Log("�������� ������� ������� ������");
            player.Damage(_damage); // ������ ������ � Player ���, ������� �������.
            player.SubtractSize(0.35f);
            IsInteractable = false;
        }
    }

}
