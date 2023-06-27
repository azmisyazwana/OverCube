using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialKubusMateri : MonoBehaviour
{
    [SerializeField] private Material originalColor;
    [SerializeField] private Material selectedColor;

    public void ApplyOriginalColor(){
        Renderer renderer = gameObject.GetComponent<Renderer>();
        renderer.material = originalColor;
    }

    public void ApplySelectedColor(){
        Renderer renderer = gameObject.GetComponent<Renderer>();
        renderer.material = selectedColor;
    }
}
