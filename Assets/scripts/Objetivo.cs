using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Objetivo : MonoBehaviour
{
   public bool check;
   
    void Start()
    {
        transform.position= new Vector3(Random.Range(-17.29f, 19.14f),-3.35f, Random.Range(4.7f, 41.12f));
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
            Debug.Log("posicion del objetivo"+transform.position);
           transform.position= new Vector3(Random.Range(-17.29f, 19.14f),-3.35f, Random.Range(4.7f, 41.12f));
        }
    }
}
