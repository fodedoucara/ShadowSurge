using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public enum EnemyState {
    CHASE,
    ATTACK
}

public class EnemyController : MonoBehaviour {
    private CharacterAnimations enemy_Anim;
    private NavMeshAgent navAgent;
    private Transform playerTarget;

    public float move_Speed = 3.5f;
    public float attack_Distance = 1f;
    public float chase_Player_After_Attack_Distance = 1f;
    private float wait_Before_Attack_Time = 3f;
    private float attack_Timer;

    private EnemyState enemy_State;

    void Awake() {
        enemy_Anim = GetComponent<CharacterAnimations>();
        navAgent = GetComponent<NavMeshAgent>();

        playerTarget = GameObject.FindGameObjectWithTag(Tags.PLAYER_TAG).transform;
        
    } // awake

    void Start() {
        enemy_State = EnemyState.CHASE;
        attack_Timer = wait_Before_Attack_Time;

    } // start

    // Update is called once per frame
    void Update() {
        if (enemy_State == EnemyState.CHASE) {
            ChasePlayer();
        }

        if (enemy_State == EnemyState.ATTACK) {
            AttackPlayer();
        }
        
    } // update

        void ChasePlayer() {
            navAgent.SetDestination(playerTarget.position);
            navAgent.speed = move_Speed;

            if(navAgent.velocity.sqrMagnitude == 0) {
                enemy_Anim.Walk(false);

            } else {
                enemy_Anim.Walk(true);

            }

            if (Vector3.Distance(transform.position, playerTarget.position) <= attack_Distance) {
                enemy_State = EnemyState.ATTACK;
            }

        } //chaseplayer

        void AttackPlayer() {

        } // attackplayer
} // class
