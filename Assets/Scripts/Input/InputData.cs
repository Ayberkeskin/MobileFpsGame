using UnityEngine;

[CreateAssetMenu(menuName = "Input Data")]
public class InputData : ScriptableObject
{
    [Header("Motion input")]
    [SerializeField] float moveHorizontal;
    [SerializeField] float moveVertical;
    [SerializeField] Vector3 moveDirection;
    [SerializeField] bool moevHasInput;

    [Header("Rotate input")]
    [SerializeField] float rotateHorizontal;
    [SerializeField] float rotateVertical;
    [SerializeField] Vector3 rotateDirection;
    [SerializeField] bool rotateHasInput;

    //Move
    public float Horizontal { get => moveHorizontal; set => moveHorizontal = value; }
    public float Vertical { get => moveVertical; set => moveVertical = value; }
    public Vector3 Direction { get => moveDirection; set => moveDirection = value; }
    public bool HasInput { get => moevHasInput; set => moevHasInput = value; }

    //Rotate
    public float RotateHorizontal { get => rotateHorizontal; set => rotateHorizontal = value; }
    public float RotateVertical { get => rotateVertical; set => rotateVertical = value; }
    public Vector3 RotateDirection { get => rotateDirection; set => rotateDirection = value; }
    public bool RotateHasInput { get => rotateHasInput; set => rotateHasInput = value; }
}
