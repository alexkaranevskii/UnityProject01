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
            Debug.Log("Сработал триггер плохого бонуса");
            playSong();
            player.Damage(_damage); // такого метода у Player нет, поэтому создаем.
            player.SubtractSize(0.35f);
            IsInteractable = false;
        }

        public void playSong()
        {
            a.clip = sound[0];
            a.Play();
        }
    }

}
