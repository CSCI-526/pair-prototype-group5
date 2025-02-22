using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{

    private int health = 15;
    private int turnsToSkip;

    // Start is called before the first frame update
    void Start()
    {
        turnsToSkip = new System.Random().Next(0, 3);    
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(int damage) {
        health = Mathf.Max(0, health - damage);
    }

    public int CurrentHealth() {
        return health;
    }

    public int MakeDamage() {
        if (turnsToSkip == 0) {
            turnsToSkip = new System.Random().Next(0, 3);
            return new System.Random().Next(2, 6);
        }
        --turnsToSkip;
        return 0;
    }
}
