using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoBala : MonoBehaviour
{
    public float velocidad = 5.0f;

    void Update()
    {
        transform.Translate(Vector3.forward * velocidad * Time.deltaTime);
    }

    void OnDestroy()
    {
        GameObject jefe = GameObject.FindWithTag("Jefe");

        if (jefe != null)
        {
            jefe.SendMessage("DecrementarContadorBalas");
        }
        else
        {
            Debug.LogWarning("No se encontró un objeto con la etiqueta 'Jefe'");
        }
    }
}
