using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Geek
{
    public class FinishPoint : Point
    {

        // ���������� �������
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
            Debug.Log("�������� �������, �������� ������");
            // ��������� ����� �������
            LevelLoader.LoadLevel(_currentLevelIndex + 1);
            playSong();
            // ������ ������ � Player ���, ������� �������.
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
