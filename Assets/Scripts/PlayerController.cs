using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float verticalInput;
    public float horizontalInput;

    public float speed = 12.0f;
    public float turnSpeed = 120.0f;

    public float xRange = 25.0f;
    public float zRange = 25.0f;
    public BulletPool bulletPool;
    public Transform firePoint;

    void Start()
    {

    }

    void Update()
    {
        if (transform.position.x < -xRange)
        {
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
        }

        if (transform.position.x > xRange)
        {
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
        }

        if (transform.position.z < -zRange)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, -zRange);
        }

        if (transform.position.z > zRange)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, zRange);
        }

        verticalInput = Input.GetAxis("Vertical");
        horizontalInput = Input.GetAxis("Horizontal");

        transform.Translate(Vector3.forward * verticalInput * Time.deltaTime * speed);
        transform.Rotate(Vector3.up * horizontalInput * Time.deltaTime * turnSpeed);


        if (Input.GetKeyDown(KeyCode.Space))
{
    GameObject b = bulletPool.GetBullet();

    if (b != null)
    {
        b.transform.position = firePoint.position;
        b.transform.rotation = firePoint.rotation;
        b.SetActive(true);
    }
}
    }
}