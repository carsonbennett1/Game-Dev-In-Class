using UnityEngine;

public class Movement : MonoBehaviour
{
    public float MovementSpeed = 80.0f;
    public float horizontal;
    public float vertical;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.forward * Time.deltaTime);    
        }
        
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(-1 * Vector3.forward * Time.deltaTime);    
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.right * Time.deltaTime);    
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(-1 * Vector3.right * Time.deltaTime);    
        }

        horizontal = Input.GetAxis("Mouse X");
        vertical = Input.GetAxis("Mouse Y");

        transform.Rotate(Vector3.up, horizontal * Time.deltaTime * MovementSpeed);
        transform.Rotate(-1 * Vector3.right, vertical * Time.deltaTime * MovementSpeed);

    }
}
