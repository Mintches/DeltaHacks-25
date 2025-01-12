using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class score_functions : MonoBehaviour
{
    [SerializeField] private string scoreText;
    public int score;
    // Start is called before the first frame update
    void Start()
    {
        scoreText = "Score: " + 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void addScore(int score_to_add) { // updated this with scoring system
        score += score_to_add;
        scoreText = "Score: " + score;
    }
}
