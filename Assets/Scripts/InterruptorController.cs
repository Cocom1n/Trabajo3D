using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InterruptorController : MonoBehaviour
{
    public GameObject luzObjeto;
    public bool luz;
    public bool isSwitched;

    public void SwitchLuz()
    {
        isSwitched = !isSwitched;
        if (isSwitched == true)
        {
            luzObjeto.SetActive(true);
            TorchCounter.Instance.IncreaseCounter();// se incrementa el contador de antorchas
            if (TorchCounter.Instance.Counter == 7)// si el contador llega a 7 se muestra la pantalla de win
            {
                SceneManager.LoadScene("GameWin");
            }
        }
        if (isSwitched == false)
        {
            luzObjeto.SetActive(false);
            TorchCounter.Instance.DecreaseCounter();// se resta el contador de antorchas
        }
    }
}
