using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject platziCourse;
    public GameObject spawnHight;
    public GameObject destroydHight;


    public float seconsWaitToSpawn = 3;
    public float maxSpawnRange;
    public float minSpawnRange;

    private Rigidbody2D platziCousesRB2D;
    //public bool isPlatziCourse;



    // Start is called before the first frame update
    void Start()
    {
        //spawnHight = GameObject.Find("Spawn Height");
        //destroydHight = GameObject.Find("Destroy Height");

        platziCousesRB2D = platziCourse.GetComponent<Rigidbody2D>();

        Instantiate(platziCourse, new Vector2(Random.Range(maxSpawnRange, minSpawnRange), 0), platziCourse.transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        /*
        if (isPlatziCourse == false)
        {
            Instantiate(platziCourse, new Vector2(Random.Range(maxSpawnRange, minSpawnRange), 0), platziCourse.transform.rotation);
            isPlatziCourse = true;
        }
        */

        

        if (platziCourse.transform.position.y == destroydHight.transform.position.y || platziCourse.transform.position.y < destroydHight.transform.position.y)
        {
            platziCourse.transform.position = new Vector2(Random.Range(maxSpawnRange, minSpawnRange), spawnHight.transform.position.y);

            platziCousesRB2D.gravityScale = 0;
        }
    }

    private void FixedUpdate()
    {
        //StartCoroutine(SpawnPlatziCourses());
    }

    
    //Corrutina que spawnea los cursoso de platzi
    IEnumerator SpawnPlatziCourses()
    {
        yield return new WaitForSeconds(seconsWaitToSpawn);
        Instantiate(platziCourse, new Vector2(Random.Range(maxSpawnRange, minSpawnRange), spawnHight.transform.position.y), platziCourse.transform.rotation);
    }

}
