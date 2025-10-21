using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Escudos : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Player"))
        {

            EscudoContador escudoContador = collision.GetComponent<EscudoContador>();

            if (escudoContador != null)
            {
                escudoContador.Actualiza(1);

                Destroy(this.gameObject);
            }
            else
            {
                Debug.LogError("Error");

            }
        }
    }
}
