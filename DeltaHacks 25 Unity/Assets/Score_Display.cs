using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score_Display : MonoBehaviour {
    private int currScore;
    private GameObject curText = null;
    public ObjectPool objectPool;
    public GameObject collisionObj;
    // Start is called before the first frame update
    void Start() {
        currScore = 0;
    }

    // Update is called once per frame
    void Update() {
        int newScore = collisionObj.GetComponent<CollisionTimer>().score;
        if (currScore != newScore) {
            currScore = newScore;
            string scoreText = "Score: " + currScore;
            // GetComponent<GenerateNumbers>().deleteWord();
            if (curText != null) {
                curText.GetComponent<GenerateNumbers>().deleteWord();
                curText.SetActive(false);
            }
            Debug.Log(newScore);
            curText = objectPool.GetPooledObject("Text");
            curText.GetComponent<GenerateNumbers>().getWord(4,4.5f,scoreText);
            //GetComponent<GenerateNumbers>().getWord(1,1,scoreText);
        }
    }

    
}
