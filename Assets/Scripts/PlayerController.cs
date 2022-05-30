using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class PlayerController : MonoBehaviour
{
    //Declaramos la velocidad de movimiento en ambos ejes
    public float speed = 10f;
    public float speed_y = 0.05f;
    public FuelBar fuelBar;
    private float currentFuel;
    private int score = 0;
    private Animator animator;
    public CinemachineVirtualCamera vCam;
    private CinemachineFramingTransposer framingTransposer;



    // Start is calld before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();

        framingTransposer = vCam.GetComponent<CinemachineVirtualCamera>()
        .GetCinemachineComponent<CinemachineFramingTransposer>();
        currentFuel = 10f;
        GetComponent<ConstantForce2D>().enabled = true;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        SpriteRenderer sprite = GetComponent<SpriteRenderer>();
        float width = (vCam.m_Lens.OrthographicSize * vCam.m_Lens.Aspect) - (sprite.bounds.size.x / 2f);
        // declaramos el control de movimiento vertical
        transform.Translate(Vector2.up * speed * Time.deltaTime * Input.GetAxis("Vertical"));
        float new_y = framingTransposer.m_ScreenY - Input.GetAxis("Vertical") * speed_y * speed * Time.deltaTime;
        framingTransposer.m_ScreenY = Mathf.Clamp(new_y, 0.1f, 0.9f);
        // declaramos el control de movimiento derecha izquierda
        transform.Translate(Vector2.right * speed * Time.deltaTime * Input.GetAxis("Horizontal"));
        //se limita movimiento en X
        transform.position = new Vector2(Mathf.Clamp(transform.position.x, 0 - width, width), transform.position.y);

        if (currentFuel > 0f)
        {
            animator.SetBool("PowerUpAnim", true);
        }
        //paramos la Coroutine , la animacion y la potencia y del cohete 
        else
        {
            animator.SetBool("PowerUpAnim", false);
            BoolForceUp();
        }
        currentFuel = Mathf.Clamp(currentFuel - (Time.deltaTime * 1f), fuelBar.slider.minValue, fuelBar.slider.maxValue);
        fuelBar.SetFuel(currentFuel);
    }

    private void BoolForceUp()
    {
        GetComponent<ConstantForce2D>().enabled = false;
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "PlatziCourses")
        {
            score++;
            GetComponent<ConstantForce2D>().enabled = true;
            currentFuel = Mathf.Clamp(currentFuel + 3f, fuelBar.slider.minValue, fuelBar.slider.maxValue);
        }
    }

    public int getScore(){
        return score;
    }
}