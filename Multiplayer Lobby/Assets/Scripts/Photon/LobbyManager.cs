using System;
using System.Collections.Generic;
using Photon.Pun;
using Photon.Realtime;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

namespace Photon
{
    public class LobbyManager : MonoBehaviourPunCallbacks
    {

        public GameObject loadingPanel, roomPanel, playButton;
        public TMP_Text roomName;
    
        public RoomItem roomItemPrefab;
        private List<RoomItem> roomItemList = new List<RoomItem>();
        public Transform contentObject;

        public float timeBetweenUpdates = 1.5f;
        private float nextUpdateTime;

        private List<PlayerItem> playerItemsList = new List<PlayerItem>();
        public PlayerItem playerItemPrefab;
        public Transform playerItemParent;

        [SerializeField] private int minPlayers = 2;
        [SerializeField] private byte maxPlayers = 20;

        [SerializeField] private bool createGroup;

        // Start is called before the first frame update
        void Start()
        {
            createGroup = Convert.ToBoolean(PlayerPrefs.GetInt("CreateGroup"));
            PhotonNetwork.JoinLobby();
        }

        private void Update()
        {
            if (PhotonNetwork.IsMasterClient && PhotonNetwork.CurrentRoom.PlayerCount >= minPlayers)
            {
                playButton.SetActive(true);
            }
            else
            {
                playButton.SetActive(false);
            }
        }

        public override void OnJoinedLobby()
        {
            if (createGroup)
            {
                var sessionIdInt = Random.Range(1000000, 9999999);
                var sessionIdString = sessionIdInt.ToString();
                var groupCode = sessionIdString.Insert(3, " ");
        
                OnClickCreate(groupCode);
            }
            else
            {
                // loadingPanel.SetActive(false);
                // lobbyPanel.SetActive(true);
                JoinRoom(PlayerPrefs.GetString("GroupCode"));
            }
        }

        public void OnClickCreate(string _roomName = "test")
        {
            // if (roomInputField.text.Length >= 1)
            // {
                PhotonNetwork.CreateRoom(_roomName, new RoomOptions(){MaxPlayers = maxPlayers, BroadcastPropsChangeToAll = true});
            // }
        }

        public override void OnJoinedRoom()
        {
            loadingPanel.SetActive(false);
            roomPanel.SetActive(true);
            roomName.text = "Your group code is:\n" + PhotonNetwork.CurrentRoom.Name;
            UpdatePlayerList();
        }

        public override void OnRoomListUpdate(List<RoomInfo> roomList)
        {
            if (Time.time >= nextUpdateTime)
            {
                UpdateRoomList(roomList);
                nextUpdateTime = Time.time + timeBetweenUpdates;
            }
        
        }

        void UpdateRoomList(List<RoomInfo> list)
        {
            foreach (var item in roomItemList)
            {
                Destroy(item.gameObject);
            }
            roomItemList.Clear();

            foreach (var room in list)
            {
                RoomItem newRoom = Instantiate(roomItemPrefab, contentObject);
                newRoom.SetRoomName(room.Name);
                roomItemList.Add(newRoom);
            }
        }
    
        public void JoinRoom(string _roomName)
        {
            PhotonNetwork.JoinRoom(_roomName);
        }

        public void OnClickLeaveRoom()
        {
            PhotonNetwork.Disconnect();
        }

        public override void OnDisconnected(DisconnectCause cause)
        {
            SceneManager.LoadScene("Main");
        }

        public override void OnConnectedToMaster()
        {
            PhotonNetwork.JoinLobby();
        }

        void UpdatePlayerList()
        {
            foreach (PlayerItem item in playerItemsList)
            {
                Destroy(item.gameObject);
            }
            playerItemsList.Clear();

            if (PhotonNetwork.CurrentRoom == null)
            {
                return;
            }

            foreach (KeyValuePair<int, Player> player in PhotonNetwork.CurrentRoom.Players)
            {
                PlayerItem newPlayerItem = Instantiate(playerItemPrefab, playerItemParent);
                newPlayerItem.SetPlayerInfo(player.Value);

                if (player.Value == PhotonNetwork.LocalPlayer)
                {
                    newPlayerItem.ApplyLocalChanges();
                }

                playerItemsList.Add(newPlayerItem);
            }
        }
    
        private void AddPlayerToList(Player newPlayer)
        {
            if (PhotonNetwork.CurrentRoom == null)
            {
                return;
            }

            PlayerItem newPlayerItem = Instantiate(playerItemPrefab, playerItemParent);
            newPlayerItem.SetPlayerInfo(newPlayer);
        
            if (newPlayer == PhotonNetwork.LocalPlayer)
            {
                newPlayerItem.ApplyLocalChanges();
            }

            newPlayerItem.index = newPlayer.ActorNumber;
        
            playerItemsList.Add(newPlayerItem);
        }
    
        private void RemovePlayerFromList(Player removedPlayer)
        {
            if (PhotonNetwork.CurrentRoom == null)
            {
                return;
            }

            foreach (var playerItem in playerItemsList)
            {
                if (playerItem.index == removedPlayer.ActorNumber)
                {
                    Destroy(playerItem.gameObject);
                    playerItemsList.Remove(playerItem);
                    return;
                }
            }
        }
    
        public override void OnPlayerEnteredRoom(Player newPlayer)
        {
            AddPlayerToList(newPlayer);
        }

        public override void OnPlayerLeftRoom(Player otherPlayer)
        {
            RemovePlayerFromList(otherPlayer);
        }

        public void OnClickPlayButton()
        {
            PhotonNetwork.LoadLevel("Game");
        }
    }
}
