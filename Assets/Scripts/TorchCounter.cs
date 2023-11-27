using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TorchCounter : MonoBehaviour
{
    public static TorchCounter Instance;
    private float counter;
    private TextMeshProUGUI counterTxt;

    public float Counter { get => counter; set => counter = value; }
    public TextMeshProUGUI CounterTxt { get => counterTxt; set => counterTxt = value; }

    private void Awake()
    {
        if (TorchCounter.Instance == null)
        {
            TorchCounter.Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        Counter = 0;// inicializa el contador de antorchas en 0
        CounterTxt = GetComponentInChildren<TextMeshProUGUI>();// se obtiene el componente textmeshpro para poder asignar el texto
    }

    private void Update()
    {
        CounterTxt.text = Counter.ToString() + " / 7";// actualiza el texto del contador de antorchas
    }

    // metodo para incrementar el contador de antorchas en +1
    public void IncreaseCounter()
    {
        Counter += 1;
    }
    // metodo para restar el contador de antorchas en -1
    public void DecreaseCounter()
    {
        Counter -= 1;
    }
}
