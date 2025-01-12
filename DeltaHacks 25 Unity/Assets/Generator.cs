using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : MonoBehaviour {
    public ObjectPool objectPool;
    public GameObject dit;
    public GameObject dah;
    public GameObject end;
    [SerializeField] public string message = "OOOO"; // placeholder message
    [SerializeField] public float gap = 1f; // gap between each letter
    [SerializeField]public float gapAfterDit = 0.25f; // gap after a dit
    [SerializeField]public float gapAfterDah = 0.5f; // gap after a dah should be longer
    private float elapsedTime = 0.0f;
    private int letterIndex = 0;
    private int morseIndex = 0;
    private bool isBetweenLetters = false;

    private bool wasDit = false; // check if last one was dit or dah
    // letter to morse map, I'll add the rest later
    Dictionary<char, string> letterMorseMap = new Dictionary<char, string> {
        {'A', ".-"},
        {'B', "-..."},
        {'C', "-.-."},
        {'D', "-.."},
        {'O', "---"}
    };

    // Start is called before the first frame update
    void Start() {
        
    }

    // Update is called once per frame
    void Update() {
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
                if (elapsedTime >= gapAfterDit && wasDit || elapsedTime >= gapAfterDah) {
                    char ditDah = morse[morseIndex];
                    if (ditDah == '.') {
                        GameObject tmp = objectPool.GetPooledObject("Dit");
                        tmp.transform.position = new Vector3(8, 2, 0);
                        wasDit = true;
                        Debug.Log(".");
                    } else if (ditDah == '-') {
                        GameObject tmp = objectPool.GetPooledObject("Dah");
                        tmp.transform.position = new Vector3(8, 2, 0);
                        wasDit = false;
                        Debug.Log("-");
                    }
                    elapsedTime = 0f;
                    morseIndex++;
                }
            } else {
                GameObject tmp = objectPool.GetPooledObject("End");
                tmp.GetComponent<End>().let = currentLetter;
                tmp.transform.position = new Vector3(8, 4, 0);
                Debug.Log("end");
                isBetweenLetters = true;
                elapsedTime = 0f;
            }
        }
    }

}
