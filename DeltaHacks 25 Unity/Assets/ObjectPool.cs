using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour {

    public static ObjectPool SharedInstance;
    Dictionary<string, List<GameObject>> pooledObjects;
    public List<string> objectToPoolStr;
    public List<GameObject> objectToPool;
    public List<int> amountToPool;

    void Awake() {
        SharedInstance = this;
    }

    void Start() {
        pooledObjects = new Dictionary<string, List<GameObject>>();
        for (int i = 0; i < objectToPool.Count; i++) {
            List<GameObject> tmpList = new List<GameObject>();
            GameObject tmp;
            for (int j = 0; j < amountToPool[i]; j++) {
                tmp = Instantiate(objectToPool[i]);
                tmp.SetActive(false);
                tmpList.Add(tmp);
            }
            pooledObjects.Add(objectToPoolStr[i], tmpList);
        }
    }

    // Update is called once per frame
    void Update() {
        
    }

    public GameObject GetPooledObject(string obj) {
        for (int i = 0; i < pooledObjects[obj].Count; i++) {
            if (!pooledObjects[obj][i].activeInHierarchy) {
                pooledObjects[obj][i].SetActive(true);
                return pooledObjects[obj][i];
            }
        }
        return null;
    }
}
