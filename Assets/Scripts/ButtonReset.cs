using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonReset : MonoBehaviour
{
    [SerializeField] private List<GameObject> gameObjectList;
    private List<Vector3> initialRotationList;
    private Button buttonReset;

    private void Awake() {
        GetInitialPosition();

        buttonReset = GetComponent<Button>();
        buttonReset.onClick.AddListener(() => {
            ResetPosition();
        });
    }



    // private void ResetPosition(){
    //     int i = 0;
    //     while(i <= gameObjectList.Count - 1 && !isFound){
    //         if(gameObjectList[i].activeSelf == true){
    //             isFound = true;
    //             gameObjectList[i].transform.position = new Vector3(initialRotationList[i].position.x, initialRotationList[i].position.y, initialRotationList[i].position.z);
    //             // gameObjectList[i].transform.rotation = initialRotationList[i].rotation;
    //             Debug.Log(initialRotationList[i].position);
    //         }
    //         i++;
    //     }
    //     // gameObjectList[0].transform.position = new Vector3(0, 0, 0);

    // }

    private void ResetPosition(){
        int index = GetIndexObjectActive();
        
        float rotX = initialRotationList[index].x;
        float rotY = initialRotationList[index].y;
        float rotZ = initialRotationList[index].z;

        gameObjectList[index].transform.rotation = Quaternion.Euler(rotX, rotY, rotZ);

    }

    private int GetIndexObjectActive(){
        bool isFound = false;
        int i = 0;
        while (i <= gameObjectList.Count - 1 && !isFound){
            if(gameObjectList[i].activeSelf == true){
                isFound = true;
                return i;
            }
            i++;
        }
        return 0;
    }

    private void GetInitialPosition(){
        initialRotationList = new List<Vector3>();
        foreach (GameObject gameObject in gameObjectList)
        {           
            initialRotationList.Add(gameObject.transform.eulerAngles);
        }
    }
}
