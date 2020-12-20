using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardFactory : MonoBehaviour{
    
    private int x; 

    void Start() {
        x = 1;
    }
    
    void Update() {
        for (int i = 0; i < 10; i++){
            Debug.Log(i);
        }
    }
}
