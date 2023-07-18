using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] InputData input;
    [Header("Player Control Settings")]
    [SerializeField] private float walkSpeed = 8f;
    [SerializeField] private float runSpeed = 12f;
    [SerializeField] private float rotateSpeed = 30f;
    [SerializeField] private float gravityModifer = 0.95f;
    [SerializeField] float maxViewAngle = 60f;

    private CharacterController characterController;

    private float currentSpeed = 8f;
    private Vector3 heightMovement;
    private Transform mainCamera;



    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
        if (Camera.main.GetComponent<CameraController>() == null)
        {
            Camera.main.gameObject.AddComponent<CameraController>();
        }
        mainCamera = GameObject.FindWithTag("CameraPoint").transform;
    }

    private void FixedUpdate()
    {
        Move();
        Rotate();
    }


    private void Move()
    {
        heightMovement.y -= gravityModifer * Time.deltaTime;

        //Baktigin yöne dogru gitmesi icin
        Vector3 localVerticalVector = transform.forward * input.Vertical; 
        Vector3 localHorizontalVector = transform.right * input.Horizontal;
        Vector3 movmentVector = localHorizontalVector + localVerticalVector;

        movmentVector.Normalize();       // normal hiz 8 ise sag ust hiz 8.4 daha hizli onu esitledik hepsi 8
        movmentVector *= currentSpeed * Time.deltaTime;

        characterController.Move(movmentVector+ heightMovement);

        if (characterController.isGrounded)
        {
            heightMovement.y = 0f;
        }
    }

    private void Rotate()
    {
        transform.rotation = Quaternion.Euler(transform.eulerAngles.x + (-input.RotateDirection.z),
        transform.eulerAngles.y + input.RotateDirection.x,
        transform.eulerAngles.z);
    }
}


