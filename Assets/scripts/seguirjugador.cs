﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

    public class seguirjugador : MonoBehaviour {
    public Transform jugador;
    public Transform randomPosition;

    UnityEngine.AI.NavMeshAgent enemigo;
    public bool dentro = false;
    public bool check;
    public bool buscar;

    public float tiempoBusqueda = 10f;  

	void Start ()
    {
        enemigo = GetComponent<UnityEngine.AI.NavMeshAgent>();
        Debug.Log(enemigo.destination);
	}
	
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Objetivo")
        {
            enemigo.destination = randomPosition.position;
            Debug.Log(enemigo.destination);
        }
         
        if (other.tag == "Player")
        {
            SceneManager.LoadScene(3);
        }

    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            StartCoroutine(actualizarCronometro());
            dentro = false;
        }
    }

	void Update () {
		
        if (dentro)
        {
            check=true;
            tiempoBusqueda=10f;
        }
        if(check)
        {
            enemigo.destination = jugador.position;
        }
        if (!check)
        {
            enemigo.destination = randomPosition.position;
        }
            if(tiempoBusqueda< 0f)
            {
                check=false;
                Debug.Log("se escapo el jugador");
                tiempoBusqueda=10f;
                StopAllCoroutines();
            }

	}
     IEnumerator actualizarCronometro()
    {
        while (true)
        {
            Debug.Log("persiguiendo jugador"+tiempoBusqueda);
            tiempoBusqueda = tiempoBusqueda - Time.deltaTime;
            yield return null;
        }
       
    }
}
