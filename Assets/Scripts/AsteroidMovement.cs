using UnityEngine;

public class AsteroidMovement : MonoBehaviour
{
    public float speed = 6f;
    private Vector3 moveDir;

    public void SetDirection(Vector3 dir)
    {
        moveDir = dir.normalized;
    }

    void Start()
    {
        if (moveDir == Vector3.zero)
            moveDir = transform.forward;
    }

    void Update()
    {
        transform.position += moveDir * speed * Time.deltaTime;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager gm = FindFirstObjectByType<GameManager>();
            if (gm != null) gm.GameOver();
        }
    }

}