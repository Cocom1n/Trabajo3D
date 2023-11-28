using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemigo3 : MonoBehaviour
{
   //public Transform jugador;
   public Transform[] puntos;
   


   public bool dentro = false;
   public float speed = 3f;


   // Use this for initialization
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
       if (other.tag == "Puntos")
       {
        

       }

   }

//    void OnTriggerExit(Collider other)
//    {
//        if (other.tag == "Player")
//        {
        
//            dentro = false;
//        }
//        if (other.tag == "Puntos")
//        {

//        }
//    }
   // Update is called once per frame
   void Update()
   {


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
