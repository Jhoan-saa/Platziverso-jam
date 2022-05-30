using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class GameManager : MonoBehaviour
{
    public static GameManager sharedInstance;
    public GameObject[] platziCourse;
    public GameObject spawnHight;
    public GameObject destroydHight;
    public PlayerController player;


    public float seconsWaitToSpawn = 3;
    public int courseIndex = 0;
    private Rigidbody2D platziCousesRB2D;
    public CinemachineVirtualCamera vCam;

    public float width;

    private void Awake()
    {
        if(sharedInstance == null)
        {
            sharedInstance = this;
        }
        width = (vCam.m_Lens.OrthographicSize * vCam.m_Lens.Aspect);
    }

    // Start is called before the first frame update
    void Start()
    {
        //primer curso que se spawnea
        Instantiate(platziCourse[courseIndex],
         new Vector2(Random.Range(0-width, width),
         player.transform.position.y + 15), gameObject.transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    //Corrutina que spawnea los cursoso de platzi
    IEnumerator SpawnPlatziCourses()
    {
        yield return new WaitForSeconds(seconsWaitToSpawn);
        Instantiate(platziCourse[courseIndex], new Vector2(Random.Range(0-width, width), 
                    spawnHight.transform.position.y), platziCourse[courseIndex].transform.rotation);
    }
}
