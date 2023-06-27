using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundMateriManager : MonoBehaviour
{
    private const string PLAYER_PREFS_SOUND_EFFECTS_VOLUME = "SoundEffectsVolume";

    public static SoundMateriManager Instance { get; private set; }

    [SerializeField] private AudioClipRefsSO audioClipRefsSO;

    private float volume = 1f;

    private void Awake() {
        Instance = this;

        volume = PlayerPrefs.GetFloat(PLAYER_PREFS_SOUND_EFFECTS_VOLUME, 1f);
    }

    private void Start() {
        Selection.Instance.OnUnsurClicked += Selection_OnUnsurClicked;
        Selection.Instance.OnUnsurUnclicked += Selection_OnUnsurUnclicked;
        ToggleMateri.OnToggleMateriClick += ToggleMateri_OnToggleMateriClick;
        HideMenuMateriUI.OnHideMenu += HideMenuMateriUI_OnHideMenu;
        KalkulatorKubus.OnCalculateButtonPress += KalkulatorKubus_OnCalculateButtonPress;
        ToggleMateri.OnToggleHideMateriClick += ToggleMateri_OnToggleHideMateriClick;
    }

    private void Selection_OnUnsurClicked(object sender, System.EventArgs e){
        Selection selection = sender as Selection;
        PlaySound(audioClipRefsSO.selectObject, Camera.main.transform.position);
    }

    private void Selection_OnUnsurUnclicked(object sender, System.EventArgs e){
        Selection selection = sender as Selection;
        PlaySound(audioClipRefsSO.unselectObject, selection.transform.position);
    }

    private void ToggleMateri_OnToggleMateriClick(object sender, System.EventArgs e){
        ToggleMateri toggleMateri = sender as ToggleMateri;
        PlaySound(audioClipRefsSO.toggle, toggleMateri.transform.position);
    }

    private void HideMenuMateriUI_OnHideMenu(object sender, System.EventArgs e){
        HideMenuMateriUI hideMenuMateriUI = sender as HideMenuMateriUI;
        PlaySound(audioClipRefsSO.button, Camera.main.transform.position);
    }

    private void KalkulatorKubus_OnCalculateButtonPress(object sender, System.EventArgs e){
        KalkulatorKubus kalkulatorKubus = sender as KalkulatorKubus;
        PlaySound(audioClipRefsSO.button, Camera.main.transform.position);
    }

    private void ToggleMateri_OnToggleHideMateriClick(object sender, System.EventArgs e){
        ToggleMateri toggleMateri = sender as ToggleMateri;
        PlaySound(audioClipRefsSO.button, toggleMateri.transform.position);
    }


    // private void BaseCounter_OnAnyObjectPlacedHere(object sender, System.EventArgs e){
    //     BaseCounter baseCounter = sender as BaseCounter;
    //     PlaySound(audioClipRefsSO.objectDrop, baseCounter.transform.position);
    // }

    // private void DeliveryManager_OnRecipeSuccess(object sender, System.EventArgs e){
    //     DeliveryCounter deliveryCounter = DeliveryCounter.Instance;
    //     PlaySound(audioClipRefsSO.deliverySuccess, deliveryCounter.transform.position);
    // }

    private void PlaySound(AudioClip[] audioClipArray, Vector3 position, float volume = 1f){
        PlaySound(audioClipArray[Random.Range(0, audioClipArray.Length)], position, volume);
    }
    private void PlaySound(AudioClip audioClip, Vector3 position, float volumeMultiplier = 1f){
        AudioSource.PlayClipAtPoint(audioClip, position, volumeMultiplier * volume);
    }

    public void ChangeVolume(){
        volume += .1f;
        if(volume > 1f){
            volume = 0f;
        }

        PlayerPrefs.SetFloat(PLAYER_PREFS_SOUND_EFFECTS_VOLUME, volume);
        PlayerPrefs.Save();
    }

    public float GetVolume(){
        return volume;
    }
}
