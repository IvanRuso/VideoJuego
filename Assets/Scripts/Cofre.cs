using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cofre : MonoBehaviour
{
    public GameObject[] Recursos;

    public Transform Cofre_Tapa;

    public float DistanciaH = 1.0f;
    public float DistanciaV = 1.0f;

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
        if (Abierto)
        {
            return;
        }

        if (other.CompareTag("Player"))
        {
            if (Input.GetButtonDown("Fire2") && !Abierto)
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

        Vector3 SpawnH = transform.position + transform.forward * DistanciaH;

        Vector3 SpwanReal = SpawnH + Vector3.up * DistanciaV;

        Instantiate(Drop, SpwanReal, Quaternion.identity);

        if (Cofre_Tapa != null)
        {
            Cofre_Tapa.Rotate(0f, 25f, 0f, Space.Self);
        }

        Abierto = true;
       
    }
}
