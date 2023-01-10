using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;


namespace Geek
{
    public class LevelLoader : MonoBehaviour, IExecute
    {
        public static int CurrentSceneIndex;
        private static LevelLoader _instanse;

        // Событие - изменение уровня
        public event Action<int> LevelChanged;

        void Start()
        {
            if (_instanse == null)
            {
                _instanse = this;
                DontDestroyOnLoad(gameObject);
            }
        }
        public static void LoadLevel(int levelIndex)
        {
            CurrentSceneIndex = levelIndex;
            _instanse.StartCoroutine(WaitAndLoadScene(levelIndex));
            Debug.Log($"Текущий уровень {levelIndex}" );
        }



        private static IEnumerator WaitAndLoadScene(int levelIndex)
        {
            // создаем на текущей сцене пустой игровой объект
            var fadeObject = new GameObject("fade");

            //  var fadeComponent = fadeObject.AddComponent<Fading>();
            //  fadeComponent.fadeOutTexture = _instanse.FadeOutTexture;
            //   var waitTime = fadeComponent.BeginFade(-1) * 2f;

            var waitTime = 2f;

            yield return new WaitForSeconds(waitTime);
            SceneManager.LoadScene(levelIndex);
        }

        void IExecute.Update()
        {
           
            
        }
    }
}
