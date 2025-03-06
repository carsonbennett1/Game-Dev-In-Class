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
}