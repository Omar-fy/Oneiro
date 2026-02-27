using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeHeadLvl5 : MonoBehaviour
{
    [Header("SpikeHead Attributes")]
    public GameObject player;
    public float speed;
    [SerializeField] protected float damage;
    private float distance;


    private void Update()
    {
        distance = Vector2.Distance(transform.position, player.transform.position);
        Vector2 direction = player.transform.position - transform.position;
        direction.Normalize();
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        if (distance < 12)
        {
            transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, speed * Time.deltaTime);
            //transform.rotation = Quaternion.Euler(Vector3.forward * angle);
        }


    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
            collision.GetComponent<PlayerHealth>().TakeDamage(damage);

    }
}
