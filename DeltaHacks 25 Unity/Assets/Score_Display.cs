using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score_Display : MonoBehaviour
{
    private int currScore;
    public GameObject myObject;
    // Start is called before the first frame update
    void Start()
    {
        currScore = 0;
    }

    // Update is called once per frame
    void Update()
    {
        int newScore = GetComponent<CollisionTimer>().score;
        if (currScore != newScore) {
            currScore = newScore;
            string scoreText = "Score: " + currScore;
            // GetComponent<GenerateNumbers>().deleteWord();
            GameObject temp = Instantiate(myObject);
            GenerateNumbers bob = temp.GetComponent<GenerateNumbers>();
            bob.getWord(1,1,scoreText);
            //GetComponent<GenerateNumbers>().getWord(1,1,scoreText);
        }
    }

    
}
