using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Geek
{
    public class FinishPoint : Point
    {

        // переменна€ уровень
        private int _currentLevelIndex => LevelLoader.CurrentSceneIndex;

        public override void Awake()
        {
            base.Awake();
        }
        public override void Update()
        {
            
        }
        protected override void Interaction(Player player)
        {
            Debug.Log("Ћабиринт пройден, получите валюту");
            // «агружаем новый уровень
            LevelLoader.LoadLevel(_currentLevelIndex + 1);
            playSong();
            // такого метода у Player нет, поэтому создаем.
             // player.AddHealth(_healValue);
            //IsInteractable = false;
        }

        public void playSong()
        {
            a.clip = sound[0];
            a.Play();
        }
    }
}
