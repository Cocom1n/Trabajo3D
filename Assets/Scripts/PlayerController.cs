using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;// referencia al rigidbody
    public float moveSpeed;// velocidad de desplazamietno
    public Vector2 sensitivity;// para la sencibilidad del mouse

    [SerializeField] public Transform cameraPlayer; // una referencia a la camara

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Cursor.lockState = CursorLockMode.Locked;// para que el mouse no se salga de la ventana del juego (press ESC para ver el mouse)
        moveSpeed = 15f;
        sensitivity.x = 3f;
        sensitivity.y = 3f;
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
        if (hor != 0.0f || ver != 0.0f)
        {
            Vector3 dir = transform.forward * ver + transform.right * hor;
            rb.MovePosition(transform.position + dir * moveSpeed * Time.deltaTime);
        }
    }
}
