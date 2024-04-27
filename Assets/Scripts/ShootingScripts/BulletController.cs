using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    [SerializeField] private GameObject stickyBullet;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("DoTheThing");
        Destroy(gameObject, 5f);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            EnemyStats enemyStats = collision.gameObject.GetComponent<EnemyStats>();

            if (enemyStats != null)
            {
                enemyStats.TakeDamage(1);
            }
            else
            {
                EnemyStatsTwo enemyStatsTwo = collision.gameObject.GetComponent<EnemyStatsTwo>();

                if (enemyStatsTwo != null)
                {
                    enemyStatsTwo.TakeDamage(1);
                }
                else
                {
                    BossStats bossStats = collision.gameObject.GetComponent<BossStats>();

                    if (bossStats != null)
                    {
                        bossStats.TakeDamage(1);
                    }
                    else
                    {
                        Debug.LogError("No enemy stats component found on the enemy GameObject.");
                    }
                }
            }

            GameObject sb = Instantiate(stickyBullet) as GameObject;
            ContactPoint contact = collision.contacts[0];
            sb.transform.position = contact.point;
            sb.transform.parent = collision.gameObject.transform;
            Destroy(gameObject);
        }
    }

    void Update()
    {
        // Update logic here
    }
}
