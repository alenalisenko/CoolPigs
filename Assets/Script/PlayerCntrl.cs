using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCntrl : MonoBehaviour
{
    public CharacterController controller;
    public float speed = 10f;

    public float gravity = -9.8f;
    private Vector3 velocity;
    public float JumpHeight = 3f;

    public Transform grndCheck;
    public float grndDist = 0.4f;
    public LayerMask grandMask;
    private bool isGrand;

    void Update()
    {
        isGrand = Physics.CheckSphere(grndCheck.position, grndDist, grandMask);

        if (isGrand && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);

        if (Input.GetButtonDown("Jump") && isGrand)
        {
            velocity.y = Mathf.Sqrt(JumpHeight * -2 * gravity);
        }

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }
}
