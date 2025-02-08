using UnityEngine;

public class Bullet : MonoBehaviour
{
public void OnCollisionEnter(Collision collision)
{
    Destroy(gameObject);

    if(collision.gameObject.tag == "Asteroid")
    {
        Destroy(collision.gameObject);
    }
}
}