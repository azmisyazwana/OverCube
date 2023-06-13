using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class DeliveryManager : MonoBehaviour
{
    public event EventHandler OnRecipeSpawned;
    public event EventHandler OnRecipeCompleted;
    public event EventHandler OnRecipeSuccess;
    public event EventHandler OnRecipeFailed;

    public static DeliveryManager Instance { get; private set; }

    [SerializeField] private RecipeListSO recipeListSO;


    private List<RecipeSO> waitingRecipeSOList;
    private float spawnRecipeTimer;
    private float spawnRecipeTimerMax = 0f;
    private int waitingRecipeMax = 1;
    private int successfulRecipesAmount;
    private List<RecipeSO> recipeListCopy;

    private void Awake() {
        Instance = this;


        waitingRecipeSOList = new List<RecipeSO>();

        recipeListCopy = new List<RecipeSO>(recipeListSO.recipeSOList);
    }

    private void Update() {
        spawnRecipeTimer -= Time.deltaTime;
        if(spawnRecipeTimer <= 0f){
            spawnRecipeTimer = spawnRecipeTimerMax;

            if(waitingRecipeSOList.Count < waitingRecipeMax){
                // 1 SOAL 1 KALI MUNCUL
                if(recipeListCopy.Count != 0){
                    RecipeSO waitingRecipeSO = recipeListCopy[UnityEngine.Random.Range(0, recipeListCopy.Count)];
                
                    recipeListCopy.Remove(waitingRecipeSO);

                    waitingRecipeSOList.Add(waitingRecipeSO);

                    OnRecipeSpawned?.Invoke(this, EventArgs.Empty);
                }
                
            }
            
        }
    }

    public void DeliverRecipe(PlateKitchenObject plateKitchenObject){
        for(int i = 0; i < waitingRecipeSOList.Count; i++){
            RecipeSO waitingRecipeSO = waitingRecipeSOList[i];
            

            

            if(waitingRecipeSO.kitchenObjectSOList.Count == plateKitchenObject.GetKitchenObjectSOList().Count){
                // Has the same number of ingredients
                bool plateContentMatchesRecipe = true;
                foreach(KitchenObjectSO recipeKitchenObjectSO in waitingRecipeSO.kitchenObjectSOList){
                    // Cycling through all ingredients in the Recipe
                    bool ingridientFound = false;
                    foreach(KitchenObjectSO plateKitchenObjectSO in plateKitchenObject.GetKitchenObjectSOList()){
                        Debug.Log(plateKitchenObjectSO);
                        // Cycling through all ingredients in the Plate
                        if(plateKitchenObjectSO == recipeKitchenObjectSO){
                            // Ingredient matches!
                            ingridientFound = true;
                            break;
                        }
                    }
                    if(!ingridientFound){
                        // This recipe ingredient was not found on the plate
                        plateContentMatchesRecipe = false;
                    }
                }
                if(plateContentMatchesRecipe){
                    // Player deliver the correct recipe
                    successfulRecipesAmount++;

                    waitingRecipeSOList.RemoveAt(i);

                    OnRecipeCompleted?.Invoke(this, EventArgs.Empty);
                    OnRecipeSuccess?.Invoke(this, EventArgs.Empty);
                    return;
                }
            }
        }
        // no matches found
        // player did not deliver a correct recipe
        OnRecipeFailed?.Invoke(this, EventArgs.Empty);

    }

///
    public void DeliverOnlyGeometry(KitchenObjectSO kitchenObjectSO){
        Debug.Log(kitchenObjectSO);
         for(int i = 0; i < waitingRecipeSOList.Count; i++){
            RecipeSO waitingRecipeSO = waitingRecipeSOList[i];

            

            if(waitingRecipeSO.kitchenObjectSOList.Count == 1){
                // Has the same number of ingredients
                bool plateContentMatchesRecipe = true;
                foreach(KitchenObjectSO recipeKitchenObjectSO in waitingRecipeSO.kitchenObjectSOList){
                    // Cycling through all ingredients in the Recipe
                    bool ingridientFound = false;
                    // foreach(KitchenObjectSO plateKitchenObjectSO in plateKitchenObject.GetKitchenObjectSOList()){
                    //     // Cycling through all ingredients in the Plate
                    //     if(plateKitchenObjectSO == recipeKitchenObjectSO){
                    //         // Ingredient matches!
                    //         ingridientFound = true;
                    //         break;
                    //     }
                    // }
                    if(kitchenObjectSO == recipeKitchenObjectSO){
                        ingridientFound = true;
                        break;
                    }
                    if(!ingridientFound){
                        // This recipe ingredient was not found on the plate
                        plateContentMatchesRecipe = false;
                    }
                }
                if(plateContentMatchesRecipe){
                    // Player deliver the correct recipe
                    successfulRecipesAmount++;

                    waitingRecipeSOList.RemoveAt(i);

                    OnRecipeCompleted?.Invoke(this, EventArgs.Empty);
                    OnRecipeSuccess?.Invoke(this, EventArgs.Empty);
                    return;
                }
            }
        }
        // no matches found
        // player did not deliver a correct recipe
        OnRecipeFailed?.Invoke(this, EventArgs.Empty);
    }
///
    public List<RecipeSO> GetWaitingRecipeSOList(){
        return waitingRecipeSOList;
    }

    public int GetSuccessfulRecipesAmount(){
        return successfulRecipesAmount;
    }

    public bool isQuestionEmpty(){
        return recipeListSO.recipeSOList.Count == successfulRecipesAmount;
    }

}
