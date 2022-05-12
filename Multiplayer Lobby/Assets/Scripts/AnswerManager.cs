using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class AnswerManager : MonoBehaviour
{
    public void OnClickAnswerBtn()
    {
        var go = EventSystem.current.currentSelectedGameObject;
        var answerText = go.GetComponent<TMP_Text>().text;

        
    }
}
