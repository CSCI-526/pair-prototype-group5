using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour {

    // Start is called before the first frame update
    public float offsetDistance;
    public int currentCharacterIdx;
    public GameObject[] characters;
    public GameObject enemy; 
    public Vector3 offset;

    void Start() {
        currentCharacterIdx = 0;
        MoveToCharacter(currentCharacterIdx);
    }

    // Update is called once per frame
    void Update() {
        if (Input.GetKeyDown(KeyCode.Space)) {
            currentCharacterIdx = (currentCharacterIdx + 1) % characters.Length;
            MoveToCharacter(currentCharacterIdx);
        }
    }

    void MoveToCharacter(int characterIdx) {
        transform.position = characters[currentCharacterIdx].transform.position + offset;
        transform.LookAt(enemy.transform.position);
        transform.position -= transform.forward * offsetDistance;
    }
}
