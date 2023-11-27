using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigo3 : MonoBehaviour
{
    public Transform jugador;

    public bool dentro = false;
    public float speed = 3f;
 

    // Use this for initialization
    void Start()
    {

    }

    void OnTriggerEnter(Collider other)
    {
   

        if (other.tag == "Player")
        {
            dentro = true;
        }

    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
         
            dentro = false;
        }


    }
    // Update is called once per frame
    void Update()
    {
        Vector3 positionPlayer = new Vector3(jugador.position.x, transform.position.y, jugador.position.z);
        transform.LookAt(positionPlayer);
        transform.position= Vector3.MoveTowards(transform.position, positionPlayer, speed*Time.deltaTime);
    }
  
}
