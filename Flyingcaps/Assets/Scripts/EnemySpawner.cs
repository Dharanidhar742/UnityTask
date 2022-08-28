using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject EnemyPre;
    public float respawnTime = 1.0f;
    Vector2 ScreenBounds;
    private int enemyCount=15;

    void Start()
    {
        ScreenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        StartCoroutine(EnemyWave());
    }
    private void spawn()
    {
       // GameObject a = Instantiate(EnemyPre) as GameObject;
        //a.transform.position = new Vector2(ScreenBounds.x * 2, Random.Range(0, ScreenBounds.y-1));
        GameObject obj = ObjectPool.instance.GetPooledObject();
        if(obj!=null)
        {
            obj.transform.position = new Vector2(ScreenBounds.x * 2, Random.Range(0, ScreenBounds.y - 1));
            obj.SetActive(true);
        }
    }

    IEnumerator EnemyWave()
    {
        for (int i= 0;i< enemyCount;i++)
        {
            yield return new WaitForSeconds(respawnTime);
            spawn();
        }
    }

  
}
