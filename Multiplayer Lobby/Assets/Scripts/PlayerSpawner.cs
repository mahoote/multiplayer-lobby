using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] playerPrefabs;
    
    private void Start()
    {
        GameObject playerToSpawn = playerPrefabs[(int) PhotonNetwork.LocalPlayer.CustomProperties["playerAvatar"]];
        PhotonNetwork.Instantiate(playerToSpawn.name, Vector3.zero, Quaternion.identity);
    }
}
