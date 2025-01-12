using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class press_start : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private string sceneToLoad;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void change_scene() {
        SceneManager.LoadScene(sceneToLoad);;
    }
}
