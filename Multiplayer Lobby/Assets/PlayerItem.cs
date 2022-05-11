using System;
using Photon.Realtime;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerItem : MonoBehaviour
{
    public TMP_Text playerName; 
    public Image backgroundImage;
    public Color highlightColor;
    public GameObject leftArrowButton;
    public GameObject rightArrowButton;

    public void SetPlayerInfo(Player _player)
    {
        playerName.text = _player.NickName;
    }

    public void ApplyLocalChanges()
    {
        backgroundImage.color = highlightColor;
        leftArrowButton.SetActive(true);
        rightArrowButton.SetActive(true);
    }
}
