using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


namespace Geek
{
    public class MainMenu : MonoBehaviour
    {
      //  LevelLoader levelLoader;

        public void Play(int index)
        {
            Debug.Log("Загрузка игры");
            LevelLoader.LoadLevel(index + 1);
           // SceneManager.LoadScene(index);
        }

        public void LoadState()
        {
            Debug.Log("Загрузка состояния");
        }

        public void SaveState()
        {
            Debug.Log("Сохранение состояния");
        }

        public void Exit()
        {
            Debug.Log("Выход из игры");
            Application.Quit();
        }

    }
}
