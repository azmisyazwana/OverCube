using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClickableMateriUI : MonoBehaviour
{
    private const string KUBUS = "UnsurKubus";
    private const string LIMAS = "Cube";

    [SerializeField] private List<GroupToggleMateri> groupToggleClickableMateriKubusList;
    [SerializeField] private List<GroupToggleMateri> groupToggleClickableMateriLimasList;
    private string currentGameObject;


    private void Awake() {
        SetInactiveList(groupToggleClickableMateriLimasList);
    }


    private void Start() {
        PilihObjekUI.Instance.OnGameObjectChanged += PilihObjekUI_OnGameObjectChanged;

        currentGameObject = PilihObjekUI.Instance.GetCurrentGameObject();
        // Debug.Log(currentGameObject);
    }

    private void PilihObjekUI_OnGameObjectChanged(object sender, System.EventArgs e){
        currentGameObject = PilihObjekUI.Instance.GetCurrentGameObject();
        Debug.Log(currentGameObject);
        
        if(currentGameObject == KUBUS){
            SetActiveList(groupToggleClickableMateriKubusList);


            SetInactiveList(groupToggleClickableMateriLimasList);
        }else if(currentGameObject == LIMAS){
            SetActiveList(groupToggleClickableMateriLimasList);


            SetInactiveList(groupToggleClickableMateriKubusList);
        }else{
            SetInactiveAllList();
        }
       
    }

    private void SetActiveList(List<GroupToggleMateri> list){
         foreach(GroupToggleMateri groupToggleMateri in list){
            groupToggleMateri.gameObject.SetActive(true);
        }
    }

    private void SetInactiveList(List<GroupToggleMateri> list){
        foreach(GroupToggleMateri groupToggleMateri in list){
            groupToggleMateri.gameObject.SetActive(false);
        }
    }

    private void SetInactiveAllList(){
        SetInactiveList(groupToggleClickableMateriKubusList);
        SetInactiveList(groupToggleClickableMateriLimasList);
    }

}
