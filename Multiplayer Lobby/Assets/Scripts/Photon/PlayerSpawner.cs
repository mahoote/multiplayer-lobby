using Photon.Pun;
using Saving;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Photon
{
    public class PlayerSpawner : MonoBehaviour
    {
        [SerializeField] private TMP_Text playerNameTxt;
        [SerializeField] private Image playerAvatarImage;
        [SerializeField] private TMP_Text roomCodeTxt;

        [SerializeField] private Sprite[] avatarSprites;
        
        
        private void Start()
        {
            PlayerDetails.SetPlayerDetails(
                PhotonNetwork.LocalPlayer.ActorNumber,
                PhotonNetwork.LocalPlayer.NickName,
                (int) PhotonNetwork.LocalPlayer.CustomProperties["playerAvatar"],
                PhotonNetwork.CurrentRoom.Name);
        
            PlayerDetails.LogPlayerDetails();

            playerAvatarImage.sprite = avatarSprites[PlayerPrefs.GetInt("avatarIndex")];
            playerNameTxt.text = PlayerPrefs.GetString("nickname");
            roomCodeTxt.text = $"Room code: {PlayerPrefs.GetString("sessionId")}";
        }

        public void OnClickTakeQuiz()
        {
            PhotonNetwork.AutomaticallySyncScene = false;
            SceneManager.LoadScene("Quiz");
        }
    }
}
