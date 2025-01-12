using UnityEngine;
using UnityEngine.UI; 

public class CollisionTimer : MonoBehaviour {
    private bool isColliding = false;
    private float collisionTime = 0f;  
    private float spacePressedTime = 0f;
    private bool clicked = false;
    private bool wrongPress = false;


    public int score = 0;

    private GameObject collidedObject;
    public AudioSource beep;
    public GameObject light;
    public ObjectPool objectPool;
    private GameObject curWord;

    void Start() {

        
    }

    void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.CompareTag("Dit") || other.gameObject.CompareTag("Dah")) {
            isColliding = true;
            collidedObject = other.gameObject;
            beep.Play();
            light.SetActive(true);
        }
        else if (other.gameObject.CompareTag("End")) {
            if (curWord != null) {
                curWord.GetComponent<GenerateNumbers>().deleteWord();
                curWord.SetActive(false);
            }
            curWord = objectPool.GetPooledObject("Text");
            curWord.GetComponent<GenerateNumbers>().getWord(-5, 4, other.gameObject.GetComponent<End>().let.ToString());
        }
    }

    void OnTriggerExit2D(Collider2D other) {
        if (other.gameObject.CompareTag("Dit") || other.gameObject.CompareTag("Dah")) {
            isColliding = false;
            ResetTimes();
            beep.Stop();
            light.SetActive(false);
        }
        other.gameObject.SetActive(false);
    }

    void Update() {
        if (curWord == null) {
            curWord = objectPool.GetPooledObject("Text");
            curWord.GetComponent<GenerateNumbers>().getWord(-5, 4, " ");
        }
        if(collidedObject == null && Input.GetKey(KeyCode.Space) && !wrongPress) {
            wrongPress = true;
            score--;
            Debug.Log("Deduct");
        }
        if (!Input.GetKey(KeyCode.Space)) {
            wrongPress = false;
        }
        if (wrongPress) return;
        if (collidedObject != null && collidedObject.CompareTag("Dit")) {
            if (Input.GetKey(KeyCode.Space)) {
                if (collidedObject != null) {
                    score += 2;
                    collidedObject.SetActive(false);
                    collidedObject = null;
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
            } else if (clicked) {
                score += (int)Mathf.Round(spacePressedTime * 4);
                collidedObject.SetActive(false);
                collidedObject = null;
            }
        }
    }

    void BounceObject(GameObject obj) {
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
