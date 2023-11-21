using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Objetivo : MonoBehaviour
{
   public bool check;
    // Start is called before the first frame update
    void Start()
    {
        transform.position= new Vector3(Random.Range(-16,16),0f,Random.Range(-16,16));
    }

    // Update is called once per frame
    void Update()
    {
        
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
           transform.position= new Vector3(Random.Range(-16,16),0f,Random.Range(-16,16));
        }
        
    }
   
}
