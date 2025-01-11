using UnityEngine;
using UnityEngine.UI; 

public class CollisionTimer : MonoBehaviour
{
    private bool isColliding = false;
    private float collisionTime = 0f;  
    private float spacePressedTime = 0f; 

    public int score = 0;
    private GameObject collidedObject;

    void Start()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        isColliding = true;
        collidedObject = other.gameObject;
    }

    void OnTriggerExit2D(Collider2D other)
    {
        isColliding = false;
        DestroyDah();
        ResetTimes();
    }

    void Update()
    {
        if (collidedObject != null && collidedObject.CompareTag("Dit"))
        {


            if (Input.GetKey(KeyCode.Space))
            {
                if (collidedObject != null)
                {
                    score++;
                    Destroy(collidedObject); 
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
                spacePressedTime += Time.deltaTime;
            }
        }
    }

    private void DestroyDah()
    {
        if(spacePressedTime > 0)
        {
            Destroy(collidedObject);
            Debug.Log("Clicked!");
        }
    }

    private void ResetTimes()
    {
        collisionTime = 0f;
        spacePressedTime = 0f;
    }
}
