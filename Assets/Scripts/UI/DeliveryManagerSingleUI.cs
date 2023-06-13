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

    }

    public void SetRecipeSO(RecipeSO recipeSO){
        recipeNameText.text = recipeSO.recipeName.Replace("[n]", "\n");;

        foreach (Transform child in iconContainer){
            if(child == iconTemplate) continue;
            Destroy(child.gameObject);
        }

        Debug.Log(recipeSO.kitchenObjectSOList);

        foreach (KitchenObjectSO kitchenObjectSO in recipeSO.kitchenObjectSOList){
            Transform iconTransform = Instantiate(iconTemplate, iconContainer);

            if(recipeSO.isTextOnly){
                iconTransform.gameObject.SetActive(false);
            }else{
                iconTransform.gameObject.SetActive(true);
                iconTransform.GetComponent<Image>().sprite = kitchenObjectSO.sprite;
            }
        }
    }
}
