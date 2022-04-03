using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPool : MonoBehaviour
{
    public static BulletPool Instance;

    private List<GameObject> pooledBullet = new List<GameObject>();

    private int amountToPool = 20;

    [SerializeField] private GameObject BulletPrefab;

    private void Awake()
    {
        InitializeSingleton();
    }


    private void InitializeSingleton()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            Instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < amountToPool; i++)
        {
            GameObject bullet = Instantiate(BulletPrefab);

            bullet.SetActive(false);

            pooledBullet.Add(bullet);
        }
    }

    public GameObject getPooledBullet()
    {
        for (int i = 0; i < pooledBullet.Count; i++)
        {
            if (!pooledBullet[i].activeInHierarchy)
            {
                return pooledBullet[i];
            }
        }

        return null;
    }
}
