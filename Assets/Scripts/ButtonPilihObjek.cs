using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ButtonPilihObjek : MonoBehaviour
{
    [SerializeField] ButtonPilihObjectSO buttonPilihObjectSO;
    [SerializeField] Button button;
    [SerializeField] GameObject objek;

    private void Awake() {
        button.image.sprite = buttonPilihObjectSO.icon;
    }

    public string GetJenis(){
        return buttonPilihObjectSO.jenis.ToString();
    }

    public string GetNamaButton(){
        return buttonPilihObjectSO.nama;
    }

    public GameObject GetObjek(){
        return objek;
    }

    public Sprite GetIcon(){
        return buttonPilihObjectSO.icon;
    }

    public Button GetButton(){
        return button;
    }

    public delegate void MyFunctionDelegate();

    // public void EventListener(MyFunctionDelegate ButtonEventListener){
    //     button.onClick.AddListener(() => {
    //         ButtonEventListener();
    //         });
    // }

    // public void setGameObjek(GameObject gameObject){
    //     gameObject = GetObjek();
    // }

}
