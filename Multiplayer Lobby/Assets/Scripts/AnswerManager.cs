using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class AnswerManager : MonoBehaviour
{
    public void OnClickAnswerBtn()
    {
        var go = EventSystem.current.currentSelectedGameObject;
        var btnImage = go.GetComponent<Image>();
        
        btnImage.color = go.GetComponent<AnswerButton>().isCorrect ? Color.green : Color.red;
        
    }
}
