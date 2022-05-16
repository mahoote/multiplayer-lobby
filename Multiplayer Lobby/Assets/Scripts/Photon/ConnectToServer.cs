using System;
using Photon.Pun;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Photon
{
    public class ConnectToServer : MonoBehaviourPunCallbacks
    {
        public TMP_InputField createNameInput;
        public TMP_InputField joinNameInput;
        public TMP_InputField groupCodeInput;
        public TMP_Text buttonText;

        public void OnClickConnect(bool createGroup)
        {
            if (createNameInput.text.Length >= 1 && createGroup)
            {
                PlayerPrefs.SetInt("CreateGroup", 1);
                ConnectToPhoton(createNameInput.text);
            } 
            else if (joinNameInput.text.Length >= 1 && groupCodeInput.text.Length >= 1)
            {
                PlayerPrefs.SetInt("CreateGroup", 0);
                PlayerPrefs.SetString("GroupCode", groupCodeInput.text);
                ConnectToPhoton(joinNameInput.text);
            }
        }

        private void ConnectToPhoton(string nickname)
        {
            PhotonNetwork.NickName = nickname;
            buttonText.text = "Connecting...";
            PhotonNetwork.AutomaticallySyncScene = true;
            PhotonNetwork.ConnectUsingSettings();
        }

        public override void OnConnectedToMaster()
        {
            SceneManager.LoadScene("Lobby");
        }
    }
}
