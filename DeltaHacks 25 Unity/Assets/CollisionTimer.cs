using UnityEngine;
using UnityEngine.UI; 

public class CollisionTimer : MonoBehaviour {
    private bool isColliding = false;
    private float collisionTime = 0f;  
    private float spacePressedTime = 0f;
    private bool clicked = false;


    public int score = 0;
    private GameObject collidedObject;

    void Start() {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        isColliding = true;
        collidedObject = other.gameObject;
    }

    void OnTriggerExit2D(Collider2D other)
    {
        isColliding = false;
        ResetTimes();
    }

    void Update() {
        if (collidedObject != null && collidedObject.CompareTag("Dit")) {
            if (Input.GetKey(KeyCode.Space)) {
                if (collidedObject != null) {
                    score++;
                    collidedObject.SetActive(false);
                    collidedObject = null;
                    Debug.Log("Clicked!");
                }
                spacePressedTime += Time.deltaTime;
            }
        }
        else if (collidedObject != null && collidedObject.CompareTag("Dah"))
        {
            collisionTime += Time.deltaTime;
            if (Input.GetKey(KeyCode.Space))
            {
                clicked = true;
                spacePressedTime += Time.deltaTime;
                BounceObject(collidedObject);
            } else if (clicked)
            {
                score += (int)Mathf.Round(spacePressedTime * 4);
                collidedObject.SetActive(false);
                collidedObject = null;
                Debug.Log("Clicked!");
            }
        }
    }

    void BounceObject(GameObject obj)
    {
        float initialY = obj.transform.position.y;
        float bounce = Mathf.Sin(Time.time * 50.0f) * 0.01f;
        obj.transform.position = new Vector3(obj.transform.position.x, initialY + bounce, obj.transform.position.z);
    }



    private void ResetTimes()
    {
        collisionTime = 0f;
        spacePressedTime = 0f;
        clicked = false;
    }
}
