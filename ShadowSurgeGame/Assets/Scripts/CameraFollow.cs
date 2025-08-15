using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

    private Transform target;

    [SerializeField]
    private Vector3 offsetPosition;
    
    void Awake() {
        target = GameObject.FindGameObjectWithTag("Player").transform;
    } // awake

    // LateUpdate is called once per frame after Update
    void LateUpdate() {
        FollowPlayer();
    } // lateupdate

    void FollowPlayer() {

        transform.position = target.TransformPoint(offsetPosition);
        transform.rotation = target.rotation;
    }
} // class
