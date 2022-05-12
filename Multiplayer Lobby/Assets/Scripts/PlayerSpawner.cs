using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] playerPrefabs;
    [SerializeField] private Sprite[] playerAvatars;
    
    /** TODO:
         * Do not reset images when new player joins.
         * Show name.
         * Find another way of printing avatars than using prefabs.
    **/
    private void Start()
    {
        GameObject playerToSpawn = playerPrefabs[(int) PhotonNetwork.LocalPlayer.CustomProperties["playerAvatar"]];
        PhotonNetwork.Instantiate(playerToSpawn.name, Vector3.zero, Quaternion.identity);

        PlayerEntity.id = PhotonNetwork.LocalPlayer.ActorNumber;
        PlayerEntity.avatar = playerAvatars[(int) PhotonNetwork.LocalPlayer.CustomProperties["playerAvatar"]];
        PlayerEntity.nickName = PhotonNetwork.LocalPlayer.NickName;
        PlayerEntity.sessionId = PhotonNetwork.CurrentRoom.Name;
        
        Debug.Log(PlayerEntity.id);
        Debug.Log(PlayerEntity.nickName);
        Debug.Log(PlayerEntity.sessionId);
        Debug.Log(PlayerEntity.avatar);
    }
}
