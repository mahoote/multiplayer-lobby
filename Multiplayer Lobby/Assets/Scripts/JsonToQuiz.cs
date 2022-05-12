using Photon.Pun;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class JsonToQuiz : MonoBehaviour
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

        foreach (var answer in q.answers)
        {
            var answerBtn = answerBtnPrefab;
         
            answerBtn.GetComponent<AnswerButton>().questionId = q.id;
            answerBtn.GetComponent<AnswerButton>().answerName = answer;
            answerBtn.GetComponent<AnswerButton>().isCorrect = false;
            
            Instantiate(answerBtn, buttonContainer.transform);
        }
    }
}
