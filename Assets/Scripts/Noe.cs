using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Noe : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] PlayerInput playerInput;
    private Vector2 entrada;
    //[SerializeField] Animator anim;


    public float velocidad = 10f;
    public float fuerzaSalto = 12f;
    public float gSubida = 2f;
    public float gCaida = 6f;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        entrada = playerInput.actions["Movimiento"].ReadValue<Vector2>();
    }

    private void FixedUpdate()
    {
        

        if (playerInput.actions["Movimiento"].IsPressed())
        {
            // Si el jugador presiona las teclas de movimiento horizontal el personaje se mueve de izquierda a derecha con normalidad
            rb.velocity = new Vector2(entrada.x * velocidad, rb.velocity.y);
        }
        else
        {
            //Si el jugador no presion las teclas de movimiento horizontal, el personaje se detiene inmediatamente
            rb.velocity = new Vector2(0f, rb.velocity.y);
            
        }

        if (rb.velocity.y > 0.1f)
        {
            // El personaje está subiendo en el salto
            rb.gravityScale = gSubida;
        }
        else if (rb.velocity.y < -0.1f)
        {
            // El personaje está cayendo
            rb.gravityScale = gCaida;
        }

        //anim.SetFloat("VelX", entrada.x);
        //anim.SetFloat("VelY", entrada.y);
    }
    public void jump(InputAction.CallbackContext callbackContext)
    {
        if (callbackContext.performed) 
        {
            rb.AddForce(Vector3.up * fuerzaSalto);
        }
    }
}
