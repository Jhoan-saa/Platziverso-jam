using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager sharedInstance;

    private void Awake()
    {
        if(sharedInstance == null)
        {
            sharedInstance = this;
        }
    }


    public GameObject[] platziCourse;
    public GameObject spawnHight;
    public GameObject destroydHight;


    public float seconsWaitToSpawn = 3;
    public float maxSpawnRange;
    public float minSpawnRange;

    public int courseIndex = 0;

    private Rigidbody2D platziCousesRB2D;



    // Start is called before the first frame update
    void Start()
    {
        //primer curso que se spawnea
        Instantiate(platziCourse[courseIndex], new Vector2(Random.Range(maxSpawnRange, minSpawnRange), spawnHight.transform.position.y), gameObject.transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    //Corrutina que spawnea los cursoso de platzi
    IEnumerator SpawnPlatziCourses()
    {
        yield return new WaitForSeconds(seconsWaitToSpawn);
        Instantiate(platziCourse[courseIndex], new Vector2(Random.Range(maxSpawnRange, minSpawnRange), 
                    spawnHight.transform.position.y), platziCourse[courseIndex].transform.rotation);
    }
}
