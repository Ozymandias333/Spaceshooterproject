using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] public float E_speed;
    
    // Start is called before the first frame update
    void Start()
    {
       E_speed = Random.Range(E_speed , E_speed + 1f); 
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.left * Time.deltaTime * E_speed);
    }
}
