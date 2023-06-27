using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu()]
public class ButtonPilihObjectSO : ScriptableObject
{
    public enum Jenis{
        Jaring,
        BangunRuang,
    }


    public Jenis jenis;
    public string nama;
    public GameObject objek;
    public Sprite icon;
}
