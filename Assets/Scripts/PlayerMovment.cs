using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovment : MonoBehaviour
{
    private PlayerInput playerInput;
    [SerializeField] private float walkSpeed,runSpeed, turnspeed;

    Vector2 movementInput;
    Vector3 currentMovement;
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
            rb.MovePosition(transform.position + currentMovement.normalized * walkSpeed * Time.fixedDeltaTime);
        }
        else
        {
            rb.MovePosition(transform.position + currentMovement.normalized * runSpeed * Time.fixedDeltaTime);
        }
            }
    // Player Rotation
    private void RotationProcess()
    {
        if (!isMovementPressed) return;
        Quaternion targetRotation = Quaternion.LookRotation(currentMovement,Vector3.up);
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
