using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardFactory : MonoBehaviour{
    
    private int x; 
    private int y;

    void Start() {
	x = 1;
        y = 2;
    }
    
    void Update() {
        for (int i = 0; i < 10; i++){
            Debug.Log(i);
        }
        Debug.Log(y);
    }
}
