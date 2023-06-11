using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeliveryCounter : BaseCounter
{
    public static DeliveryCounter Instance { get; private set; }

    private void Awake() {
        Instance = this;
    }

    public override void Interact(Player player)
    {
       
        if(player.HasKitchenObject()){
            
            if(player.GetKitchenObject().TryGetPlate(out PlateKitchenObject plateKitchenObject)){
                // Only Accept Plates
                DeliveryManager.Instance.DeliverRecipe(plateKitchenObject);
                
                player.GetKitchenObject().DestroySelf();
            }else{
                /// 
            
                // only accept 1 Geometry Object
                DeliveryManager.Instance.DeliverOnlyGeometry(player.GetKitchenObject().GetKitchenObjectSO());

                player.GetKitchenObject().DestroySelf();

                ///
            }
        }
    }
}
