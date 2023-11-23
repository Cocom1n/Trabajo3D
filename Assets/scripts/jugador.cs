using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jugador : MonoBehaviour
{
    [SerializeField] public KeyCode camera1;
    [SerializeField] public KeyCode camera2;
    private float rotacion;
    private float speed=4f;
    private float rotationSpeed=3f;
    private Quaternion getRotation;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput= Input.GetAxis("Horizontal");
        float verticalInput=Input.GetAxis("Vertical");
        Vector3 moveDirection= new Vector3(horizontalInput,0,verticalInput);
        transform.position=transform.position+moveDirection*speed*Time.deltaTime;
        transform.rotation= getRotation;

        if(Input.GetKeyDown(camera1)){
            getRotation =  Quaternion.Slerp(transform.rotation,Quaternion.LookRotation(new Vector3(-1f,0f,-1)),rotationSpeed*Time.deltaTime);
            
            rotacion=gameObject.transform.rotation.y/360;
        }
        if(Input.GetKeyDown(camera2))
        {
            transform.rotation=  Quaternion.Slerp(transform.rotation,Quaternion.LookRotation(new Vector3(0f,1f,0)),rotationSpeed*Time.deltaTime);
            rotacion=gameObject.transform.rotation.y/360 ;
        }
 
    }
}
