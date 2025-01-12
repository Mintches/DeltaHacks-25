using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateNumbers : MonoBehaviour {

    public ObjectPool objectPool;
    List<GameObject> letters;

    // Start is called before the first frame update
    void Start() {
        letters = new List<GameObject>();
    }

    // Update is called once per frame
    void Update() {
        
    }

    public void getWord(float x, float y, string word) {
        for (int i = 0; i < word.Length; i++) {
            GameObject newObj = objectPool.GetPooledObject("Letter");
            LetterRenderer newLetter = newObj.GetComponent<LetterRenderer>();
            newObj.transform.position = new Vector3(x + (i * 0.4f), y, 0);
            newLetter.setLetter(word[i]);
            letters.Add(newObj);
        }
    }

    public void deleteWord() {
        for (int i = 0; i < letters.Count; i++) {
            letters[i].SetActive(false);
        }
    }
}
