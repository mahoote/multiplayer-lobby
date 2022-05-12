using System;
using TMPro;
using UnityEngine;

public class AnswerButton : MonoBehaviour
{
    public int questionId;
    public string answerName;
    public bool isCorrect;
    private TMP_Text answerTxt;
    
    private void Awake()
    {
        answerTxt = GetComponentInChildren<TMP_Text>();
        answerTxt.text = answerName;
    }
}
