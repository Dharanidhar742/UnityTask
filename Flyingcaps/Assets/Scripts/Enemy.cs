using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 10.0f;
    Rigidbody2D rb;
    public GameObject hiteffect;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(-speed, 0);
        //Invoke("DestroyEnemy", 30f);
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("HIT");
        GameObject effect= Instantiate(hiteffect, transform.position, Quaternion.identity);
        Destroy(effect, 1f);
        //Destroy(this.gameObject);
        DestroyEnemy();
        if(collision.gameObject.CompareTag("Wall"))
        {
            Global.DragonsEntered++;
            
        }
        Global.TotalDragonsLeft--;

    }

    private void DestroyEnemy()
    {
        gameObject.SetActive(false);
    }
}
