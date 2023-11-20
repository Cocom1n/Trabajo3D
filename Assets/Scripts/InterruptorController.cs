using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InterruptorController : MonoBehaviour
{
    public GameObject luzObjeto;
    public bool luz;
    public bool isSwitched;

    public void SwitchLuz(){
        isSwitched = !isSwitched;
        if (isSwitched == true)
        {
            luzObjeto.SetActive(true);
        }
        if (isSwitched == false)
        {
            luzObjeto.SetActive(false);
        }
    }
}
