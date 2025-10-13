using UnityEngine;
using TMPro;
using System.Collections.ObjectModel;
using UnityEngine.InputSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using JetBrains.Annotations;
using Unity.Cinemachine;

public class Dialogue : MonoBehaviour
{
    public TextMeshProUGUI textComponent;
    public string[] lines;
    public float textSpeed;
    public Button Next;
    public Button Back;
    private PlayerController canMove;
    private Rigidbody2D rb;
    private Animator an;
    public Interact Move;
    
    private int index;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        textComponent.text = string.Empty;
        StartDialogue();
    }

    void Awake()
    {
        canMove = GameObject.Find("Player").GetComponent<PlayerController>();
        rb = GameObject.Find("Player").GetComponent<Rigidbody2D>();
        an = GameObject.Find("GFX").GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {

        

    }
    public void OpenDialogue()
    {
        StopAllCoroutines();
        index = 0;
        textComponent.text = lines[index];
        StartCoroutine(TypeLine());
        gameObject.SetActive(true);
        canMove.enabled = false;
        rb.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezePositionY | RigidbodyConstraints2D.FreezeRotation;
        an.enabled = false;
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
                canMove.enabled = true;
                rb.constraints = RigidbodyConstraints2D.None | RigidbodyConstraints2D.FreezeRotation;
                an.enabled = true;

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
