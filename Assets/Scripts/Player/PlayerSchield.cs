using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerSchield : MonoBehaviour
{
    public Slider ShieldBar; 

    public GameObject shieldObject;
    public KeyCode activationKey = KeyCode.Q;
    private bool shieldActive = false;

    public float shieldDuration; 
    public float shieldCooldown;

    private float shieldTimer = 0f;
    private float cooldownTimer = 0f; 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(activationKey) && !shieldActive && cooldownTimer <= 0f)
        {
            ActivateShield();
        }

        if (shieldActive)
        {
            shieldTimer += Time.deltaTime;

            if (shieldTimer >= shieldDuration)
            {
                DeactivateShield();
            }
            else
            {
                ShieldBar.value = 100f - (shieldTimer / shieldDuration) * 100f;
            }
        }
        else if (cooldownTimer > 0f)
        {
            ShieldBar.value = (shieldCooldown - cooldownTimer) / shieldCooldown * 100f;
            cooldownTimer -= Time.deltaTime;
            if (cooldownTimer < 0f)
            {
                cooldownTimer = 0f;
                ShieldBar.value = 100f;
            }
        }
    }

    private void ActivateShield()
    {
        shieldObject.SetActive(true);
        shieldActive = true;
        shieldTimer = 0f;
    }

    private void DeactivateShield()
    {
        shieldObject.SetActive(false);
        shieldActive = false;
        cooldownTimer = shieldCooldown;
    }

}

