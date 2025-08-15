using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour {
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public float movement_speed = 3f;
    public float gravity = 9.8f;
    public float rotation_Speed = 0.15f;
    public float rotateDegreesPerSecond = 180f;
    private CharacterController charController;
    private CharacterAnimations playerAnimations;

    void Awake() {
        charController = GetComponent<CharacterController>();
        playerAnimations = GetComponent<CharacterAnimations>();
        } // awake

    // Update is called once per frame
    void Update() {
        Move();
        Rotate();
        AnimateWalk();
    } // update
    
    void Move() {
        if (Input.GetAxis(Axis.VERTICAL_AXIS) > 0) {

            Vector3 moveDirection = transform.forward;
            moveDirection.y -= gravity * Time.deltaTime;

            charController.Move(moveDirection * movement_speed * Time.deltaTime);   

        } else if (Input.GetAxis(Axis.VERTICAL_AXIS) < 0) {
            Vector3 moveDirection = -transform.forward;
            moveDirection.y -= gravity * Time.deltaTime;

            charController.Move(moveDirection * movement_speed * Time.deltaTime);   
        } else {
            charController.Move(Vector3.zero);
        }
    } // move

    void Rotate() {

        Vector3 rotation_Direction = Vector3.zero;

        if (Input.GetAxis(Axis.HORIZONTAL_AXIS) < 0) {
            rotation_Direction = transform.TransformDirection(Vector3.left);
            } 

        if (Input.GetAxis(Axis.HORIZONTAL_AXIS) > 0) {
            rotation_Direction = transform.TransformDirection(Vector3.right);
            }

        if (rotation_Direction != Vector3.zero) {
            transform.rotation = Quaternion.RotateTowards(transform.rotation, 
            Quaternion.LookRotation(rotation_Direction), 
            rotateDegreesPerSecond * Time.deltaTime);
        }
    } // rotate\

    void AnimateWalk() {

        if (charController.velocity.sqrMagnitude !=0) {
            playerAnimations.Walk(true);
        } else {
            playerAnimations.Walk(false);
        }
    } // animatewalk
} // class
