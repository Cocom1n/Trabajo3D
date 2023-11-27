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

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Cursor.lockState = CursorLockMode.Locked;// para que el mouse no se salga de la ventana del juego (press ESC para ver el mouse)
        sensitivity.x = 3f;
        sensitivity.y = 3f;
        moveSpeed = 5f;
    }

    // Update is called once per frame
    void Update()
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
            transform.Rotate(0, hor * sensitivity.x, 0);
        }
        if (ver != 0)
        {
            Vector3 rotation = cameraPlayer.localEulerAngles;
            rotation.x = (rotation.x - ver * sensitivity.y + 360) % 360;
            if (rotation.x > 80 && rotation.x < 180)
            {
                rotation.x = 80;
            }
            else if (rotation.x < 280 && rotation.x > 180)
            {
                rotation.x = 280;
            }
            cameraPlayer.localEulerAngles = rotation;
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
        }else{
            mover = Vector3.zero; //si no se aprieta ningun boton se queda quieto
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
