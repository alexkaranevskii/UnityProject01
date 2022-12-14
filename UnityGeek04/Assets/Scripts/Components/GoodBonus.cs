using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Geek
{
    public class GoodBonus : Bonus
    {
        [SerializeField] private int _healValue;


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
            Debug.Log("Сработал триггер хорошего бонуса");
            player.AddHealth(_healValue); // такого метода у Player нет, поэтому создаем.
            player.AddSize(0.9f);
            IsInteractable = false;
        }

    }
}
