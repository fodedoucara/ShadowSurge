using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimations : MonoBehaviour {

    private Animator anim;
   
    void Awake() {
        anim = GetComponent<Animator>();
    } // awake

    public void Walk(bool walk) {
        anim.SetBool(AnimationTags.WALK_PARAMETER, walk);
    } // walk

    public void Defend(bool defend) {
        anim.SetBool(AnimationTags.DEFEND_PARAMETER, defend);
    } // defend

    public void Attack_0() {
        anim.SetTrigger(AnimationTags.ATTACK_TRIGGER_0);
    } // attack0

    public void Attack_1() {
        anim.SetTrigger(AnimationTags.ATTACK_TRIGGER_1);
    } // attack1
} // class
