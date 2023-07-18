using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    [SerializeField] private VariableJoystick moveJoystick;
    [SerializeField] private VariableJoystick rotateJoystick;
    [SerializeField] private InputData input;

    private void Update()
    {
        MoveInput();
        RotateInput();
    }


    private void MoveInput()
    {
        input.Horizontal = moveJoystick.Horizontal;
        input.Vertical = moveJoystick.Vertical;
        input.Direction = new Vector3(input.Horizontal, 0, input.Vertical);
        input.HasInput = (input.Direction.sqrMagnitude > 0f ? true : false);
    }

    private void RotateInput()
    {
        
        input.RotateHorizontal = rotateJoystick.Horizontal;
        input.RotateVertical = rotateJoystick.Vertical;
        input.RotateDirection = new Vector3(input.RotateHorizontal, 0, input.RotateVertical);
        input.RotateHasInput = (input.RotateDirection.sqrMagnitude > 0f ? true : false);
    }
}
