using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Geek { 
    public class UIititializer : MonoBehaviour
    {
        [SerializeField] private Player _player;
        [SerializeField] private CharacterStatsUI _statsUI;

        void Start()
        {
            _statsUI.Initialize(_player);
        }
    
    }
}
