using UnityEngine;

public class Movement : MonoBehaviour
{
    public float MoveForce;
    public float TurnTorque;
    public Rigidbody rocket;

    // public float MovementSpeed = 80.0f;
    public float horizontal;
    public float vertical;

    public Transform bulletSpawnRef;
    public GameObject bulletPrefab;
    public float ShootForce;
    private bool isMoving = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        isMoving = false;
        if (Input.GetKey(KeyCode.W))
        {
            // transform.Translate(Vector3.forward * Time.deltaTime);    
            rocket.AddForce(transform.forward * MoveForce);
            isMoving = true;
        }
        
        if (Input.GetKey(KeyCode.S))
        {
           // transform.Translate(-1 * Vector3.forward * Time.deltaTime);    
            rocket.AddForce(-1 * transform.forward * MoveForce);
            isMoving = true;
        }

        if (Input.GetKey(KeyCode.D))
        {
            // transform.Translate(Vector3.right * Time.deltaTime);    
            rocket.AddForce(transform.right * MoveForce);
            isMoving = true;
        }

        if (Input.GetKey(KeyCode.A))
        {
            // transform.Translate(-1 * Vector3.right * Time.deltaTime);    
            rocket.AddForce(-1 * transform.right * MoveForce);
            isMoving = true;
        }

        horizontal = Input.GetAxis("Mouse X");
        vertical = Input.GetAxis("Mouse Y");

        if(Input.GetMouseButton(1)) //0 - Left Click , 1 - Right Click 2- middle click
        {
            // transform.Rotate(Vector3.up, horizontal * Time.deltaTime * MovementSpeed);
            // transform.Rotate(-1 * Vector3.right, vertical * Time.deltaTime * MovementSpeed);
            rocket.AddRelativeTorque(-1 * vertical * TurnTorque, horizontal * TurnTorque, 0);
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
        
        if (Input.GetMouseButtonDown(0))
        {
            // Create the Bullet!
            GameObject tempBullet = Instantiate(bulletPrefab, bulletSpawnRef.position, bulletSpawnRef.rotation);

            // Shoot Bullet!
            tempBullet.GetComponent<Rigidbody>().AddForce(bulletSpawnRef.forward * ShootForce);

            Destroy(tempBullet, 3);
        }
    }
}
