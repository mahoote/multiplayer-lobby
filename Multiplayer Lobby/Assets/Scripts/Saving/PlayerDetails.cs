using System.Text;
using UnityEngine;

namespace Saving
{
    public static class PlayerDetails
    {
        public static void SetPlayerDetails(int id, string nickname, int avatarIndex, string sessionId)
        {
            PlayerPrefs.SetInt("playerId", id);
            PlayerPrefs.SetString("nickname", nickname);
            PlayerPrefs.SetInt("avatarIndex", avatarIndex);
            PlayerPrefs.SetString("sessionId", sessionId);

            PlayerPrefs.Save();
        }

        public static void LogPlayerDetails()
        {
            StringBuilder playerDetails = new StringBuilder();

            playerDetails.Append(PlayerPrefs.GetInt("playerId") + ", ");
            playerDetails.Append(PlayerPrefs.GetString("nickname") + ", ");
            playerDetails.Append(PlayerPrefs.GetInt("avatarIndex") + ", ");
            playerDetails.Append(PlayerPrefs.GetString("sessionId"));

            Debug.Log(playerDetails);
        }
    }
}
