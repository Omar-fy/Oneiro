using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{

    public Image healthBar;
    public float healthAmount;
    private Animator anim;
    private bool dead;

    public GameManagerScript gameManager;
    [SerializeField] private AudioSource hurtSFX;
    [SerializeField] private AudioSource deathSFX;

    private void Awake()
    {
        healthAmount = 100f;
        anim = GetComponent<Animator>(); 
    }





    public void TakeDamage(float damage)
    {
        healthAmount -= damage;
        healthBar.fillAmount = healthAmount / 100f;

        if (healthAmount > 0)
        {
            hurtSFX.Play();
            anim.SetTrigger("Hurt");
        }

        else
        {
            if (!dead)
            {
            

            if (GetComponent<PlayerMovement>() != null)
                GetComponent<PlayerMovement>().enabled = false;
                deathSFX.Play();
                anim.SetTrigger("Die");
                gameManager.delayedEnd();


                dead = true;
            }
            
        }
       

    }

  








}
