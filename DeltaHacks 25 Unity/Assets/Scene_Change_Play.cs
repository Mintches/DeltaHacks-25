using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene_Change_Play : MonoBehaviour
{
    [SerializeField] private string sceneToLoad;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void scene_start_play() {
        SceneManager.LoadScene(sceneToLoad);
    }
}
