using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score_Display : MonoBehaviour {
    private int currScore;
    private GameObject curText;
    public ObjectPool objectPool;
    public GameObject collisionObj;
    
    // Start is called before the first frame update
    void Start() {
        currScore = 0;
    }

    // Update is called once per frame
    void Update() {
        int newScore = collisionObj.GetComponent<CollisionTimer>().score;
        if (curText == null) {
            curText = objectPool.GetPooledObject("Text");
            curText.GetComponent<GenerateNumbers>().getWord(4,4.5f," ");
        }
        if (newScore != currScore) {
            currScore = newScore;
            string scoreText = "Score: " + currScore;
            curText.GetComponent<GenerateNumbers>().deleteWord();
            curText.SetActive(false);
            curText = objectPool.GetPooledObject("Text");
            curText.GetComponent<GenerateNumbers>().getWord(4,4.5f,scoreText);
        }
    }



    
}
