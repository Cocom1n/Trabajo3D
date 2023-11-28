using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemigo3 : MonoBehaviour
{
    public Transform[] puntos; //Puntos a los que se movera el enemigo
    public bool dentro = false;
    public float speed = 3f;

    void Start()
    {
       StartCoroutine("Moverse");
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            SceneManager.LoadScene(3);
        }
    }

    IEnumerator Moverse()
    {
        int i = 1;
        Vector3 puntoObjetivo = new Vector3(puntos[i].position.x, transform.position.y, puntos[i].position.z);
        while (true) {
            while (transform.position != puntoObjetivo)
            {
               transform.LookAt(puntoObjetivo);
               transform.position = Vector3.MoveTowards(transform.position, puntoObjetivo, speed * Time.deltaTime);
               yield return null;
            }
            yield return new WaitForSeconds(2);
            if (i < 3) i++; else i = 0;
            puntoObjetivo = new Vector3(puntos[i].position.x, transform.position.y, puntos[i].position.z);
        }
    }
}
