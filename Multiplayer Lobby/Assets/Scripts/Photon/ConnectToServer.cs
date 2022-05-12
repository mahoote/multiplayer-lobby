using Photon.Pun;
using TMPro;
using UnityEngine.SceneManagement;

namespace Photon
{
    public class ConnectToServer : MonoBehaviourPunCallbacks
    {
        public TMP_InputField usernameInput;
        public TMP_Text buttonText;

        public void OnClickConnect()
        {
            if (usernameInput.text.Length >= 1)
            {
                PhotonNetwork.NickName = usernameInput.text;
                buttonText.text = "Connecting...";
                PhotonNetwork.AutomaticallySyncScene = true;
                PhotonNetwork.ConnectUsingSettings();
            }
        }

        public override void OnConnectedToMaster()
        {
            SceneManager.LoadScene("Lobby");
        }
    }
}
