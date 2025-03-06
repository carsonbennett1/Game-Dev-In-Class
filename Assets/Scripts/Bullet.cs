using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject explosionParticle;

    public void Start()
    {
        if (AudioManager.instance != null)
        {
            AudioManager.instance.PlaySound(AudioManager.instance.shootClip);
        }
    }
    public void OnCollisionEnter(Collision collision)
    {
        if (AudioManager.instance != null)
        {
            AudioManager.instance.PlaySound(AudioManager.instance.explosionClip);
        }
    
        Instantiate(explosionParticle, transform.position, transform.rotation);
    
        Destroy(gameObject);

        if (collision.gameObject.CompareTag("Asteroid"))
        {
            Destroy(collision.gameObject);
        }
    }

    // handling bullet shooting

    public static void FireBullet(GameObject bulletPrefab, Transform SpawnPoint, float speed)
    {
        GameObject bullet = Instantiate(bulletPrefab, SpawnPoint.position, SpawnPoint.rotation);
        Rigidbody bulletRigidbody = bullet.GetComponent<Rigidbody>();
        bulletRigidbody.AddForce(SpawnPoint.forward * speed);
        Destroy(bullet, 4);
    }
}