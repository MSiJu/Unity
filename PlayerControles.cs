using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private CharacterController characterController;
    private Vector3 moveVelocity;
    public float speed;
    public float Runspeed;

    private Animator anim;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        float horizontal = 0f;
        float vertical = 0f;

        if (Input.GetKey(KeyCode.W)) vertical += 1f;
        if (Input.GetKey(KeyCode.S)) vertical -= 1f;
        if (Input.GetKey(KeyCode.D)) horizontal += 1f;
        if (Input.GetKey(KeyCode.A)) horizontal -= 1f;

        Vector3 moveDirection = (transform.forward * vertical + transform.right * horizontal);

        if (moveDirection.magnitude > 0.1f)
        {
            moveDirection.Normalize();
        }

        if (Input.GetKey(KeyCode.LeftShift) )
        {
            moveVelocity = moveDirection * Runspeed;
        } 
        else 
        {
            moveVelocity = moveDirection * speed;
        }

        if (vertical != 0 || horizontal != 0) 
        {
            anim.SetBool("IsRun", true);
            // キャラクターを動かす
            characterController.Move(moveVelocity * Time.deltaTime);
        } 
        else
        {
            anim.SetBool("IsRun", false);
        }
    }
}