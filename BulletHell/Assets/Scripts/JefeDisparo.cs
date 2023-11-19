using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class JefeDisparo : MonoBehaviour
{
    public GameObject balaPrefab;
    public Transform spawnPoint;
    public float disparoIntervalo;
    public TextMeshProUGUI balasEnPantallaText;

    private int balasEnPantalla = 0;

    float anguloInicialPatron3 = 0.0f;

    private void Start()
    {
        StartCoroutine(DispararBullets());
    }

    IEnumerator DispararBullets()
    {
        float tiempoTotal = 30.0f;

        while (tiempoTotal > 0)
        {
            yield return new WaitForSeconds(disparoIntervalo);

            // Cambiar el patrón de disparo cada 10 segundos
            if (tiempoTotal > 20.0f)
            {
                Circulo();
            }
            else if (tiempoTotal > 10.0f)
            {
                Estrella();
            }
            else
            {
                Espiral();
            }

            tiempoTotal -= disparoIntervalo;
        }
    }

    void Circulo()
    {
        disparoIntervalo = 1.0f;
        int numBalas = 36;
        float anguloInicial = 0.0f;
        float anguloSeparacion = 10.0f;

        for (int i = 0; i < numBalas; i++)
        {
            Quaternion rotacion = Quaternion.Euler(0, anguloInicial + i * anguloSeparacion, 0);
            GameObject bala = Instantiate(balaPrefab, spawnPoint.position, rotacion);
            Destroy(bala, 5.0f);
            IncrementarContadorBalas();
        }
    }

    void Estrella()
    {
        disparoIntervalo = 0.2f;
        int numBalas = 12;
        float anguloInicial = 0.0f;
        float anguloSeparacion = 30.0f;

        for (int i = 0; i < numBalas; i++)
        {
            Quaternion rotacion = Quaternion.Euler(0, anguloInicial + i * anguloSeparacion, 0);
            GameObject bala = Instantiate(balaPrefab, spawnPoint.position, rotacion);
            Destroy(bala, 5.0f);
            IncrementarContadorBalas();
        }
    }

    void Espiral()
    {
        disparoIntervalo = 0.1f;
        int numBalas = 8;
        float anguloSeparacion = 45.0f;

        for (int i = 0; i < numBalas; i++)
        {
            Quaternion rotacion = Quaternion.Euler(0, anguloInicialPatron3 + i * anguloSeparacion, 0);
            GameObject bala = Instantiate(balaPrefab, spawnPoint.position, rotacion);
            Destroy(bala, 5.0f);
            IncrementarContadorBalas();
        }
        anguloInicialPatron3 += 2.0f;
    }

    void IncrementarContadorBalas()
    {
        balasEnPantalla++;
        ActualizarTextoContadorBalas();
    }

    public void DecrementarContadorBalas()
    {
        balasEnPantalla--;
        ActualizarTextoContadorBalas();
    }

    void ActualizarTextoContadorBalas()
    {
        balasEnPantallaText.text = "Balas en pantalla: " + balasEnPantalla;
    }
}