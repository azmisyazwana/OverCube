using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class KalkulatorKubus : MonoBehaviour
{
    [SerializeField] private TMP_InputField sideLengthInputField;
    [SerializeField] private TMP_Dropdown unitsDropdown;
    [SerializeField] private TextMeshProUGUI formulaText;
    [SerializeField] private Button calculateButton;

    public static event EventHandler OnCalculateButtonPress;

    private float sideLength;

    // private void Start()
    // {
    //     calculateButton.onClick.AddListener(CalculateFormula);
    // }

    public void KalkulatorLuasPermukaan()
    {
        OnCalculateButtonPress?.Invoke(this, EventArgs.Empty);

        string rumusLuasKubus = "L = 6 x s x s = 6 x " + GetPangkat("s", 2);
        formulaText.alignment = TextAlignmentOptions.Left;

        if (float.TryParse(sideLengthInputField.text, out sideLength))
        {
            float luasPermukaan = 6 * sideLength * sideLength;

            string unit = unitsDropdown.options[unitsDropdown.value].text;

            string sisi = sideLength + " " + unit;

            string hasilRow2 = sideLength * sideLength + " " + GetPangkat(unit, 2);
            
            formulaText.text = rumusLuasKubus + "\n";
            formulaText.text += "L = 6 x (" + sisi + " x " + sisi + ")\n";
            formulaText.text += "L = 6 x " + hasilRow2 + "\n";           
            formulaText.text += "L = " + luasPermukaan + " " + GetPangkat(unit, 2);

        }
        else
        {
            formulaText.text = "Invalid side length!";
        }
    }

    public void KalkulatorVolume()
    {
        OnCalculateButtonPress?.Invoke(this, EventArgs.Empty);
        
        string rumusVolume = "V = s x s x s = " + GetPangkat("s", 3);
        formulaText.alignment = TextAlignmentOptions.Left;

        if (float.TryParse(sideLengthInputField.text, out sideLength))
        {
            float volume = sideLength * sideLength * sideLength;

            string unit = unitsDropdown.options[unitsDropdown.value].text;

            string sisi = sideLength + " " + unit;

            string hasilRow2 = sideLength * sideLength + " " + GetPangkat(unit, 2);
            
            formulaText.text = rumusVolume + "\n";
            formulaText.text += "V = " + sisi + " x " + sisi + " x " + sisi + "\n";
            formulaText.text += "V = " + GetPangkat(sideLength, 3) +  " " + GetPangkat(unit, 3) + "\n";          
            formulaText.text += "V = " + volume + " " + GetPangkat(unit, 3);

        }
        else
        {
            formulaText.text = "Invalid side length!";
        }
    }

    private string GetPangkat<T>( T satuan, float pangkat){
        switch (pangkat){
            case 2:
                return $"{satuan}{'\u00B2'}";
            case 3:
                return $"{satuan}{'\u00B3'}";
            default:
                return "";
        }
    }
}
