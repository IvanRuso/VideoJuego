using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cofre : MonoBehaviour
{
    public GameObject[] Recursos;

    public float Distancia = 1.0f;

    private bool Abierto = false;
    void Start()
    {
        Abierto = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Logica Interacción
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                AbrirCofre();
            }
        }
    }


    // Logica del Drop
    public void AbrirCofre()
    {
        if (Abierto)
        {
            return;
        }

        int randomIndex = Random.Range(0,Recursos.Length);
        GameObject Drop = Recursos[randomIndex];

        Vector3 Spawn = transform.position + Vector3.back * Distancia;
        Instantiate(Drop, Spawn, Quaternion.identity);

        Abierto = true;
       
    }
}
