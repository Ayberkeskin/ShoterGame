using UnityEngine.InputSystem;
using UnityEngine;
using System.Collections;

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
    [SerializeField] private float bulletDamage;
    bool isFirePressed = false;
    [SerializeField] float fireRate;
    [SerializeField] float recoilSpeed;
    [SerializeField] float returnSpeed;
    float nextFire;
    float delay;
    Vector3 targetPos=new Vector3(0,0.3f,-.2f);
    Vector3 basePos = new Vector3(0,0.3f, 0);
    #endregion

    #region Bullet
    [SerializeField] Transform spawnLeftPos;
    [SerializeField] Transform spawnRightPos;
    [SerializeField] float range;
    [SerializeField] LayerMask mask;
    [SerializeField] TrailRenderer bullet;
    [SerializeField] Vector3 randomiseBullet;

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
            StartCoroutine(Trigger());
        }
        else
        {
            leftArm.transform.localPosition = Vector3.Lerp(leftArm.transform.localPosition, basePos, returnSpeed * Time.deltaTime);
            rightArm.transform.localPosition = Vector3.Lerp(rightArm.transform.localPosition, basePos, returnSpeed * Time.deltaTime);
        }
    }
    IEnumerator Trigger()
    {
        Vector3 direction = BulletRecoil();
        leftArm.transform.localPosition = Vector3.Lerp(leftArm.transform.localPosition, targetPos, recoilSpeed * Time.deltaTime);

        if (Physics.Raycast(spawnLeftPos.position, direction, out RaycastHit hitLeft,range,mask))
        {
            TrailRenderer trailLeft = Instantiate(bullet, spawnLeftPos.position, Quaternion.identity);
            StartCoroutine(SpawnTrail(trailLeft,hitLeft));
        }

        yield return new WaitForSeconds(delay);


        rightArm.transform.localPosition = Vector3.Lerp(rightArm.transform.localPosition, targetPos, recoilSpeed * Time.deltaTime);

        if (Physics.Raycast(spawnRightPos.position, direction, out RaycastHit hitRight, range, mask))
        {
            TrailRenderer traiRight = Instantiate(bullet, spawnRightPos.position, Quaternion.identity);
            StartCoroutine(SpawnTrail(traiRight, hitRight));
        }
    }

    IEnumerator SpawnTrail(TrailRenderer trail,RaycastHit hit)
    {
        float time = 0;
        Vector3 starPos = trail.transform.position;

        while (time<1)
        {
            trail.transform.position = Vector3.Lerp(starPos, hit.point, time);
            time += Time.deltaTime / trail.time;
            yield return null;
        }

        Enemy enemy = hit.transform.GetComponent<Enemy>();

        if (enemy!=null)
        {
            enemy.TakeDamage(bulletDamage);
        }
        trail.transform.position = hit.point;
        Destroy(trail.gameObject, trail.time);
    }

    private Vector3 BulletRecoil()
    {
        Vector3 bulletDirectoin = transform.forward;

        bulletDirectoin += new Vector3(
            Random.Range(-randomiseBullet.x, randomiseBullet.x),
            Random.Range(-randomiseBullet.y, randomiseBullet.y),
            Random.Range(-randomiseBullet.z, randomiseBullet.z));
        bulletDirectoin.Normalize();
        return bulletDirectoin;
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
