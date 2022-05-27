using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
   //Declaramos los valores minimos y maximos de X y la velocidad de movimiento
    private float minValueX = -7f;
    private float maxValueX = 7f;
    public float speed = 10f;
    public bool forceUp = true;
    public float forceUpVelocity = 100f;
    private Animator animator;

    
    // Start is calld before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // declaramos el control de movimiento derecha izquierda
        transform.Translate(Vector2.right*speed*Time.deltaTime*Input.GetAxis("Horizontal"));
        //condicionamos los limites en X en positivo
        if(transform.position.x >7f)
        {
            transform.position = new Vector2(maxValueX,transform.position.y);
    
        }
        //condicionamos los limites en X en positivo
        if (transform.position.x < -7f)
        {
            transform.position = new Vector2(minValueX,transform.position.y);
        }
        // Agregamos Fuerza de hacia arriba y velocidad + activamos la animacion PowerUpAnim por 1 segundo con Coroutine
        if(forceUp == true)
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