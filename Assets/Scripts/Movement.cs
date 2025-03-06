using UnityEngine;

public class Movement : MonoBehaviour
{
    public float MoveForce;
    public float TurnTorque;
    public Rigidbody rocket;

    // public float MovementSpeed = 80.0f;

    public Transform bulletSpawnRef;
    public GameObject bulletPrefab;
    public float ShootForce;
    private bool isMoving = false;

    public GameObject flame;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        isMoving = false;
        if (InputManager.Instance.MoveUp)       
        {
            // transform.Translate(Vector3.forward * Time.deltaTime);    
            rocket.AddForce(transform.forward * MoveForce);
            isMoving = true;
        }
        
        if (InputManager.Instance.MoveDown)       
        {
           // transform.Translate(-1 * Vector3.forward * Time.deltaTime);    
            rocket.AddForce(-1 * transform.forward * MoveForce);
            isMoving = true;
        }

        if (InputManager.Instance.MoveRight)       
        {
            // transform.Translate(Vector3.right * Time.deltaTime);    
            rocket.AddForce(transform.right * MoveForce);
            isMoving = true;
        }

        if (InputManager.Instance.MoveLeft)       
        {
            // transform.Translate(-1 * Vector3.right * Time.deltaTime);    
            rocket.AddForce(-1 * transform.right * MoveForce);
            isMoving = true;
        }

        if (flame != null)
        {
            flame.SetActive(isMoving);
        }

        if (InputManager.Instance.IsRotating)       
        {
            // transform.Rotate(Vector3.up, horizontal * Time.deltaTime * MovementSpeed);
            // transform.Rotate(-1 * Vector3.right, vertical * Time.deltaTime * MovementSpeed);
            rocket.AddRelativeTorque(-1 * InputManager.Instance.VerticalLook * TurnTorque, InputManager.Instance.HorizontalLook * TurnTorque, 0);
        }
        
        if (isMoving)
        {
            if (AudioManager.instance != null)
            {
                AudioManager.instance.PlayMovementSound();
            }
        }
        else
        {
            if (AudioManager.instance != null)
            {
                AudioManager.instance.StopMovementSound();
            }
        }

        if (PauseMenu.isPaused)
        {
            return;
        }
        
        if (InputManager.Instance.IsShooting)       
        {
            Bullet.FireBullet(bulletPrefab, bulletSpawnRef, ShootForce);
        }
    }
}
