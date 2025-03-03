using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject explosionParticle;
public void OnCollisionEnter(Collision collision)
{
    Instantiate(explosionParticle, transform.position, transform.rotation);
    
    Destroy(gameObject);

    if(collision.gameObject.tag == "Asteroid")
    {
        Destroy(collision.gameObject);
    }
}
}