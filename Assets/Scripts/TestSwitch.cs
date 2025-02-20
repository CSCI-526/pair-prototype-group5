using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TestSwitch : MonoBehaviour
{
    public float EnemyHp = 10f;
    // Start is called before the first frame update
    void Start()
    {
        if (EnemyMeeting.sceneOneObjects != null)
        {
            Debug.Log("Found Inactive Object");
            //SceneOneManager.sceneOneObject.SetActive(true); // Enable it if needed
        }
        else
        {
            Debug.Log("No reference found!");
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (EnemyHp == 0){
            UnloadSecondScene();
        }
    }

    public void UnloadSecondScene()
    {
        // Unload Scene Two
        SceneManager.UnloadSceneAsync(1);
        
        foreach (GameObject obj in EnemyMeeting.sceneOneObjects)
        {
            if (obj != null) 
                obj.SetActive(true);
        }
        // Unload Scene Two
        SceneManager.UnloadSceneAsync(1);
        Debug.Log("Scene One objects re-enabled.");
    }
}
