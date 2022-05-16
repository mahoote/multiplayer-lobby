using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class QuizHandler : MonoBehaviour
{
    [SerializeField] private TextAsset jsonFile;
    
    [SerializeField] private TMP_Text questionNr;
    [SerializeField] private TMP_Text questionTxt;
    [SerializeField] private GameObject buttonContainer;
    [SerializeField] private GameObject answerBtnPrefab;
    
    void Start()
    {
     
        Quiz quizInJson = JsonUtility.FromJson<Quiz>(jsonFile.text);

        var q = quizInJson.quiz[0];

        questionNr.text = $"Question {q.id}";
        questionTxt.text = $"{q.name}";

        for (int i = 0; i < q.answers.Length; i++)
        {
            var answerBtn = answerBtnPrefab;
            var correctAnswer = q.correct_answer == i;

            answerBtn.GetComponent<AnswerButton>().questionId = q.id;
            answerBtn.GetComponent<AnswerButton>().answerName = q.answers[i];
            answerBtn.GetComponent<AnswerButton>().isCorrect = correctAnswer;
            
            Instantiate(answerBtn, buttonContainer.transform);
        }
    }

    public void DisplayAnswers()
    {
        foreach (Transform child in buttonContainer.transform)
        {
            var button = child.gameObject;
            
            if(button.GetComponent<AnswerButton>().isCorrect)
                button.GetComponent<Image>().color = Color.green;
        }
        
        foreach (var manager in buttonContainer.GetComponentsInChildren<AnswerManager>())
        {
            Destroy(manager);
        }
        
    }
}
