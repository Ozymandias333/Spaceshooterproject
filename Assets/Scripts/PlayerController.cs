using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.Diagnostics;
using System.Collections;


[System.Serializable]
public class Boudary
{
    public float xMin, xMax, zMin, zMax;
}

public class PlayerController : MonoBehaviour
{

    [SerializeField] private float H_speed = 1f; // Horizontal speed
    [SerializeField] private float V_speed = 1f; // Vertical speed
    //[SerializeField] private float S_speed = 1f; // Shooting spped
    [SerializeField] Camera m_MainCamera;
    private Stopwatch timer;
    private float t = 400f;
    //[SerializeField] private GameObject SpawnPosition;
    [SerializeField] private GameObject bullet;
    public Boudary boundary;
    [SerializeField] GameObject explosion;

    private void Awake()
    {

        timer = new Stopwatch();

        timer.Start();
    }

    // Start is called before the first frame update
    void Start()
    {
        m_MainCamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow))
            transform.Translate(Vector3.forward * V_speed * Time.deltaTime);
        if (Input.GetKey(KeyCode.LeftArrow))
            transform.Translate(Vector3.left * H_speed * Time.deltaTime);
        if (Input.GetKey(KeyCode.RightArrow))
            transform.Translate(Vector3.right * H_speed * Time.deltaTime);
        if (Input.GetKey(KeyCode.DownArrow))
            transform.Translate(Vector3.back * V_speed * Time.deltaTime);


        ProcessFire();
    }

    void ProcessFire()
    {
        if ((Input.GetKey(KeyCode.Space)) && timer.ElapsedMilliseconds > t)
        {
            GameObject newBullet = Instantiate(bullet, transform.position, Quaternion.identity);
            timer.Reset();
            timer.Start();
            Destroy(newBullet, 4);
        }


    }
    private void OnCollisionEnter(Collision collision)
    {
        //gameObject other = collision.gameObject;
        if (collision.gameObject.tag == "Enemy")
        {
            //Instantiate(explosion, transform.position, transform.rotation);
            Destroy(collision.gameObject);
            GameManager.instance.TakeDamage(1);
        }
    }
}

