using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PartyUI : MonoBehaviour
{

    public GameObject party;
    public GameObject enemy;
    private PartyManager partyManager;
    private EnemyManager enemyManager;
    
    public TextMeshProUGUI healthText;
    public TextMeshProUGUI chargeText;
    public TextMeshProUGUI enemyHealthText;

    void Start()
    {
        partyManager = party.GetComponent<PartyManager>();
        enemyManager = enemy.GetComponent<EnemyManager>();
    }

    void Update()
    {
        // Update Text Values
        healthText.text = "Health: " + partyManager.CurrentHealth();
        chargeText.text = "Charge: " + partyManager.CurrentCharge();
        enemyHealthText.text = "Health: " + enemyManager.CurrentHealth();
    }
}
