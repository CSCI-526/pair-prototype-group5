using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartyManager : MonoBehaviour
{
    private int health = 15;
    private int currentCharge = 1;
    private bool hasShield = false;
    private int currentCharacterIdx = 0;
    public GameObject[] characters;
    
    // Start is called before the first frame update
    void Start()
    {
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
        if (damage == 0) return;
        if (hasShield) {
            hasShield = false;
            return;
        }
        health = Mathf.Max(0, health - damage);
    }

    public void Charge() {
        ++currentCharge;
    }

    public int MakeDamage() {
        int damage = 2 + currentCharge;
        currentCharge = Mathf.Max(1, currentCharge - 1);
        return damage;
    }

    public void ActivateShield() {
        hasShield = true;
        currentCharge = Mathf.Max(1, currentCharge - 1);
    }

    public int CurrentHealth() {
        return health;
    }

    public int CurrentCharge() {
        return currentCharge;
    }

    public bool HasShield() {
        return hasShield;
    }
}
