using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LetterObjectPool : MonoBehaviour {
    /*
    public static LetterObjectPool SharedInstance;
    List<LetterRenderer> pooledObjects;
    public LetterRenderer objectToPool;
    public int amountToPool;

    void Awake() {
        SharedInstance = this;
    }

    void Start() {
        pooledObjects = new List<LetterRenderer>();
        for (int i = 0; i < amountToPool; i++) {
            LetterRenderer tmp;
            for (int j = 0; j < amountToPool; j++) {
                tmp = Instantiate(objectToPool);
                tmp.SetActive(false);
            }
            pooledObjects.Add(tmp);
        }
    }

    // Update is called once per frame
    void Update() {
        
    }

    public LetterRenderer GetPooledObject(string obj) {
        for (int i = 0; i < pooledObjects.Count; i++) {
            if (!pooledObjects[i].activeInHierarchy) {
                pooledObjects[i].SetActive(true);
                return pooledObjects[i];
            }
        }
        return null;
    }*/
}
