using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JugadorController : MonoBehaviour
{
    private Rigidbody rb;
    public float velocidad;
    private int contador;
    public Text textoContador, textoGanar;


    void Start()
    {
        rb = GetComponent<Rigidbody>();
        contador = 0;
        setTextoContador();
        textoGanar.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        float movimientoH = Input.GetAxis("Horizontal");
        float movimientoV = Input.GetAxis("Vertical");

        Vector3 movimiento = new Vector3(movimientoH, 0.0f, movimientoV);

        rb.AddForce(movimiento * velocidad);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Coleccionable")) {
            other.gameObject.SetActive(false);
            contador++;
            setTextoContador();
        } else if (other.gameObject.CompareTag("Moneda")) {
            other.gameObject.SetActive(false);
            contador += 4;
            setTextoContador();
        }
    }

    void setTextoContador(){
        textoContador.text = "Contador: " + contador.ToString();
        if (contador >= 28){
            textoGanar.text = "¡Ganaste!";
        }
    }
}
