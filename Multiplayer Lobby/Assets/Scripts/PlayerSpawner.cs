using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] playerPrefabs;
    
    /** TODO:
         * Do not reset images when new player joins.
         * Show name.
         * Find another way of printing avatars than using prefabs.
    **/
    private void Start()
    {
        GameObject playerToSpawn = playerPrefabs[(int) PhotonNetwork.LocalPlayer.CustomProperties["playerAvatar"]];
        PhotonNetwork.Instantiate(playerToSpawn.name, Vector3.zero, Quaternion.identity);
    }
}
