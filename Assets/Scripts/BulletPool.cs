using UnityEngine;
using System.Collections.Generic;

public class BulletPool : MonoBehaviour
{
    public GameObject bulletPrefab;
    public int poolSize = 20;

    List<GameObject> pool = new List<GameObject>();

    void Start()
    {
        for (int i = 0; i < poolSize; i++)
        {
            GameObject b = Instantiate(bulletPrefab);
            b.SetActive(false);
            pool.Add(b);
        }
    }

    public GameObject GetBullet()
    {
        foreach (var b in pool)
        {
            if (!b.activeInHierarchy)
                return b;
        }

        return null;
    }
}