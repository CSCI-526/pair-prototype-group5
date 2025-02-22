using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnManager : MonoBehaviour
{
    public GameObject party;
    public GameObject enemy;
    private PartyManager partyManager;
    private EnemyManager enemyManager;

    void Start()
    {
        Debug.Log("Battle Started.");
        partyManager = party.GetComponent<PartyManager>();
        enemyManager = enemy.GetComponent<EnemyManager>();
        Debug.Log(partyManager);
        Debug.Log(enemyManager);
        StartCoroutine(RunTurnLoop());
    }

    IEnumerator RunTurnLoop()
    {
        Debug.Log(IsBattleOver());
        // Debug.Log(partyManager.CurrentHealth());
        // Debug.Log(enemyManager.CurrentHealth());
        while (!IsBattleOver())
        {
            Debug.Log("Battle is not over");
            yield return StartCoroutine(PlayerTurn());  
            yield return StartCoroutine(EnemyTurn());  
        }
    }

    IEnumerator PlayerTurn()
    {
        Debug.Log("Player's Turn");

        // Wait for player action (attack, skill, etc.)
        yield return new WaitForSeconds(3);
        GameObject currentCharacter = partyManager.GetCurrentCharacter();

        int damage = partyManager.MakeDamage();
        enemyManager.TakeDamage(damage);

        // Simulate attack animation time
        yield return new WaitForSeconds(1); 
    }

    IEnumerator EnemyTurn()
    {
        Debug.Log("Enemy's Turn");

        // Simulate enemy thinking time
        yield return new WaitForSeconds(1);

        int damage = enemyManager.MakeDamage();
        partyManager.TakeDamage(damage);

        // Simulate enemy attack animation time
        yield return new WaitForSeconds(1); 
    }

    bool IsBattleOver()
    {
        return partyManager.CurrentHealth() == 0 || enemyManager.CurrentHealth() == 0;
    }
}
