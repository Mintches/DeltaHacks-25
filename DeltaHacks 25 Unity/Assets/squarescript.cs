using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class squarescript : MonoBehaviour {

    // Start is called before the first frame update
    public GameObject thisone;
    int num = 0;

    void Start() {
        thisone.SetActive(false);
        
    }

    // Update is called once per frame
    void Update() {
        num += 1;
        if (num == 1000) {
            thisone.SetActive(false);
            num = 0;
        }
    }
}
