using UnityEngine;

namespace YourNamespace // Replace "YourNamespace" with the appropriate namespace for your project
{
    public class XRPlatformRestriction : MonoBehaviour
    {
        [SerializeField]
        private Transform playerPlatform;

        [SerializeField]
        private Transform completeXROriginSetUp;

        private void Start()
        {
            // Make sure both PlayerPlatform and Complete XR Origin Set Up are assigned
            if (playerPlatform == null || completeXROriginSetUp == null)
            {
                Debug.LogError("PlayerPlatform or Complete XR Origin Set Up is not assigned!");
                return;
            }

            // Check if the Complete XR Origin Set Up is not on the PlayerPlatform
            if (!IsOnPlayerPlatform(completeXROriginSetUp))
            {
                Debug.LogWarning("Complete XR Origin Set Up is not on the PlayerPlatform!");
                // You can disable or move the Complete XR Origin Set Up to the PlayerPlatform here
            }
        }

        private bool IsOnPlayerPlatform(Transform objTransform)
        {
            // Get the position of the PlayerPlatform
            Vector3 playerPlatformPosition = playerPlatform.position;
            // Get the scale of the PlayerPlatform
            Vector3 playerPlatformScale = playerPlatform.localScale;

            // Get the position of the object
            Vector3 objPosition = objTransform.position;

            // Check if the object's position is within the bounds of the PlayerPlatform
            bool withinXBounds = objPosition.x >= playerPlatformPosition.x - playerPlatformScale.x / 2 &&
                                 objPosition.x <= playerPlatformPosition.x + playerPlatformScale.x / 2;
            bool withinYBounds = objPosition.y >= playerPlatformPosition.y - playerPlatformScale.y / 2 &&
                                 objPosition.y <= playerPlatformPosition.y + playerPlatformScale.y / 2;
            bool withinZBounds = objPosition.z >= playerPlatformPosition.z - playerPlatformScale.z / 2 &&
                                 objPosition.z <= playerPlatformPosition.z + playerPlatformScale.z / 2;

            return withinXBounds && withinYBounds && withinZBounds;
        }
    }
}
