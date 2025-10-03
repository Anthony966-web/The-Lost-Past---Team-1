using UnityEngine;
using TMPro;
using System.Collections.ObjectModel;
using UnityEngine.InputSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
public class Dialogue : MonoBehaviour
{
    public TextMeshProUGUI textComponent;
    public string[] lines;
    public float textSpeed;
    public Button Next;
    public Button Back;

    private int index;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        textComponent.text = string.Empty;
        StartDialogue();
    }

    // Update is called once per frame
    void Update()
    {

        

    }

    void StartDialogue()
    {
        index = 0;
        StartCoroutine(TypeLine());
    }   
    IEnumerator TypeLine()
    {
        foreach (char c in lines[index].ToCharArray())
        {
            textComponent.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }
    public void NextLine(bool next)
    {
        StopAllCoroutines();
        textComponent.text = lines[index];
        
        if (next)
        {
            if (index < lines.Length - 1)
            {
                index++;
                textComponent.text = string.Empty;
                StartCoroutine(TypeLine());
            }
            else
            {
                gameObject.SetActive(false);
            }
        }
        else
        {
            if (index == lines.Length - 1)
            {
                index--;
                textComponent.text = string.Empty;
                StartCoroutine(TypeLine());
            }
        }

    }
    //public void BackLine()
    //{
    //    if (index >= lines.Length - 1)
    //    {
    //        index--;
    //        textComponent.text = string.Empty;
    //        StartCoroutine(TypeLine());
    //    }
    //}
}
