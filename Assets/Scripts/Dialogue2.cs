using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dialogue2 : MonoBehaviour
{
    public TextMeshProUGUI textDisplay;
    public string[] sentences;
    private int index;
    public float typingspeed;

    public GameObject continueButton;
    public GameObject DialogueManager;


    private void Start()
    {
        DialogueManager.SetActive(false);
    }

    private void Update()
    {

        if (textDisplay.text == sentences[index])
        {
            continueButton.SetActive(true);


        }

    }





    IEnumerator Type()
    {
        foreach (char letter in sentences[index].ToCharArray())
        {
            textDisplay.text += letter;
            yield return new WaitForSeconds(typingspeed);

        }

    }

    public void NextSentence()
    {
        continueButton.SetActive(false);

        if (index < sentences.Length - 1)
        {
            index++;
            textDisplay.text = "";
            StartCoroutine(Type());

        }
        else
        {
            textDisplay.text = "";
            continueButton.SetActive(false);
            DialogueManager.SetActive(false);
        }



    }
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Player")
        {
            DialogueManager.SetActive(true);
            StartCoroutine(Type());

        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        DialogueManager.SetActive(false);
        continueButton.SetActive(false);
        textDisplay.text = "";
        StopAllCoroutines();

    }



}
