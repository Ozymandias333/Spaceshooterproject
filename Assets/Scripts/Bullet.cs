using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    [SerializeField] private float B_speed = 1f;
    //[SerializeField] private float S_speed = 1f;
    [SerializeField] private GameObject bullet;
    public int t;
    public int timeoutDestructor;
    Transform myTransform;
    [SerializeField] GameObject explosion;

    // Start is called before the first frame update
    void Start()
    {
        myTransform = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        /*if (!(Input.GetKey(KeyCode.Space)) && t > S_speed)
            Instantiate(Projectile, transform.position,transform.rotation);*/
        myTransform.Translate(Vector3.right * Time.deltaTime * B_speed);
    }

    private void OnCollisionEnter(Collision collision)
    {
        //gameObject other = collision.gameObject;
        if (collision.gameObject.tag == "Enemy")
        {
            //Instantiate(explosion, transform.position, transform.rotation);
            Destroy(collision.gameObject);
            Destroy(bullet);
            GameManager.instance.Score(100);
        }
    }
}
