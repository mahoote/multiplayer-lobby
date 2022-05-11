using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerSpawner : MonoBehaviour
{
    [SerializeField] private GameObject playerPrefab;
    [SerializeField] private Sprite[] avatarSprites; 
    
    private void Start()
    {
        GameObject playerToSpawn = playerPrefab;
        SetUserDetails(playerToSpawn);
        
        PhotonNetwork.Instantiate(playerToSpawn.name, Vector3.zero, Quaternion.identity);
    }

    private void SetUserDetails(GameObject playerToSpawn)
    {
        playerToSpawn.GetComponentInChildren<Image>().sprite =
            avatarSprites[(int) PhotonNetwork.LocalPlayer.CustomProperties["playerAvatar"]];
        playerToSpawn.GetComponentInChildren<TMP_Text>().text = PhotonNetwork.LocalPlayer.NickName;
    }
}
