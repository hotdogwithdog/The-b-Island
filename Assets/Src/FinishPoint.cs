using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Finish
{
    public class FinishPoint : MonoBehaviour
    {
        void Start()
        {
            SceneManager.sceneLoaded += OnSceneLoad;
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.tag == "Player")
            {
                SceneManager.LoadScene("MainMenu");
            }
        }

        public void OnSceneLoad(Scene scene, LoadSceneMode mode)
        {
            if (scene.name == "MainMenu")
                Menu.MenuManager.Instance.SetState(new Menu.States.Credits());
        }
    }
}

