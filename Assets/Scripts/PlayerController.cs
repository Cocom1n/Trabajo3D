using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// using UnityEngine.Audio;

public class PlayerController : MonoBehaviour
{
    public Transform groundcheck;
    public LayerMask ground;
    public LayerMask walls;
    private Rigidbody rb;// referencia al rigidbody
    private Vector2 sensitivity;// para la sencibilidad del mouse
    private float moveSpeed;// velocidad de desplazamieto
    public float jumpSpeed;
    public bool tocaSuelo;
    public bool tocaPared;
    [SerializeField] private Transform cameraPlayer; // una referencia a la camara
    [SerializeField] private Animator animator;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        sensitivity.x = 3f;
        sensitivity.y = 3f;
        moveSpeed = 5f;
    }

    void FixedUpdate()
    {
        UpdateMove();
        UpdateMouseMove();
    }

    //metodo para controlar la vista del player
    public void UpdateMouseMove()
    {
        float hor = Input.GetAxis("Mouse X");
        float ver = Input.GetAxis("Mouse Y");

        if (hor != 0)
        {
            transform.Rotate(0, hor * sensitivity.x, 0);//rota la camara acorde al eje del player
        }
        if (ver != 0)
        {
            Vector3 rotation = cameraPlayer.localEulerAngles;//obtiene la rotacion de la camara
            rotation.x = (rotation.x - ver * sensitivity.y + 360) % 360; //actualiza la rotacion en X pero q este debajo del 360
            if (rotation.x > 40 && rotation.x < 180)
            {//verifica si la rotacion esta entre 40 y 180 y si llega al limite inferior mantenerlo ahi
                rotation.x = 40;
            }
            else if (rotation.x < 280 && rotation.x > 180)
            {//verifica si la rotacion esta entre 280 y 180 y si llega al limite superior mantenerlo ahi
                rotation.x = 280;
            }
            cameraPlayer.localEulerAngles = rotation; //aplica la rotacion actualizada
        }
    }

    // metodo para el desplazamiento del player
    public void UpdateMove()
    {
        // para el despazamiento del player
        float hor = Input.GetAxisRaw("Horizontal");// en eje (X)
        float ver = Input.GetAxisRaw("Vertical");// en eje (Z)

        Vector3 mover;
        if(hor != 0 || ver != 0){
            mover = (transform.forward * ver + transform.right * hor).normalized * moveSpeed; //el mov en diagonal se hace a vel normal
            // sonido.Play();
            animator.SetBool("IsRuning", true);
        }else{
            mover = Vector3.zero; //si no se aprieta ningun boton se queda quieto
            animator.SetBool("IsRuning", false);
        }
        mover.y = rb.velocity.y; // se aplica gravedad
        rb.velocity = mover;
        tocaSuelo = Physics.CheckSphere(groundcheck.position, .6f, ground); //revisa si toca el suelo con el Layer del Plano
        tocaPared = Physics.CheckSphere(groundcheck.position, .6f, walls);
        if(tocaPared == true && tocaSuelo != true){
            mover.y = rb.velocity.y * 2f;
        }
        if (Input.GetButtonDown("Jump") && tocaSuelo)
        {
            rb.AddForce(Vector3.up * jumpSpeed, ForceMode.Impulse); //aplica impulso del salto
        }
    
    }
}
