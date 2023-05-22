using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovment : MonoBehaviour
{
    private PlayerInput playerInput;
    [SerializeField] private float walkSpeed,runSpeed, turnspeed;

    Vector2 movementInput;
    Vector3 currentMovement,toIso;
    bool isMovementPressed,isRunPressed;

    Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Awake()
    {
        playerInput = new PlayerInput();
        //WALK
        playerInput.PlayerController.Movement.started += OnMove;
        playerInput.PlayerController.Movement.performed += OnMove;
        playerInput.PlayerController.Movement.canceled += OnMove;
        //RUN
        playerInput.PlayerController.Run.started += OnRun;
        playerInput.PlayerController.Run.canceled += OnRun;
    }
    private void FixedUpdate()
    {
        PlayerMove();
    }
    private void Update()
    {
        RotationProcess();
    }
    //Player Move
    private void PlayerMove()
    {
        if (!isRunPressed)
        {
            rb.MovePosition(transform.position + toIso * currentMovement.normalized.magnitude * walkSpeed * Time.fixedDeltaTime);
        }
        else
        {
            rb.MovePosition(transform.position + toIso * currentMovement.normalized.magnitude * runSpeed * Time.fixedDeltaTime);
        }
            }
    // Player Rotation
    private void RotationProcess()
    {
        Quaternion isoAngle = Quaternion.Euler(0, 45, 0);
        Matrix4x4 isoMatrix = Matrix4x4.Rotate(isoAngle);
        toIso = isoMatrix.MultiplyPoint3x4(currentMovement);


        if (!isMovementPressed) return;
        Quaternion targetRotation = Quaternion.LookRotation(toIso, Vector3.up);
        transform.rotation = Quaternion.RotateTowards(transform.rotation,targetRotation,turnspeed*Time.deltaTime);
    }

    //WALK
    private void OnMove(InputAction.CallbackContext context)
    {
        movementInput = context.ReadValue<Vector2>();

        currentMovement.x = movementInput.x;
        currentMovement.z = movementInput.y;
        isMovementPressed = movementInput.x != 0 || movementInput.y != 0;
    }
    //RUN
    private void OnRun(InputAction.CallbackContext context)
    {
        isRunPressed = context.ReadValueAsButton();
    }

    private void OnEnable()
    {
        playerInput.PlayerController.Enable();
    }

    private void OnDisable()
    {
        playerInput.PlayerController.Disable();
    }
}
