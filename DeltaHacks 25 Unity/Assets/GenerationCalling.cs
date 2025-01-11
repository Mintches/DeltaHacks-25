using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerationCalling : MonoBehaviour {
    // Start is called before the first frame update

    public ObjectPool objPool;

    void Start() {
        
    }

    // Update is called once per frame
    void Update() {
        if (Input.GetKeyDown(KeyCode.Space)) {
            int curx = Random.Range(0, 10);
            int cury = Random.Range(0, 10);
            GameObject tmp = objPool.GetPooledObject();
            tmp.transform.position = new Vector3(curx, cury, 0);
            tmp.SetActive(true);
        }
    }
}
