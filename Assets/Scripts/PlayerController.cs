using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class PlayerController : MonoBehaviour
{
   //Declaramos la velocidad de movimiento en ambos ejes
    public float speed = 10f;
    public float speed_y = 0.05f;
    public bool forceUp = true;
    public float forceUpVelocity = 100f;
    private Animator animator;
    public CinemachineVirtualCamera vCam;
    private CinemachineFramingTransposer framingTransposer;

    
    // Start is calld before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        
        framingTransposer = vCam.GetComponent<CinemachineVirtualCamera>()
        .GetCinemachineComponent<CinemachineFramingTransposer>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        SpriteRenderer sprite = GetComponent<SpriteRenderer>();
        float width = (vCam.m_Lens.OrthographicSize * vCam.m_Lens.Aspect) - (sprite.bounds.size.x / 2f);
        // declaramos el control de movimiento vertical
        float new_y = framingTransposer.m_ScreenY - Input.GetAxis("Vertical") *speed_y*speed*Time.deltaTime;
        framingTransposer.m_ScreenY = Mathf.Clamp(new_y, 0.1f, 0.9f );
        // declaramos el control de movimiento derecha izquierda
        transform.Translate(Vector2.right*speed*Time.deltaTime*Input.GetAxis("Horizontal"));
        //se limita movimiento en X
        transform.position = new Vector2(Mathf.Clamp(transform.position.x, 0 - width, width), transform.position.y);

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