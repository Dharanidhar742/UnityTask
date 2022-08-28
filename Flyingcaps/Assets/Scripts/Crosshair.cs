using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class Crosshair : MonoBehaviour
{
    public Camera cam;
    public GameObject crosshairs;
    public GameObject eye;
    public GameObject bulletPrefab;
    public GameObject bulletStart;
    public Animator Wizard;
    public GameObject Gameover;


    [SerializeField] TextMeshProUGUI Level;
    [SerializeField] TextMeshProUGUI numberOfDragons;
    public float bulletSpeed = 10.0f;
    

    private Vector3 target;
    private Vector2 direction;
    private float rotationZ;

    // Use this for initialization
    private void Awake()
    {
        Global.TotalDragonsLeft = 15;
        Global.DragonsEntered = 0;
    }
    void Start()
    {
        crosshairs.transform.position = new Vector2(0, 0);
        Cursor.visible = false;
        Level.text = "Level "+Global.Level;  
       
    }

    // Update is called once per frame
    void Update()
    {
       
        if(Global.TotalDragonsLeft<=1)
        {
            Global.Level++;
            SceneManager.LoadScene("SampleScene");
        }
        else if(Global.DragonsEntered>8)
        {
            
            Gameover.SetActive(true);
            Invoke("Menu", 5f);
        }
        numberOfDragons.text = Global.DragonsEntered.ToString();
        target = cam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, transform.position.z));
        crosshairs.transform.position = new Vector2(target.x, target.y);

        Vector3 difference = target - eye.transform.position;
        rotationZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg - 180;
        eye.transform.rotation = Quaternion.Euler(0.0f, 0.0f, rotationZ);

        if (Input.GetMouseButtonDown(0))
        {
           Wizard.SetBool("Attack", true);
            float distance = difference.magnitude;
            direction = difference / distance;
            direction.Normalize();
            Invoke("fireBullet", 0.6f);

        }
        else Wizard.SetBool("Attack", false);
    }
    void fireBullet()
    {
        GameObject b = Instantiate(bulletPrefab) as GameObject;
        b.transform.position = bulletStart.transform.position;
        b.transform.rotation = Quaternion.Euler(0.0f, 0.0f, rotationZ);
        b.GetComponent<Rigidbody2D>().velocity = direction * bulletSpeed;
        Destroy(b, 0.6f);
       

    }
    void Menu()
    {
       
        SceneManager.LoadScene("MainMenu");
    }
   
        

       

}

