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
            Debug.Log("�������� ����");
            LevelLoader.LoadLevel(index + 1);
           // SceneManager.LoadScene(index);
        }

        public void LoadState()
        {
            Debug.Log("�������� ���������");
        }

        public void SaveState()
        {
            Debug.Log("���������� ���������");
        }

        public void Exit()
        {
            Debug.Log("����� �� ����");
            Application.Quit();
        }

    }
}
