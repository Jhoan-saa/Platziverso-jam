using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatziCoursesScript : MonoBehaviour
{
    private Rigidbody2D RB2D;

    private GameObject destroyHeight;
    private GameObject spawnHeight;
    private SpriteRenderer sprite;


    // Start is called before the first frame update
    void Start()
    {
        destroyHeight = GameObject.Find("Destroy Height");
        spawnHeight = GameObject.Find("Spawn Height");

        RB2D = GetComponent<Rigidbody2D>();
        gameObject.tag = "PlatziCourses";
        gameObject.layer = 4;
        RB2D.gravityScale = 0;
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.transform.position.y <= destroyHeight.transform.position.y)
        {
            if (GameManager.sharedInstance.courseIndex != 19)
            {

                gameObject.transform.position = 
                    new Vector2(Random.Range(0 - GameManager.sharedInstance.width, GameManager.sharedInstance.width),
                    spawnHeight.transform.position.y);
            }
        }
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(this.gameObject);

            GameManager.sharedInstance.courseIndex++;
            GameManager.sharedInstance.StartCoroutine("SpawnPlatziCourses");
            RB2D.gravityScale = 0;
        }
    }
}
