using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InterruptorController : MonoBehaviour
{
    public GameObject luzObjeto;
    public bool luz;
    public bool isSwitched;

    private AudioSource soundFire;

    private void Start()
    {
        soundFire = GetComponent<AudioSource>();
    }
    public void SwitchLuz()
    {
        isSwitched = !isSwitched;
        if (isSwitched == true)
        {
            luzObjeto.SetActive(true);
            soundFire.Play();
            TorchCounter.Instance.IncreaseCounter();// se incrementa el contador de antorchas
            if (TorchCounter.Instance.Counter == 7)// si el contador llega a 7 se muestra la pantalla de win
            {
                SceneManager.LoadScene("GameWin");
            }
        }
        if (isSwitched == false)
        {
            luzObjeto.SetActive(false);
            soundFire.Pause();
            TorchCounter.Instance.DecreaseCounter();// se resta el contador de antorchas
        }
    }
}
