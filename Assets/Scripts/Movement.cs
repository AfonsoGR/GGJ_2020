using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour
{
    CharacterController characterController;

    public float speed = 6.0f;

    private Vector2 moveDirection = Vector2.zero;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        moveDirection = new Vector2
            (Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        moveDirection *= speed;
        characterController.Move(moveDirection * Time.deltaTime);
    }
}
