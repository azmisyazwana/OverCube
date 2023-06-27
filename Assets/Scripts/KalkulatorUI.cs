using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KalkulatorUI : MonoBehaviour
{
    private const string JARING = "Jaring";
    private const string BANGUN_RUANG = "BangunRuang";

    private string currentJenis;

    private void Start() {
        PilihObjekUI.Instance.OnGameObjectChanged += PilihObjekUI_OnGameObjectChanged;

        currentJenis = PilihObjekUI.Instance.GetCurrentJenisGameObject();
    }

    private void PilihObjekUI_OnGameObjectChanged(object sender, System.EventArgs e){
        currentJenis = PilihObjekUI.Instance.GetCurrentJenisGameObject();

        if(currentJenis == JARING){
            gameObject.SetActive(false);
        }else{
            gameObject.SetActive(true);
        }
    }
}
