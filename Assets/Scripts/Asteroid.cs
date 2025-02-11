using UnityEngine;

public class Asteroid : MonoBehaviour
{
    public int scoreValue = 10;

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Bullet"))
        {
            GameManager.Instance.AddScore(scoreValue);
            Destroy(gameObject); // destroys the asteroid
            Destroy(other.gameObject); // destroys the bullet
        }
    }

}

