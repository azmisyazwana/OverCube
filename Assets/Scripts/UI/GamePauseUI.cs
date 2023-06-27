using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GamePauseUI : MonoBehaviour
{

    [SerializeField] private Button resumeButton;
    [SerializeField] private Button mainMenuButton;
    [SerializeField] private Button optionsButton;
    [SerializeField] private Loader.Scene scene;

    private void Awake() {

        if(scene == Loader.Scene.GameScene){
            resumeButton.onClick.AddListener(() => {
                KitchenGameManager.Instance.TogglePauseGame();
            }); 
        }else if (scene == Loader.Scene.MateriScene){
            resumeButton.onClick.AddListener(() => {
                MateriManager.Instance.TogglePauseMateri();
            }); 
        }

               
        mainMenuButton.onClick.AddListener(() => {
            Loader.Load(Loader.Scene.MainMenuScene);
        });
        optionsButton.onClick.AddListener(() => {
            OptionsUI.Instance.Show();
        });
    }
   

    private void Start() {
        if(scene == Loader.Scene.GameScene){
            KitchenGameManager.Instance.OnGamePaused += KitchenGameManager_OnGamePaused;
            KitchenGameManager.Instance.OnGameUnpaused += KitchenGameManager_OnGameUnpaused;
        }else if (scene == Loader.Scene.MateriScene){
            MateriManager.Instance.OnMateriPaused += MateriManager_OnMateriPaused;
            MateriManager.Instance.OnMateriUnpaused += MateriManager_OnMateriUnpaused;
        }
        Hide();        
    }

    private void KitchenGameManager_OnGamePaused(object sender, System.EventArgs e){
        Show();
    }

    private void KitchenGameManager_OnGameUnpaused(object sender, System.EventArgs e){
        Hide();
    }

    private void MateriManager_OnMateriPaused(object sender, System.EventArgs e){
        Show();
    }

    private void MateriManager_OnMateriUnpaused(object sender, System.EventArgs e){
        Hide();
    }

    private void Show(){
        gameObject.SetActive(true);
    }   
    private void Hide(){
        gameObject.SetActive(false);
    } 
}
