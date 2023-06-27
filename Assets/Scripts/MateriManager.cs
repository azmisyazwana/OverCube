using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MateriManager : MonoBehaviour
{

    public static MateriManager Instance { get; private set; }
    
    public event EventHandler OnMateriPaused;
    public event EventHandler OnMateriUnpaused;

    private bool isMateriPaused = false;

    private void Awake() {
        Instance = this;
    }

    private void Start() {
        GameInput.Instance.OnPauseAction += GameInput_OnPauseAction;
    }

    private void GameInput_OnPauseAction(object sender, EventArgs e){
        TogglePauseMateri();
    }

    public void TogglePauseMateri(){
        isMateriPaused = !isMateriPaused;

        if(isMateriPaused){
            Time.timeScale = 0f;
            
            OnMateriPaused?.Invoke(this, EventArgs.Empty);
        }else{
            Time.timeScale = 1f;
            
            OnMateriUnpaused?.Invoke(this, EventArgs.Empty);
        }
        
    }
}
