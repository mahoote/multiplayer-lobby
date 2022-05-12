using Photon.Pun;
using Photon.Realtime;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Photon
{
    public class PlayerItem : MonoBehaviourPunCallbacks
    {
        public TMP_Text playerName; 
        public Image backgroundImage;
        public Color highlightColor;
        public GameObject leftArrowButton;
        public GameObject rightArrowButton;

        private ExitGames.Client.Photon.Hashtable playerProperties = new ExitGames.Client.Photon.Hashtable();
        public Image playerAvatar;
        public Sprite[] avatars;

        [HideInInspector] public int index;
        private Player player;

        public void SetPlayerInfo(Player _player)
        {
            playerName.text = _player.NickName;
            player = _player;
            index = player.ActorNumber;
            UpdatePlayerItem(player);
        }

        public void ApplyLocalChanges()
        {
            backgroundImage.color = highlightColor;
            leftArrowButton.SetActive(true);
            rightArrowButton.SetActive(true);
        }

        public void OnClickLeftArrow()
        {
            if ((int)playerProperties["playerAvatar"] == 0)
            {
                playerProperties["playerAvatar"] = avatars.Length - 1;
            }
            else
            {
                playerProperties["playerAvatar"] = (int) playerProperties["playerAvatar"] - 1;
            }
            PhotonNetwork.SetPlayerCustomProperties(playerProperties);
        }

        public void OnClickRightArrow()
        {
            if ((int)playerProperties["playerAvatar"] == avatars.Length - 1)
            {
                playerProperties["playerAvatar"] = 0;
            }
            else
            {
                playerProperties["playerAvatar"] = (int) playerProperties["playerAvatar"] + 1;
            }

            PhotonNetwork.SetPlayerCustomProperties(playerProperties);
        }

        public override void OnPlayerPropertiesUpdate(Player targetPlayer, ExitGames.Client.Photon.Hashtable hashtable)
        {
            if (player == targetPlayer)
            {
                UpdatePlayerItem(targetPlayer);
            }
        }

        private void UpdatePlayerItem(Player player)
        {
            if (player.CustomProperties.ContainsKey("playerAvatar"))
            {
                playerAvatar.sprite = avatars[(int) player.CustomProperties["playerAvatar"]];
                playerProperties["playerAvatar"] = (int) player.CustomProperties["playerAvatar"];
            }
            else
            {
                playerProperties["playerAvatar"] = 0;
                PhotonNetwork.SetPlayerCustomProperties(playerProperties);
            }
        }
    }
}