using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : MonoBehaviour
{
    public GameObject dit;
    public GameObject dah;
    public GameObject end;
    public string message = "ABCD"; // placeholder message
    public float gap = 1f; // gap between each letter
    public float gapBetweenMorse = 0.5f; // gap between each ditdah in the morse
    private float elapsedTime = 0.0f;
    private int letterIndex = 0;
    private int morseIndex = 0;
    private bool isBetweenLetters = false;
    // letter to morse map, I'll add the rest later
    Dictionary<char, string> letterMorseMap = new Dictionary<char, string>
    {
        {'A', ".-"},
        {'B', "-..."},
        {'C', "-.-."},
        {'D', "-.."}
    };

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (letterIndex >= message.Length) return; // all letters processed

        elapsedTime += Time.deltaTime;
        
        if (isBetweenLetters) {
            if (elapsedTime >= gap) {
                elapsedTime = 0;
                isBetweenLetters = false;
                letterIndex++;
                morseIndex = 0;
            }
        } else {
            char currentLetter = message[letterIndex];
            string morse = letterMorseMap[currentLetter];
            if (morseIndex < morse.Length) {
                if (elapsedTime >= gapBetweenMorse) {
                    char ditDah = morse[morseIndex];
                    if (ditDah == '.') {
                        Instantiate(dit, transform);
                        Debug.Log(".");
                    } else if (ditDah == '-') {
                        Instantiate(dah, transform);
                        Debug.Log("-");
                    }
                    elapsedTime = 0f;
                    morseIndex++;
                }
            } else {
                Instantiate(end, transform);
                Debug.Log("end");
                isBetweenLetters = true;
                elapsedTime = 0f;
            }
        }
    }

}
