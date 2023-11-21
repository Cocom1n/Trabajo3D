using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class seguirjugador : MonoBehaviour {
    public Transform jugador;
    public Transform randomPosition;

    UnityEngine.AI.NavMeshAgent enemigo;
    public bool dentro = false;
    public bool check;

	// Use this for initialization
	void Start () {
        enemigo = GetComponent<UnityEngine.AI.NavMeshAgent>();
          Debug.Log(enemigo.destination);
       
	}
	
    void OnTriggerEnter(Collider other)
    {
         if (other.tag == "Objetivo")
        {
            check=true;
            enemigo.destination = randomPosition.position;
            Debug.Log(enemigo.destination);
        }
         
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
	void Update () {
		
        if (dentro)
        {
            enemigo.destination = jugador.position;
        }
        if (!dentro)
        {
            enemigo.destination = randomPosition.position;
          
        
        }

	}
}
