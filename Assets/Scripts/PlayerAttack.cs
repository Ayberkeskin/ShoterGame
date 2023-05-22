using UnityEngine.InputSystem;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    #region Setup
    PlayerMovment playerMovment;
    private PlayerInput playerInput;
    #endregion

    #region Holster Variables
    [Header("Holster Settings")]
    bool isHolsterPressed = false;
    [SerializeField] float holsterSpeed;
    [SerializeField] Transform leftArm;
    [SerializeField] Transform rightArm;
    #endregion

    #region FÝre Variables
    bool isFirePressed = false;
    [SerializeField] float fireRate;
    [SerializeField] float recoilSpeed;
    [SerializeField] float returnSpeed;
    float nextFire;
    float delay;
    Vector3 targetPos=new Vector3(0,0.3f,-.5f);
    Vector3 basePos = new Vector3(0,0.3f, 0);
    #endregion
    private void Awake()
    {
        //Input Reference
        playerMovment = new PlayerMovment();
        playerInput = new PlayerInput();
        //Holster Listeners
        playerInput.PlayerController.Holster.started += OnHolster;
        playerInput.PlayerController.Holster.canceled += OnHolster;
        //Fire Listeners
        playerInput.PlayerController.Fire.started += OnFÝre;
        playerInput.PlayerController.Fire.canceled += OnFÝre;
    }
    private void Update()
    {
        delay = fireRate / 2;
    }
    private void FixedUpdate()
    {
        PullGun();
        Shoot();
    }

    // input controllerdan gelen deðeri okuyuor ve isHolsterPressed true yapýyor
    private void OnHolster(InputAction.CallbackContext context)
    {
        isHolsterPressed = context.ReadValueAsButton();
    }
    private void OnFÝre(InputAction.CallbackContext context)
    {
        isFirePressed = context.ReadValueAsButton();
    }
    //Pull Gun
    private void PullGun()
    {
        if (isHolsterPressed)
        {
            leftArm.transform.localRotation = Quaternion.RotateTowards(leftArm.transform.localRotation, Quaternion.identity, holsterSpeed * 10 * Time.deltaTime);
            rightArm.transform.localRotation = Quaternion.RotateTowards(rightArm.transform.localRotation, Quaternion.identity, holsterSpeed * 10 * Time.deltaTime);
        }
        else
        {
            Quaternion targetPos = Quaternion.Euler(90, 0, 0);
            leftArm.transform.localRotation = Quaternion.RotateTowards(leftArm.transform.localRotation, targetPos, holsterSpeed * 10 * Time.deltaTime);
            rightArm.transform.localRotation = Quaternion.RotateTowards(rightArm.transform.localRotation, targetPos, holsterSpeed * 10 * Time.deltaTime);
        }
    }
    private void Shoot()
    {
        if ((isHolsterPressed&&isFirePressed)&&Time.time>nextFire)
        {
            nextFire = Time.time + fireRate;
            leftArm.transform.localPosition = Vector3.Lerp(leftArm.transform.localPosition, targetPos, recoilSpeed * Time.deltaTime);
            Invoke("RightArmInvoke", delay);
        }
        else
        {
            leftArm.transform.localPosition = Vector3.Lerp(leftArm.transform.localPosition, basePos, returnSpeed * Time.deltaTime);
            rightArm.transform.localPosition = Vector3.Lerp(rightArm.transform.localPosition, basePos, returnSpeed * Time.deltaTime);
        }
    }
    void RightArmInvoke()
    {
        rightArm.transform.localPosition = Vector3.Lerp(rightArm.transform.localPosition, targetPos, recoilSpeed * Time.deltaTime);
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
