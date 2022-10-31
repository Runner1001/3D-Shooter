using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float rotationSpeed = 3f;
    [SerializeField] private float moveSpeed = 5f;

    private float horizontal;
    private float vertical;
    private float mouseHorizontal;
    private Animator anim;
    private CharacterController characterController;

    void Awake()
    {
        anim = GetComponentInChildren<Animator>();
        characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");

        mouseHorizontal = Input.GetAxis("Mouse X");

        anim.SetFloat("Speed", vertical);

        if(Input.GetMouseButtonDown(1) == false)
        {
            transform.Rotate(Vector3.up, mouseHorizontal * rotationSpeed * Time.deltaTime);
        }

        characterController.SimpleMove(transform.forward * moveSpeed * Time.deltaTime * vertical);
    }
}
