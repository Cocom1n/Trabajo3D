using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerRayCast : MonoBehaviour
{
    public int rango;
    public Image puntoCentral;
    void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, rango))
        {
            puntoCentral.color = Color.white;
            if (hit.collider.GetComponent<InterruptorController>() == true)
            {
                puntoCentral.color = Color.green;
                if (Input.GetKeyDown(KeyCode.E))
                {
                    if (hit.collider.GetComponent<InterruptorController>().luz == true)
                    {
                        hit.collider.GetComponent<InterruptorController>().SwitchLuz();
                    }
                }
            }
        }
    }

    private void OnDrawGizmos() {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(Camera.main.transform.position, Camera.main.transform.forward * rango);
    }
}
