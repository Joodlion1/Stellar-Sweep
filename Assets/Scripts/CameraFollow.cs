using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private Vector3 offset = new Vector3(0f, 60f, -30f);

    void LateUpdate()
    {
        if (target == null) return;
        transform.position = target.position + offset;
    }
}