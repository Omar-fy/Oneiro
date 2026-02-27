using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Boss_Health : MonoBehaviour
{

    public Image healthBar;
    public float healthAmount;
    private Animator anim;
    private bool dead;
    public GameObject PortalPreFab; 



    private void Awake()
    {
        healthAmount = 1000f;
        anim = GetComponent<Animator>();
    }





    public void TakeDamage(float damage)
    {
        healthAmount -= damage;
        healthBar.fillAmount = healthAmount / 1000f;

        if (healthAmount > 0)
        {
            anim.SetTrigger("Hurt");
        }

        else
        {
            if (!dead)
            {
               
                if (GetComponent<Boss>() != null)
                    GetComponent<Boss>().enabled = false;
                anim.SetTrigger("Die");
                Destroy(gameObject);
                Instantiate(PortalPreFab, transform.position, Quaternion.identity);
                dead = true;
            }

        }


    }





}
