using TMPro;
using UnityEngine;

public class JsonToQuiz : MonoBehaviour
{
    [SerializeField] private TextAsset jsonFile;
 
    [SerializeField] private TMP_Text questionNr;
    [SerializeField] private TMP_Text questionTxt;
    
    [SerializeField] private TMP_Text[] answersTxt;
    [SerializeField] private GameObject[] answerButtonObject;
 
    void Start()
    {
        Quiz quizInJson = JsonUtility.FromJson<Quiz>(jsonFile.text);

        var q = quizInJson.quiz[0];

        questionNr.text = $"Question {q.id}";
        questionTxt.text = $"{q.name}";

        for (int i = 0; i < q.answers.Length; i++)
        {
            if (q.answers[i] != null)
            {
                answerButtonObject[i].SetActive(true);
                answersTxt[i].text = q.answers[i];
            }
        }
    }
}
