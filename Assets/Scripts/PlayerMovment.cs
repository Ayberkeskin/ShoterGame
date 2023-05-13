using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovment : MonoBehaviour
{
    private PlayerInput playerInput;
    [SerializeField] private float walkSpeed,runSpeed;

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
        playerInput.PlayerController.Movement.started += Move;
        playerInput.PlayerController.Movement.performed += Move;
        playerInput.PlayerController.Movement.canceled += Move;
        //RUN
        playerInput.PlayerController.Run.started += Run;
        playerInput.PlayerController.Run.canceled += Run;
    }
    private void FixedUpdate()
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

    //WALK
    private void Move(InputAction.CallbackContext context)
    {
        movementInput = context.ReadValue<Vector2>();

        currentMovement.x = movementInput.x;
        currentMovement.z = movementInput.y;
        isMovementPressed = movementInput.x != 0 || movementInput.y != 0;
    }

    private void Run(InputAction.CallbackContext context)
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
