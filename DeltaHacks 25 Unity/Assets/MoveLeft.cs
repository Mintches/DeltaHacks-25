using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour {
    public float speed = 0.1f;

    void Start() {

    }

    void Update() {
        transform.Translate(Vector3.left * speed * Time.deltaTime);
    }
}
