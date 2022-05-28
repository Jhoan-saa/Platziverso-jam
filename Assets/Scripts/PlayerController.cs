using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class PlayerController : MonoBehaviour
{
   //Declaramos los valores minimos y maximos de X y la velocidad de movimiento
    private float maxValueX;
    private float minValueX;
    public float speed = 10f;
    public bool forceUp = true;
    public float forceUpVelocity = 100f;
    private Animator animator;
    public CinemachineVirtualCamera mainCam;
    public CinemachineFramingTransposer framingTransposer;

    
    // Start is calld before the first frame update
    void Start()
    {
        maxValueX = 11f;
        minValueX = 0 - maxValueX;
        animator = GetComponent<Animator>();
        
        mainCam = GetComponent<CinemachineVirtualCamera>();
        framingTransposer = mainCam.GetComponent<CinemachineFramingTransposer>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        mainCam.GetComponent<CinemachineVirtualCamera>()
        .GetCinemachineComponent<CinemachineFramingTransposer>().m_ScreenY += Input.GetAxis("Vertical") *.01f*Time.deltaTime;
        // declaramos el control de movimiento derecha izquierda
        transform.Translate(Vector2.right*speed*Time.deltaTime*Input.GetAxis("Horizontal"));

        //condicionamos los limites en X en positivo
        if(transform.position.x > maxValueX)
        {
            transform.position = new Vector2(maxValueX,transform.position.y);
    
        }
        //condicionamos los limites en X en positivo
        if (transform.position.x < minValueX)
        {
            transform.position = new Vector2(minValueX,transform.position.y);
        }

        if(forceUp)
        {
            animator.SetBool("PowerUpAnim",true);
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0,forceUpVelocity));
            // Invoke("BoolForceUpFalse", 110f* Time.deltaTime);
            StartCoroutine("BoolForceUp");
        }
        //paramos la Coroutine , la animacion y la potencia y del cohete 
        else 
        {
            animator.SetBool("PowerUpAnim",false);
            StopCoroutine("BoolForceUp");
        }
    }

    // private void BoolForceUpFalse()
    // {
    //     forceUp = false;
    //     animator.SetBool("PowerUpAnim",false);
    // }

    private IEnumerator BoolForceUp()
    {
        yield return new WaitForSeconds(2f);
        forceUp = false;
    }

}