using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour {

    public GameObject party;
    public GameObject enemy; 
    private PartyManager partyManager;
    private float offsetDistance = 3.5f;
    private Vector3 offset = new Vector3(0, 1, 0);

    // Start is called before the first frame update
    void Start() {
        partyManager = party.GetComponent<PartyManager>();
        GetCurrentCharacterView();
    }

    // Update is called once per frame
    void Update() {
        GetCurrentCharacterView();
    }

    void GetCurrentCharacterView() {
        GameObject currentCharacter = partyManager.GetCurrentCharacter();
        transform.position = currentCharacter.transform.position + offset;
        transform.LookAt(enemy.transform.position);
        transform.position -= transform.forward * offsetDistance;
    }
}