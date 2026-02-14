using UnityEngine;

public class BoundsTrigger : MonoBehaviour
{
    void OnTriggerExit(Collider other)
{
    if (other.CompareTag("Asteroid") || other.CompareTag("Bullet"))
    {
        Destroy(other.gameObject);
    }
}
}