using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackInput : MonoBehaviour {

    private CharacterAnimations playerAnimations;

    void Awake() {
        playerAnimations = GetComponent<CharacterAnimations>();
    }

    // Update is called once per frame
    void Update() {
        // defend when X pressed
        if (Input.GetKeyDown(KeyCode.X)) {
            playerAnimations.Defend(true);
        }
        if (Input.GetKeyUp(KeyCode.X)) {
            playerAnimations.Defend(false);
        }

        // attack when Z pressed
        if (Input.GetKeyDown(KeyCode.Z)) {
            if(Random.Range(0, 2) > 0) {
                playerAnimations.Attack_0();
            } else {
                playerAnimations.Attack_1();
            }
        }
    }
} // class
