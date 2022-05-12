using Photon.Pun;
using Saving;
using UnityEngine;

namespace Photon
{
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

            PlayerDetails.SetPlayerDetails(
                PhotonNetwork.LocalPlayer.ActorNumber,
                PhotonNetwork.LocalPlayer.NickName,
                (int) PhotonNetwork.LocalPlayer.CustomProperties["playerAvatar"],
                PhotonNetwork.CurrentRoom.Name);
        
            PlayerDetails.LogPlayerDetails();
        }
    }
}
