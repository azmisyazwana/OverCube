using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContainerCounter : BaseCounter
{
    [SerializeField] private KitchenObjectSO kitchenObjectSO;

    public event EventHandler OnPlayerGrabbedObject;

    public override void Interact(Player player)
    {
        if(!player.HasKitchenObject()){
            // player not carrying anything
            KitchenObject.SpawnKitchenObject(kitchenObjectSO, player);

            OnPlayerGrabbedObject?.Invoke(this, EventArgs.Empty);
        }
        

        // ======== Kitchen Object disimpan di Counter Top Poin kalau kosong, kalau di counter top point ada Kitchen object dipindah ke player
        // if (!HasKitchenObject())
        // {
        //     Transform kitchenObjectTransform = Instantiate(kitchenObjectSO.prefabs, counterTopPoint);
        //     kitchenObjectTransform.GetComponent<KitchenObject>().SetKitchenObjectParent(this);
        // }else{
        //     // give object to the player
        //     kitchenObject.SetKitchenObjectParent(player);
        // }


    }
}
