using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using System;

public class Selection : MonoBehaviour
{

    public static Selection Instance { get; private set; }

    public event EventHandler OnUnsurClicked;
    public event EventHandler OnUnsurUnclicked;

    public Material highlightMaterial;
    public Material selectionMaterial;

    private Material originalMaterial;
    private Transform highlight;
    private Transform selection;
    private RaycastHit raycastHit;
    private UnsurKubus lastClickedUnsur;

    private void Awake() {
        Instance = this;
    }

    private void Update()
    {
        if (highlight != null)
        {
            highlight.GetComponent<MeshRenderer>().material = originalMaterial;
            highlight = null;
        }

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (!EventSystem.current.IsPointerOverGameObject() && Physics.Raycast(ray, out raycastHit))
        {
            highlight = raycastHit.transform;
            if (highlight.CompareTag("Selectable") && highlight != selection)
            {
                if (highlight.GetComponent<MeshRenderer>().material != highlightMaterial)
                {
                    originalMaterial = highlight.GetComponent<MeshRenderer>().material;
                    highlight.GetComponent<MeshRenderer>().material = highlightMaterial;
                }
            }
            else
            {
                highlight = null;
            }
        }

        if (Input.GetKey(KeyCode.Mouse0) && !EventSystem.current.IsPointerOverGameObject())
        {
            if (selection != null)
            {
                selection.GetComponent<MeshRenderer>().material = originalMaterial;
                selection = null;

            }

            if (!EventSystem.current.IsPointerOverGameObject() && Physics.Raycast(ray, out raycastHit))
            {
                selection = raycastHit.transform;
                if (selection.CompareTag("Selectable"))
                {
                    UnsurKubus unsurKubus = selection.GetComponent<UnsurKubus>();
                    selection.GetComponent<MeshRenderer>().material = selectionMaterial;
                    if (unsurKubus != lastClickedUnsur)
                    {
                        lastClickedUnsur = unsurKubus;
                        OnUnsurClicked?.Invoke(unsurKubus, EventArgs.Empty);
                    }
                }
                else
                {
                    selection = null;
                    OnUnsurUnclicked?.Invoke(this, EventArgs.Empty);

                }
            }
        }
    }

    public UnsurKubus GetUnsurKubus(){
        if(selection != null){
            UnsurKubus unsurKubus = selection.GetComponent<UnsurKubus>();
            return unsurKubus;
        }else{
            return null;
        }
    }
}
