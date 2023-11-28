using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Transform groundcheck;
    public LayerMask ground;
    public LayerMask walls;
    private Rigidbody rb;// referencia al rigidbody
    public Vector2 sensitivity;// para la sencibilidad del mouse
    public float moveSpeed;// velocidad de desplazamieto
    public float jumpSpeed;
    public bool tocaSuelo;
    public bool tocaPared;

    [SerializeField] public Transform cameraPlayer; // una referencia a la camara

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Cursor.lockState = CursorLockMode.Locked;// para que el mouse no se salga de la ventana del juego (press ESC para ver el mouse)
    }

    // Update is called once per frame
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
<<<<<<< Updated upstream
            transform.Rotate(0, hor * sensitivity.x, 0);
=======
            transform.Rotate(0, hor * sensitivity.x, 0);//rota la camara acorde al eje del player
>>>>>>> Stashed changes
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
<<<<<<< Updated upstream
            Debug.Log("vertical: " + ver);
            cameraPlayer.localEulerAngles = rotation;
=======
            cameraPlayer.localEulerAngles = rotation; //aplica la rotacion actualizada
>>>>>>> Stashed changes
        }
    }

    // metodo para el desplazamiento del player
    public void UpdateMove()
    {
        // para el despazamiento del player
        float hor = Input.GetAxis("Horizontal");// en eje (X)
        float ver = Input.GetAxis("Vertical");// en eje (Z)

        // if (hor != 0.0f || ver != 0.0f)
        // {
        //     Vector3 dir = transform.forward * ver + transform.right * hor;
        //     rb.MovePosition(transform.position + dir * moveSpeed * Time.deltaTime);
        // }

        Vector3 mover;
        if(hor != 0 || ver != 0){
            mover = (transform.forward * ver + transform.right * hor).normalized * moveSpeed; //el mov en diagonal se hace a vel normal
        }else{
            mover = Vector3.zero; //si no se aprieta ningun boton se queda quieto
        }
        mover.y = rb.velocity.y; // se aplica gravedad
        rb.velocity = mover;
<<<<<<< Updated upstream
        tocaSuelo = Physics.CheckSphere(groundcheck.position, .2f, ground); //revisa si toca el suelo con el Layer del Plano
        tocaPared = Physics.CheckSphere(groundcheck.position, .6f, walls);
        if(tocaPared == true && tocaSuelo != true){
            mover.y = rb.velocity.y * 2f;
=======
        tocaSuelo = Physics.CheckSphere(groundcheck.position, .6f, ground); //revisa si toca el suelo con el Layer del Plano
        tocaPared = Physics.CheckSphere(groundcheck.position, .6f, walls);// revisa si toca la pared con el layer de las paredes

        if(tocaPared == true && tocaSuelo != true){ //verifica si toca la pared y no el suelo
            // mover.y = rb.velocity.y * 2f;
            rb.velocity = new Vector3(0f, -.5f, 0f) * moveSpeed;//cae hasta que toca el suelo
>>>>>>> Stashed changes
        }

        if (Input.GetButtonDown("Jump") && tocaSuelo)//verifica si se aprieta el boton space y si tocasuelo es verdadero
        {
            rb.AddForce(Vector3.up * jumpSpeed, ForceMode.Impulse); //aplica impulso inmediato de salto al personaje
        }
    }
}
