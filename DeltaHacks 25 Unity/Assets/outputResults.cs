using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class outputResults : MonoBehaviour {

    public ObjectPool objectPool;
    private GameObject curText1;
    private GameObject curText2;
    // Start is called before the first frame update

    void Start() {
        
    }

    // Update is called once per frame
    void Update() {
        if (curText1 == null) {
            curText1 = objectPool.GetPooledObject("Text");
            curText1.GetComponent<GenerateNumbers>().getWord(-7,-1f,"Score: " + Data.score.ToString());
            curText2 = objectPool.GetPooledObject("Text");
            curText2.GetComponent<GenerateNumbers>().getWord(2.5f,-1f,"Message: " + Data.message); 
        }
        
    }
}
