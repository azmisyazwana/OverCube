using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnsurKubus : MonoBehaviour
{
    [SerializeField] private UnsurKubusSO unsurKubusSO;

    public static UnsurKubus Instance { get; private set; }


    public string GetNamaUnsurKubusSO(){
        return unsurKubusSO.namaUnsur;
    }

    public string GetTitikUnsurKubusSO(){
        return unsurKubusSO.namaTitik;
    }

    public string GetCompleteNameUnsurKubus(){
        return unsurKubusSO.namaUnsur + " " + unsurKubusSO.namaTitik;
    }

}
