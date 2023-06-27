using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;


public class PilihObjekUI : MonoBehaviour
{

    public static PilihObjekUI Instance { get; private set; }
    private GameObject currentGameObject;
    private string currentJenisGameObject;

    [SerializeField] private List<ButtonPilihObjek> buttonPilihObjekList;

    public event EventHandler OnGameObjectChanged;


    private void Awake()
    {
        Instance = this;

        currentGameObject = buttonPilihObjekList[0].GetObjek();
        currentJenisGameObject = buttonPilihObjekList[0].GetJenis();

        AddListenerToButtonPilihObject();
    }

    private void AddListenerToButtonPilihObject(){
        foreach(ButtonPilihObjek buttonPilihObjek in buttonPilihObjekList ){
            buttonPilihObjek.GetButton().onClick.AddListener(() => {
                SetActiveObject(buttonPilihObjek);

                OnGameObjectChanged?.Invoke(buttonPilihObjek.GetObjek(), EventArgs.Empty);
            });
        }
    }

    public void SetActiveObject(ButtonPilihObjek buttonPilihObjek)
    {
        currentGameObject.SetActive(false);
        currentGameObject = buttonPilihObjek.GetObjek();
        currentJenisGameObject = buttonPilihObjek.GetJenis();
        buttonPilihObjek.GetObjek().SetActive(true);
    }

    public string GetCurrentGameObject(){
        return currentGameObject.name;
    }

    public string GetCurrentJenisGameObject(){
        return currentJenisGameObject;
    }

}

