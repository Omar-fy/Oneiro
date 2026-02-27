using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Voids : MonoBehaviour
{

    private int value;
    
    // Start is called before the first frame update
    void Start()
    {
        value = 1;
    }

   

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        Destroy(gameObject);
        ItemCollector.instance.IncreaseVoids(value);
    }


}
