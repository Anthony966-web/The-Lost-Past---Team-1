using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine.UI;

public class Text_Boxes_Script : MonoBehaviour
{
    [Header("Prefabs")]
    [SerializeField] GameObject JustText;
    [SerializeField] GameObject TextandName;
    [SerializeField] GameObject TextNameandImage;
    Text_Boxes_Script ourText;
    Text_Boxes_Script ourTextName;
    Text_Boxes_Script ourTextNameFace;

    [Header("Referances")]
    TextMeshProUGUI boxText;
    TextMeshProUGUI boxName;
    RawImage boxFace;
    RawImage boxImage;
    RectTransform boxRectTransform;
    Text_Boxes_Script instance;
    Canvas Canvas;

    [Header("Textbox")]
    [SerializeField] Texture2D texture;

    [Header("Typing")]
    [SerializeField] float delayBeforeSpeaking;
    [SerializeField] float delayAfterSpeaking = 0;
    [SerializeField] float charDelay = 1;
    [SerializeField] float basecharDelay = -1;
    public bool isSpeaking;

    void Awake()
    {
        instance = this;
        boxText = transform.Find("Text").gameObject.GetComponent<TextMeshProUGUI>();
        boxName = transform.Find("Name").gameObject.GetComponent<TextMeshProUGUI>();
        boxFace = transform.Find("Face").gameObject.GetComponent<RawImage>();
    }
}
