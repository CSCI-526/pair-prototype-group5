using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyMeeting : MonoBehaviour
{
    public static GameObject[] sceneOneObjects;
    // Start is called before the first frame update
    void Start()
    {
        sceneOneObjects = FindObjectsOfType<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other) {
        LoadSecondScene();

        Destroy(gameObject);
        
    }

    public void LoadSecondScene()
    {
        
        foreach (GameObject obj in sceneOneObjects)
        {
            if(obj != null){
                if (obj.scene == gameObject.scene)
                    obj.SetActive(false);
                }
        }

        // Load Scene Two additively
        SceneManager.LoadSceneAsync(1, LoadSceneMode.Additive);
        Debug.Log("Scene Two loaded.");
    }

    public void UnloadSecondScene()
    {
        // Unload Scene Two
        SceneManager.UnloadSceneAsync(1);
        
        foreach (GameObject obj in sceneOneObjects)
        {
            if (obj != null) 
                obj.SetActive(true);
        }

        Debug.Log("Scene One objects re-enabled.");
    }
}
