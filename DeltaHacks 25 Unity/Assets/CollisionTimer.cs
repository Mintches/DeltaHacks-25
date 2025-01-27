using UnityEngine;
using UnityEngine.UI; 

public class CollisionTimer : MonoBehaviour {
    private bool isColliding = false;
    private float collisionTime = 0f;  
    private float spacePressedTime = 0f;
    private bool clicked = false;
    private bool wrongPress = false;
    private bool isPlaying = false;

    public int score = 0;

    private GameObject collidedObject;
    public AudioSource beep;
    public GameObject light;
    public ObjectPool objectPool;
    private GameObject curWord;

    [SerializeField] private GameObject perfect;
    [SerializeField] private GameObject ok;
    [SerializeField] private GameObject miss;

    void Start() {
        
    }

    void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.CompareTag("Dit") || other.gameObject.CompareTag("Dah")) {
            isColliding = true;
            collidedObject = other.gameObject;
        }
        else if (other.gameObject.CompareTag("End")) {
            if (curWord != null) {
                curWord.GetComponent<GenerateNumbers>().deleteWord();
                curWord.SetActive(false);
            }
            curWord = objectPool.GetPooledObject("Text");
            curWord.GetComponent<GenerateNumbers>().getWord(-4.5f, 4.5f, other.gameObject.GetComponent<End>().let.ToString());
        }
    }

    void OnTriggerExit2D(Collider2D other) {
        if (other.gameObject.CompareTag("Dit") || other.gameObject.CompareTag("Dah")) {
            isColliding = false;
            ResetTimes();
        }
        other.gameObject.SetActive(false);
    }

    void Update() {
        if (curWord == null) {
            curWord = objectPool.GetPooledObject("Text");
            curWord.GetComponent<GenerateNumbers>().getWord(-5, 4, " ");
        }
        if (collidedObject == null && Input.GetKey(KeyCode.Space) && !wrongPress) {
            wrongPress = true;
            score--;
            // Debug.Log("Deduct");
            // perfect.transform.position = new Vector3(0,-20,0);
            // ok.transform.position = new Vector3(0,-20,0);
            // miss.transform.position = new Vector3(-6.5f,0.5f,0);
            
        }
        if (!Input.GetKey(KeyCode.Space)) {
            beep.Stop();
            light.SetActive(false);
            isPlaying = false;
            wrongPress = false;
        } else if (!isPlaying)
        {
            isPlaying = true;
            beep.Play();
            light.SetActive(true);
        }
        if (wrongPress) return;
        if (collidedObject != null && collidedObject.CompareTag("Dit")) {
            if (Input.GetKey(KeyCode.Space)) {
                if (collidedObject != null) {
                    score += 2;
                    collidedObject.SetActive(false);
                    collidedObject = null;
                    Debug.Log("point");
                    perfect.transform.position = new Vector3(-6.5f,0.75f,0);
                    ok.transform.position = new Vector3(0,-20,0);
                    miss.transform.position = new Vector3(-6,-60,0);
                }
                spacePressedTime += Time.deltaTime;
            }
        }
        else if (collidedObject != null && collidedObject.CompareTag("Dah")) {
            collisionTime += Time.deltaTime;
            if (Input.GetKey(KeyCode.Space)) {
                clicked = true;
                spacePressedTime += Time.deltaTime;
                BounceObject(collidedObject);
            } else if (clicked) {
                float dup = spacePressedTime;
                int incre = (int)Mathf.Round(spacePressedTime * 4);
                score += incre;
                collidedObject.SetActive(false);
                collidedObject = null;
                // Debug.Log(spacePressedTime);
                if (incre == 2){
                    perfect.transform.position = new Vector3(-6.5f,0.75f,0);
                    ok.transform.position = new Vector3(0,-20,0);
                    miss.transform.position = new Vector3(-6,-60,0);
                    Debug.Log("perf");
                } else if (dup == 0) {
                    Debug.Log("oop");
                    perfect.transform.position = new Vector3(-6,-20,0);
                    ok.transform.position = new Vector3(0,-20,0);
                    miss.transform.position = new Vector3(-6.5f,0.5f,0);
                } else {
                    perfect.transform.position = new Vector3(-6,-20,0);
                    ok.transform.position = new Vector3(-6.5f,0.5f,0);
                    miss.transform.position = new Vector3(-6,-60,0);
                    Debug.Log("ok");
                }
            }
        }
    }

    void BounceObject(GameObject obj) {
        float initialY = obj.transform.position.y;
        float bounce = Mathf.Sin(Time.time * 50.0f) * 0.01f;
        obj.transform.position = new Vector3(obj.transform.position.x, initialY + bounce, obj.transform.position.z);
    }

    private void ResetTimes() {
        collisionTime = 0f;
        spacePressedTime = 0f;
        clicked = false;
    }
}
