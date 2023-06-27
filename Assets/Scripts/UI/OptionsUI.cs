using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class OptionsUI : MonoBehaviour
{
    public static OptionsUI Instance { get; private set; }


    [SerializeField] private Button soundEffectsButton;
    [SerializeField] private Button musicButton;
    [SerializeField] private Button closeButton;
    [SerializeField] private TextMeshProUGUI soundEffectsText;
    [SerializeField] private TextMeshProUGUI musicText;
    [SerializeField] private Loader.Scene scene;


    private void Awake()
    {
        Instance = this;

        if (scene == Loader.Scene.GameScene)
        {
            soundEffectsButton.onClick.AddListener(() =>
            {
                SoundManager.Instance.ChangeVolume();
                UpdateVisual();
            });
        }
        else if (scene == Loader.Scene.MateriScene)
        {
            soundEffectsButton.onClick.AddListener(() =>
            {
                SoundMateriManager.Instance.ChangeVolume();
                UpdateVisual();
            });
        }

        musicButton.onClick.AddListener(() =>
        {
            MusicManager.Instance.ChangeVolume();
            UpdateVisual();
        });

        closeButton.onClick.AddListener(() =>
        {
            Hide();
        });
    }

    private void Start()
    {

        if (scene == Loader.Scene.GameScene)
        {
            KitchenGameManager.Instance.OnGameUnpaused += KitchenGameManager_OnGameUnpaused;
        }else if (scene == Loader.Scene.MateriScene){
            MateriManager.Instance.OnMateriUnpaused  += MateriManager_OnMateriUnpaused;
        }


        UpdateVisual();

        Hide();
    }

    private void KitchenGameManager_OnGameUnpaused(object sender, System.EventArgs e)
    {
        Hide();
    }

    private void MateriManager_OnMateriUnpaused(object sender, System.EventArgs e)
    {
        Hide();
    }

    private void UpdateVisual()
    {
        if(scene == Loader.Scene.GameScene){
            soundEffectsText.text = "Sound Effects: " + Mathf.Round(SoundManager.Instance.GetVolume() * 10f);
        }else if (scene == Loader.Scene.MateriScene){
            soundEffectsText.text = "Sound Effects: " + Mathf.Round(SoundMateriManager.Instance.GetVolume() * 10f);
        }
        musicText.text = "Music: " + Mathf.Round(MusicManager.Instance.GetVolume() * 10f);
    }

    public void Show()
    {
        gameObject.SetActive(true);
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }
}
