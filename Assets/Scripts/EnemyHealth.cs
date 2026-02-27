using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class EnemyHealth : MonoBehaviour
{
    public Image healthBar;
    public float healthAmount;
    private Animator anim;
    private bool dead;




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
            anim.SetTrigger("Hurt");
        }

        else
        {
            if (!dead)
            {
                anim.SetTrigger("Die");


                if (GetComponentInParent<EnemyPatrol>() != null)
                    GetComponentInParent<EnemyPatrol>().enabled = false;
                anim.SetTrigger("Die");

                if (GetComponentInParent<EnemyPatrol2>() != null)
                    GetComponentInParent<EnemyPatrol2>().enabled = false;
                anim.SetTrigger("Die");

                if (GetComponent<MeleeEnemy>() != null)
                    GetComponent<MeleeEnemy>().enabled = false;
                anim.SetTrigger("Die");
                Destroy(gameObject);

                dead = true;
            }

        }


    }
}