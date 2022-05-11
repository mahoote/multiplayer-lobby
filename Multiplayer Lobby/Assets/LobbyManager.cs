using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using Photon.Realtime;
using TMPro;
using UnityEngine;

public class LobbyManager : MonoBehaviourPunCallbacks
{

    public TMP_InputField roomInputField;
    public GameObject lobbyPanel;
    public GameObject roomPanel;
    public TMP_Text roomName;
    
    public RoomItem roomItemPrefab;
    private List<RoomItem> roomItemList = new List<RoomItem>();
    public Transform contentObject;

    public float timeBetweenUpdates = 1.5f;
    private float nextUpdateTime;

    // Start is called before the first frame update
    void Start()
    {
        PhotonNetwork.JoinLobby();
    }

    public void OnClickCreate()
    {
        if (roomInputField.text.Length >= 1)
        {
            PhotonNetwork.CreateRoom(roomInputField.text, new RoomOptions(){MaxPlayers = 3});
        }
    }

    public override void OnJoinedRoom()
    {
        lobbyPanel.SetActive(false);
        roomPanel.SetActive(true);
        roomName.text = "Room Name: " + PhotonNetwork.CurrentRoom.Name;
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
        print("Is called");
        
        foreach (var item in roomItemList)
        {
            Destroy(item.gameObject);
        }
        roomItemList.Clear();

        foreach (var room in list)
        {
            print(room.Name);
            
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
        PhotonNetwork.LeaveRoom();
    }

    public override void OnLeftRoom()
    {
        roomPanel.SetActive(false);
        lobbyPanel.SetActive(true);
    }

    public override void OnConnectedToMaster()
    {
        PhotonNetwork.JoinLobby();
    }
}
