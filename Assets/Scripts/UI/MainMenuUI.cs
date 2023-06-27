using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuUI : MonoBehaviour
{
    [SerializeField] private Button gameButton;
    [SerializeField] private Button materiButton;
    [SerializeField] private Button quitButton;

    private void Awake() {
        gameButton.onClick.AddListener(() => {
            Loader.Load(Loader.Scene.GameScene);
        });
        materiButton.onClick.AddListener(() => {
            Loader.Load(Loader.Scene.MateriScene);
        });
        quitButton.onClick.AddListener(() => {
            Application.Quit();
        });

        Time.timeScale = 1f;
    }
}
