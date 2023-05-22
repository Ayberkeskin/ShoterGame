using UnityEngine.InputSystem;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    #region Setup
    PlayerMovment playerMovment;
    private PlayerInput playerInput;
    #endregion

    #region Attack Variables
    bool isHolsterPressed = false;
    [SerializeField] float holsterSpeed;
    [SerializeField] Transform arm;
    #endregion
    private void Awake()
    {
        //Input Reference
        playerMovment = new PlayerMovment();
        playerInput = new PlayerInput();
        //Holster Listeners
        playerInput.PlayerController.Holster.started += OnHolster;
        playerInput.PlayerController.Holster.canceled += OnHolster;
    }
    private void FixedUpdate()
    {
        PullGun();
    }

    // input controllerdan gelen deðeri okuyuor ve isHolsterPressed true yapýyor
    private void OnHolster(InputAction.CallbackContext context)
    {
        isHolsterPressed = context.ReadValueAsButton();
    }
    //Pull Gun
    private void PullGun()
    {
        if (isHolsterPressed)
        {
            arm.transform.localRotation = Quaternion.RotateTowards(arm.transform.localRotation, Quaternion.identity, holsterSpeed * 10 * Time.deltaTime);
        }
        else
        {
            Quaternion targerPos = Quaternion.Euler(90, 0, 0);
            arm.transform.localRotation = Quaternion.RotateTowards(arm.transform.localRotation, targerPos, holsterSpeed * 10 * Time.deltaTime);

        }
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
