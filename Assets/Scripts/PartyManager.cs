using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartyManager : MonoBehaviour
{
    private int health = 10;
    private int currentCharge;
    private int currentCharacterIdx;
    public GameObject[] characters;
    
    // Start is called before the first frame update
    void Start()
    {
        currentCharge = 1;
        currentCharacterIdx = 0;
        GameObject attack = characters[0];
        GameObject charge = characters[1];
        attack.transform.position = new Vector3(-2.5f, 0.5f, -8f);
        charge.transform.position = new Vector3(2.5f, 0.5f, -8f); 
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) {
            SwitchCharacter();
        }
    }

    private void SwitchCharacter() {
        currentCharacterIdx = (currentCharacterIdx + 1) % characters.Length;
    }

    public GameObject GetCurrentCharacter() {
        return characters[currentCharacterIdx];
    }

    public void TakeDamage(int damage) {
        health = Mathf.Max(0, health - damage);
    }

    private void Charge() {
        ++currentCharge;
    }

    public int MakeDamage() {
        int damage = currentCharge;
        currentCharge = Mathf.Max(1, currentCharge - 1);
        return damage;
    }

    public int CurrentHealth() {
        return health;
    }
}
