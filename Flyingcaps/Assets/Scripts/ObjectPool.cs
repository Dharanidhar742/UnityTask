using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public static ObjectPool instance;

    private List<GameObject> pooledObject = new List<GameObject>();
    private int amountToPool = 15;

    [SerializeField] private GameObject EnemyPrefab;
    private void Awake()
    {
        if(instance==null)
        {
            instance = this;
        }
    }
    private void Start()
    {
        for(int i=0;i<amountToPool;i++)
        {
            GameObject obj = Instantiate(EnemyPrefab);
            obj.SetActive(false);
            pooledObject.Add(obj);
        }
    }

    public GameObject GetPooledObject()
    {
        for (int i=0;i < pooledObject.Count;i++)
        {
            if (!pooledObject[i].activeInHierarchy)
                  return pooledObject[i];
        }
        return null;
    }
    
}
