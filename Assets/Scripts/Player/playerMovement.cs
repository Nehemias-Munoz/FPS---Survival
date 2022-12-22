using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    [SerializeField] private CharacterController _characterController;
    [SerializeField] private Transform _groundCheck;
    [SerializeField] private LayerMask _groundMask;
    private float _sphereRadius = 0.1f;
    public float speed = 10f;
    private const float Gravity = -9.81f;

    private Vector3 velocity;
    private bool isGrounded;
    private float JumpHeight = 0.5f;
    void Update()
    {
        isGrounded = Physics.CheckSphere(_groundCheck.position, _sphereRadius, _groundMask);
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        Vector3 move = transform.right * x + transform.forward * z;

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(JumpHeight * -2 * Gravity);
        }
        _characterController.Move(move * (speed * Time.deltaTime));

        velocity.y += Gravity * Time.deltaTime;
        _characterController.Move(velocity * Time.deltaTime);

    }
}
