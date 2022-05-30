using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatziCoursesScript : MonoBehaviour
{
    private Rigidbody2D RB2D;

    private GameObject destroyHeight;
    private GameObject spawnHeight;


    public float minSpawnRange = -8.5f;
    public float maxSpawnRange = 8.5f;


    // Start is called before the first frame update
    void Start()
    {
        destroyHeight = GameObject.Find("Destroy Height");
        spawnHeight = GameObject.Find("Spawn Height");

        RB2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.transform.position.y <= destroyHeight.transform.position.y)
        {
            if(GameManager.sharedInstance.courseIndex != 19)
            {
                RB2D.gravityScale = 0;

                gameObject.transform.position = new Vector2(Random.Range(minSpawnRange, maxSpawnRange), spawnHeight.transform.position.y);
            }
        }
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(this.gameObject);

            GameManager.sharedInstance.courseIndex ++;
            GameManager.sharedInstance.StartCoroutine("SpawnPlatziCourses");
            RB2D.gravityScale = 1;
        }
    }
}
