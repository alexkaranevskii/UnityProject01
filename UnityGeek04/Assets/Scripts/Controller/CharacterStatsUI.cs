using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


namespace Geek
{
    public class CharacterStatsUI : MonoBehaviour {

        [SerializeField] private Slider _slider;
        [SerializeField] private TextMeshProUGUI _healthText;
       
        private Player _player;
        private int _playerMaxHealth; 
       
        public void Initialize(Player player)
        {
            _player = player;
            player.PlayerHealthChanged += OnHealthChanged;

        }

        private void OnDisable(Player player)
        {
           _player = player;
           player.PlayerHealthChanged -= OnHealthChanged;
        }

        private void OnHealthChanged(int playerHealth)
        {
            var normalisedValue = playerHealth / Player.MaxHealth;
            _healthText.text = $"Health: {playerHealth}/{Player.MaxHealth}";

            StartCoroutine(SetSliderValueCoroutine(normalisedValue, 0.5f));
        }


        // ????????? ????? ??? ???????? ???????? ? ???????
        private IEnumerator SetSliderValueCoroutine(float toValue, float changeTime)
        {
            var startTime = Time.time;
            var endTime = startTime + changeTime;
            var startValue = _slider.value;
            var wait = new WaitForEndOfFrame();

            while (Time.time < endTime)
            {
                var lerp = (Time.time - startTime) / changeTime;
                _slider.value = Mathf.Lerp(startValue, toValue, lerp);

                yield return wait; 
            }
        }

    }
}
