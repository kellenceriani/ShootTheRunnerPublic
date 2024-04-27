using UnityEngine;

public class PlayerCollisionHandler : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        // Check if the collision involves the baseball projectile
        if (collision.gameObject.CompareTag("baseball"))
        {
            // Increase player hits
            EnemyProjectileLauncher launcher = FindObjectOfType<EnemyProjectileLauncher>();
            if (launcher != null)
            {
                launcher.IncreasePlayerHits();
            }
        }
    }
}
