using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
   //Declaramos los valores minimos y maximos de X y la velocidad de movimiento
    public float speed = 10f;
    private float minValueX = -7f;
    private float maxValueX = 7f;
    public bool forceUp = true;
    public float forceUpVelocity = 100f;
  

    
    // Start is calld before the first frame update
    void Start()
    {
       
        
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

        if(forceUp == true)
        {
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0,forceUpVelocity));
            Invoke("BoolForceUpFalse", 110f* Time.deltaTime);
        }
    }

    private void BoolForceUpFalse()
    {
        forceUp = false;
    }
  

}