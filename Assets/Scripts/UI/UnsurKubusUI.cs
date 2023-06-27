using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UnsurKubusUI : MonoBehaviour
{
    private const string POPUP = "Popup";

    [SerializeField] private Image backgroundImage;
    [SerializeField] private TextMeshProUGUI messageText;
    [SerializeField] private Color backgroundColor;

    private UnsurKubus unsurKubus;

    [SerializeField] private float editPosX = 0.1f;
    [SerializeField] private float editPosY = 0.15f;
    [SerializeField] private float editPosZ = -0.5f;

    private Animator animator;

    private void Awake() {
        animator = GetComponent<Animator>();
    }

    private void Start() {
        Selection.Instance.OnUnsurClicked += Selection_OnUnsurClicked;
        Selection.Instance.OnUnsurUnclicked += Selection_OnUnsurUnclicked;

        gameObject.SetActive(false);

    }

    private void Selection_OnUnsurClicked(object sender, System.EventArgs e){
        unsurKubus = Selection.Instance.GetUnsurKubus();

        MakePositionForUI();

        gameObject.SetActive(true);
        animator.SetTrigger(POPUP);
        backgroundImage.color = backgroundColor;
        messageText.text = unsurKubus.GetCompleteNameUnsurKubus();
    }

    private void Selection_OnUnsurUnclicked(object sender, System.EventArgs e){
        unsurKubus = Selection.Instance.GetUnsurKubus();

        gameObject.SetActive(false);
    }

    private void MakePositionForUI(){
        float posX = MousePosition.GetMouseWorldPosition().x;
        float posY = MousePosition.GetMouseWorldPosition().y;
        float posZ = MousePosition.GetMouseWorldPosition().z;

        if(posX < -0.45){
            editPosX *= 1;
        }else if(posX > -0.45 && posX < 0.4){
            editPosX = 0;
        }else{
            editPosX *= -1;
        }

    
        if(posY > 2.8f){
            gameObject.transform.position = new Vector3(posX + editPosX, posY - editPosY, editPosZ);
        }else{
            gameObject.transform.position = new Vector3(posX + editPosX, posY + editPosY, editPosZ);
        }

    }
}
