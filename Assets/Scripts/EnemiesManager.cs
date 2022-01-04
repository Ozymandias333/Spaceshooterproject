using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// faire spawn les enemy en -4 et +4 de la pos du centre
public class EnemiesManager : MonoBehaviour
{
    public static EnemiesManager instance = null;

    //[SerializeField] public GameObject[] objects;
    [SerializeField] private GameObject enemy;
    private Vector3 _randomPosition;
    private float _zAxis;
    private float y = 0.5f;
    

    //Variables for the waves of enemies
    [SerializeField] public int e_amount;
    [SerializeField] private float WaveWait;
    [SerializeField] private float SpawnWait;

    // Heal bonuses
 /*   [SerializeField] public int HealSpawn;
    [SerializeField] private GameObject heal;
    private Vector3 SpawnPosition;
    private float heal_bonus = 1.0f;*/

    private void Awake()
    {
        if (instance != null)
        {
            DestroyImmediate(gameObject);
        }
        else
        {
            instance = this;
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("SpawnRandom");
    }

    IEnumerator SpawnRandom()
    {
        //Instantiate(objects[UnityEngine.Random.Range(0, objects.Length - 1)]);
        while (Application.isPlaying)
        {
           // if(GameManager.instance.Score() )
                for (int i = 0; i < e_amount; i++)
                {
                    _zAxis = Random.Range(-8, 8);
                    _randomPosition = new Vector3(8, -6, _zAxis);
                    //SpawnWait = Random.Range(y, y + 1);
                    yield return new WaitForSeconds(SpawnWait);
                    GameObject clone_Enemy = Instantiate(enemy, _randomPosition, Quaternion.identity);
                    Destroy(clone_Enemy, 8);
                }

            yield return new WaitForSeconds(WaveWait);
            
        }


        
    }

   
}


/*for (int i = 0; i < heal_bonus; i++)
{
    SpawnPosition = new Vector3(8, -6, 0);
    GameObject heal_clone = Instantiate(heal, SpawnPosition, Quaternion.identity);
    yield return new WaitForSeconds(HealSpawn);
}*/