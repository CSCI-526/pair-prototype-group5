using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class TurnManager : MonoBehaviour
{
    public GameObject party;
    public GameObject enemy;
    public TextMeshProUGUI turnStatusText;
    private PartyManager partyManager;
    private EnemyManager enemyManager;

    void Start()
    {
        Debug.Log("Battle Started.");
        partyManager = party.GetComponent<PartyManager>();
        enemyManager = enemy.GetComponent<EnemyManager>();
        StartCoroutine(RunTurnLoop());
    }

    IEnumerator RunTurnLoop()
    {
        bool win = false;
        while (!IsBattleOver())
        {
            Debug.Log("Battle is not over");
            Debug.Log(partyManager.CurrentHealth());
            Debug.Log(enemyManager.CurrentHealth());
            yield return StartCoroutine(PlayerTurn()); 
            if (enemyManager.CurrentHealth() == 0) {
                turnStatusText.gameObject.SetActive(true);
                turnStatusText.text = "Win!";
                yield return new WaitForSeconds(1f);
                turnStatusText.gameObject.SetActive(false);
                win = true;
                break;
            } 
            yield return StartCoroutine(EnemyTurn());  
        }
        if (!win) {
            turnStatusText.gameObject.SetActive(true);
            turnStatusText.text = "Defeat!";
            yield return new WaitForSeconds(1f);
            turnStatusText.gameObject.SetActive(false);
        }
        UnloadSecondScene();
    }

    IEnumerator PlayerTurn()
    {
        Debug.Log("Player's Turn");

        // Show timer text
        turnStatusText.gameObject.SetActive(true);
        turnStatusText.text = "Your turn!";
        yield return new WaitForSeconds(1f);
        turnStatusText.gameObject.SetActive(false);

        yield return new WaitForSeconds(0.5f); 
        turnStatusText.gameObject.SetActive(true);
        
        // Start the countdown
        float timeLeft = 3f;
        while (timeLeft > 0)
        {
            turnStatusText.text = "Press SPACE to choose your character within: " + timeLeft.ToString("F1") + "s"; // Update UI
            yield return new WaitForSeconds(0.1f);
            timeLeft -= 0.1f;
        }

        // Hide timer text after time runs out
        turnStatusText.gameObject.SetActive(false);

        GameObject currentCharacter = partyManager.GetCurrentCharacter();

        yield return new WaitForSeconds(0.5f); 
        turnStatusText.gameObject.SetActive(true);

        if (currentCharacter.name == "Charge") {
            turnStatusText.text = "You get 1 charge!";
            partyManager.Charge();
        } else if (currentCharacter.name == "Shield") {
            turnStatusText.text = "Shield activated!";
            partyManager.ActivateShield();
        } else {
            int damage = partyManager.MakeDamage();
            turnStatusText.text = "Enemy takes " + damage.ToString() + " damage!";
            enemyManager.TakeDamage(damage);
        }

        yield return new WaitForSeconds(1f);
        turnStatusText.gameObject.SetActive(false);

        yield return new WaitForSeconds(0.5f); 
    }

    IEnumerator EnemyTurn()
    {
        Debug.Log("Enemy's Turn");

        turnStatusText.gameObject.SetActive(true);
        turnStatusText.text = "Enemy's turn!";
        yield return new WaitForSeconds(1f);
        turnStatusText.gameObject.SetActive(false);

        yield return new WaitForSeconds(0.5f); 
        turnStatusText.gameObject.SetActive(true);

        int damage = enemyManager.MakeDamage();
        if (damage == 0){
            turnStatusText.text = "Enemy skips his turn!";
        } else {
            if (partyManager.HasShield()) {
                turnStatusText.text = "Your shield absorbs " + damage.ToString() + " damage!";
            } else {
                turnStatusText.text = "You take " + damage.ToString() + " damage!";
            }
        }
        partyManager.TakeDamage(damage);

        yield return new WaitForSeconds(1f);
        turnStatusText.gameObject.SetActive(false);

        yield return new WaitForSeconds(0.5f); 
    }

    bool IsBattleOver()
    {
        return partyManager.CurrentHealth() == 0 || enemyManager.CurrentHealth() == 0;
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
    }
}
