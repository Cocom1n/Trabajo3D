using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjetivoE2 : MonoBehaviour
{
    public Transform jugador;
    public float tiempoBusqueda=10f;
    public int distanciaExtra = 4;
    public bool caza;
    public bool check;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(jugador.position.x+ distanciaExtra, -3.35f,jugador.position.z+distanciaExtra);
    }

    // Update is called once per frame
    void Update()
    {
        if(caza) 
        {
            transform.position = jugador.position;
        }
        if (tiempoBusqueda < 0f)
        {

            caza = false;
            Debug.Log("se escapo el jugador");
            distanciaExtra = 4;
            tiempoBusqueda = 10f;
            StopAllCoroutines();
        }

    }
    void OnTriggerExit(Collider other)
    {
        if (other.tag == "enemy")
        {
            check = false;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "enemy")
        {
           
            check = true;
            if (!caza)
            { 
                distanciaExtra = distanciaExtra - 1;
                if (distanciaExtra == 0)
                {
                    caza = true;
                    StartCoroutine(actualizarCronometro());
                }
                Debug.Log("posicion del objetivo" + transform.position);
                transform.position = new Vector3(jugador.position.x + distanciaExtra, -3.35f, jugador.position.z + distanciaExtra);
            }
        }

    }
    IEnumerator actualizarCronometro()
    {
        while (true)
        {
            Debug.Log("persiguiendo jugador" + tiempoBusqueda);
            tiempoBusqueda = tiempoBusqueda - Time.deltaTime;
            yield return null;
        }

    }
}
