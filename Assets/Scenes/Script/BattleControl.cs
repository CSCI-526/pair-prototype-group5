using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleControl : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameObject enemy = GameObject.Find("enemy");
        if (enemy != null)
    {
        Debug.Log("Found player!");
    }
    else
    {
        Debug.LogError("Player GameObject not found!");
    }

    
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

