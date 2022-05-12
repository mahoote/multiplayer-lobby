using UnityEngine;
using UnityEngine.UI;

public class AnswerManager : MonoBehaviour
{
    private JsonToQuiz quizManager;
    [SerializeField] private Color standardBtnColor;

    private Image btnImage;
    private void Start()
    {
        btnImage = GetComponent<Image>();
        quizManager = GameObject.Find("QuizHandler").GetComponent<JsonToQuiz>();
        
        btnImage.color = standardBtnColor;
    }

    public void OnClickAnswerBtn()
    {
        if(!GetComponent<AnswerButton>().isCorrect)
            btnImage.color = Color.red;
        
        quizManager.DisplayAnswers();
    }

}
