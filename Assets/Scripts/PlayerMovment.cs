using UnityEngine;
using UnityEngine.InputSystem;
using Cinemachine;

public class PlayerMovment : MonoBehaviour
{
    #region Setup
    Rigidbody rb;
    [SerializeField] private CinemachineVirtualCamera virtualCamera;
    private PlayerInput playerInput;
    #endregion

    #region Movment Variables
    [Header("Player Movment Settings")]
    Vector2 movementInput;
    Vector3 currentMovement,toIso;
    bool isMovementPressed, isRunPressed;
    [SerializeField] private float walkSpeed, runSpeed, turnspeed;
    #endregion

    #region Camera Zoom Variables
    [Header("Camera Zoom Settings")]
    float zoomInput;
    [SerializeField] float zoomAmount;
    private float minZoom = 1f;
    private float maxZoom = 6f;
    #endregion

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
        //ZOOM
        playerInput.CameraController.Zoom.performed += OnZoom;
    }
    private void FixedUpdate()
    {
        PlayerMove();
    }
    private void Update()
    {
        RotationProcess();
    }
    private void LateUpdate()
    {
        ZoomProcess();
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
    //Zoom Camera
    private void ZoomProcess()
    {
        if (zoomInput>0)
        {
            virtualCamera.m_Lens.OrthographicSize -= zoomAmount*Time.deltaTime;
        }
        else if (zoomInput<0)
        {
            virtualCamera.m_Lens.OrthographicSize += zoomAmount * Time.deltaTime;
        }
        virtualCamera.m_Lens.OrthographicSize = Mathf.Clamp(virtualCamera.m_Lens.OrthographicSize,minZoom,maxZoom);
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
    //ZOOM
    private void OnZoom(InputAction.CallbackContext context)
    {
        zoomInput = context.ReadValue<float>();
    }

    private void OnEnable()
    {
        playerInput.PlayerController.Enable();
        playerInput.CameraController.Enable();
    }

    private void OnDisable()
    {
        playerInput.PlayerController.Disable();
        playerInput.CameraController.Disable();
    }
}
