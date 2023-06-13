using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class DeliveryManagerSingleUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI recipeNameText;
    [SerializeField] private Transform iconContainer;
    [SerializeField] private Transform iconTemplate;

    private void Awake() {
        iconTemplate.gameObject.SetActive(false);

        Debug.Log("TES");
    }

    public void SetRecipeSO(RecipeSO recipeSO){
        recipeNameText.text = recipeSO.recipeName;
        Debug.Log("TES 2");

        foreach (Transform child in iconContainer){
            if(child == iconTemplate) continue;
            Destroy(child.gameObject);
        }
                Debug.Log("TES 3");

                            Debug.Log(recipeSO.kitchenObjectSOList);

        foreach (KitchenObjectSO kitchenObjectSO in recipeSO.kitchenObjectSOList){

            Transform iconTransform = Instantiate(iconTemplate, iconContainer);
            iconTransform.gameObject.SetActive(true);
            iconTransform.GetComponent<Image>().sprite = kitchenObjectSO.sprite;
        }
    }
}
