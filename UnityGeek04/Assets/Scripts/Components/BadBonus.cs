using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Geek
{
    public class BadBonus : Bonus
    {
        public override void Awake()
        {
            base.Awake();
        }

        public override void Update()
        {

        }

        protected override void Interaction()
        {
            IsInteractable = false;
            Debug.Log("Сработал триггер");
        }
    }

}
