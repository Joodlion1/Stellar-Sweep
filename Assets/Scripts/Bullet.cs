using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 20f;
    public float lifeTime = 3f;

    float timer;

    void OnEnable()
    {
        timer = 0f;
    }

    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);

        timer += Time.deltaTime;

        if (timer >= lifeTime)
        {
            gameObject.SetActive(false); // return to pool
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player"))
        {
            gameObject.SetActive(false);
        }

        if (other.CompareTag("Asteroid"))
        {
            Destroy(other.gameObject);
            gameObject.SetActive(false);}
    }
}