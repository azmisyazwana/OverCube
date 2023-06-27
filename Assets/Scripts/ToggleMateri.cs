using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class ToggleMateri : MonoBehaviour
{

    [SerializeField] private List<UnsurKubus> unsurKubusList;
    [SerializeField] private Material selectedMaterial;
    [SerializeField] private Material unselectedMaterial;

    [SerializeField] private Toggle toggle;

    public static event EventHandler OnToggleMateriClick;
    public static event EventHandler OnToggleHideMateriClick;



    public void ChangeColor(){
        OnToggleMateriClick?.Invoke(this, EventArgs.Empty);
        if(toggle.isOn){
            SetMaterial(selectedMaterial);
        }else{
            SetMaterial(unselectedMaterial);
        }
    }

    private void SetMaterial(Material material){
        foreach(UnsurKubus unsurKubus in unsurKubusList){                
            unsurKubus.GetComponent<MeshRenderer>().material = material;
        }
    }

    public void SetActiveUnsur(){
        OnToggleHideMateriClick?.Invoke(this, EventArgs.Empty);
        gameObject.SetActive(!gameObject.activeSelf);
    }
}
