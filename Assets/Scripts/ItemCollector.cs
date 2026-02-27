using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class ItemCollector : MonoBehaviour
{
    public static ItemCollector instance;


    private int collectible = 0;
    [SerializeField] private TextMeshProUGUI VoidsText;

    [SerializeField] private AudioSource voidSFX;
    private void Awake()
    {
        instance = this;
    }



    private void Start()
    {
   
        VoidsText.text = "VOIDS: " + collectible.ToString();
        
    }

    public void IncreaseVoids( int v)
    {
        collectible += v;
        VoidsText.text = "VOIDS: " + collectible.ToString();

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            voidSFX.Play();
            gameObject.SetActive(false);

            collectible = collectible + 1;
            


        }
    }



}
