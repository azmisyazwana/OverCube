using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class HideMenuMateriUI : MonoBehaviour
{
    public static event EventHandler OnHideMenu;

    [SerializeField] private List<GameObject> gameObjectList;
    [SerializeField] private GameObject gameObjectContainer;
    [SerializeField] private float heightHide;

    private float initialHeight;
    private float newBottom = 0;


    public void HideManager()
    {

        OnHideMenu?.Invoke(this, EventArgs.Empty);

        RectTransform rectTransform = gameObjectContainer.GetComponent<RectTransform>();

        // Get the height of the RectTransform
        float height = rectTransform.rect.height;

        // Calculate the new bottom position based on the toggle state
        if (newBottom != heightHide)
        {
            // Toggle is currently active, so hide the menu
            newBottom = heightHide;
        }
        else
        {
            // Toggle is currently inactive, so show the menu
            newBottom = 0;
        }

        // Update the bottom and top positions
        rectTransform.offsetMin = new Vector2(rectTransform.offsetMin.x, newBottom);

        // Toggle the active state of the game objects
        foreach (GameObject gameObject in gameObjectList)
        {
            gameObject.SetActive(!gameObject.activeSelf);
        }
    }
}
