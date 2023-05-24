using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] Image healthBar;
    [SerializeField] float decreaseSpeed;
    float healthBarInstance = 1f;

    private Camera cam;

    void Start()
    {
        cam = Camera.main;
        
    }


    void Update()
    {
        healthBar.fillAmount = Mathf.MoveTowards(healthBar.fillAmount,healthBarInstance,decreaseSpeed*Time.deltaTime);
        transform.rotation = cam.transform.rotation;
    }

    public void HealthBarProgress(float currentHealth,float maxHealth)
    {
        healthBarInstance = currentHealth / maxHealth;
        transform.gameObject.SetActive(true);
    }

}
