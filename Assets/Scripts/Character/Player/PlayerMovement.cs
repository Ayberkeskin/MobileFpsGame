using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] InputData input;
    [Header("Player Control Settings")]
    [SerializeField] private float _walkSpeed = 8f;
    [SerializeField] private float _runSpeed = 12f;
    [SerializeField] private float _rotateSpeed = 30f;
    [SerializeField] private float _gravityModifer = 0.95f;
    [SerializeField] float _maxViewAngle = 40f;

    private CharacterController _characterController;

    private float _currentSpeed = 8f;
    private Vector3 _heightMovement;
    private Transform _mainCamera;



    private void Awake()
    {
        _characterController = GetComponent<CharacterController>();
        if (Camera.main.GetComponent<CameraController>() == null)
        {
            Camera.main.gameObject.AddComponent<CameraController>();
        }
        _mainCamera = GameObject.FindWithTag("CameraPoint").transform;
    }

    private void FixedUpdate()
    {
        Move();
        Rotate();
    }


    private void Move()
    {
        _heightMovement.y -= _gravityModifer * Time.deltaTime;

        //Baktigin y�ne dogru gitmesi icin
        Vector3 localVerticalVector = transform.forward * input.Vertical;
        Vector3 localHorizontalVector = transform.right * input.Horizontal;
        Vector3 movmentVector = localHorizontalVector + localVerticalVector;

        movmentVector.Normalize();       // normal hiz 8 ise sag ust hiz 8.4 daha hizli onu esitledik hepsi 8
        movmentVector *= _currentSpeed * Time.deltaTime;

        _characterController.Move(movmentVector + _heightMovement);

        if (_characterController.isGrounded)
        {
            _heightMovement.y = 0f;
        }
    }

    private void Rotate()
    {
        // Calculate the rotation angles based on input and rotation speed
        float rotationX = -input.RotateDirection.z * _rotateSpeed * Time.deltaTime;
        float rotationY = input.RotateDirection.x * _rotateSpeed * Time.deltaTime;

        // Apply the rotation
        transform.Rotate(rotationX, rotationY, 0f, Space.Self);

        // Clamp the X rotation between -60 and 60 degrees
        float currentRotationX = transform.localEulerAngles.x;
        if (currentRotationX > 180f)
            currentRotationX -= 360f;

        float clampedRotationX = Mathf.Clamp(currentRotationX, -_maxViewAngle, _maxViewAngle);

        // Apply the clamped rotation
        transform.localRotation = Quaternion.Euler(clampedRotationX, transform.localEulerAngles.y, 0f);
    }
}
