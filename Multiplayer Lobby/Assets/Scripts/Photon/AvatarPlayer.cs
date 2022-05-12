using UnityEngine;

namespace Photon
{
    public class AvatarPlayer : MonoBehaviour
    {
        private GameObject parent;

        private void Awake()
        {
            parent = GameObject.Find("PlayerListParent");
            gameObject.transform.parent = parent.transform;
        }
    }
}
