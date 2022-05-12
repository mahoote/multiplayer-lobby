using TMPro;
using UnityEngine;

namespace Photon
{
    public class RoomItem : MonoBehaviour
    {
        public TMP_Text roomName;
        private LobbyManager manager;

        private void Start()
        {
            manager = FindObjectOfType<LobbyManager>();
        }

        public void SetRoomName(string _roomName)
        {
            this.roomName.text = _roomName;
        }

        public void OnClickItem()
        {
            manager.JoinRoom(roomName.text);
        }
    }
}
