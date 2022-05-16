using UnityEngine;
using UnityEngine.UI;

public class AnswerManager : MonoBehaviour
{
    private QuizHandler _quizHandlerManager;
    [SerializeField] private Color standardBtnColor;

    private Image btnImage;
    private void Start()
    {
        btnImage = GetComponent<Image>();
        _quizHandlerManager = GameObject.Find("QuizHandler").GetComponent<QuizHandler>();
        
        btnImage.color = standardBtnColor;
    }

    public void OnClickAnswerBtn()
    {
        if(!GetComponent<AnswerButton>().isCorrect)
            btnImage.color = Color.red;
        
        _quizHandlerManager.DisplayAnswers();
    }

}
