using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutOutMuros : MonoBehaviour
{
    [SerializeField] private Renderer RenderMuro;
    [SerializeField] public Material[] MaterialsMuro;

    //bool dentro=false;

    // Start is called before the first frame update
    void Start()
    {
        RenderMuro = GetComponent<Renderer>();    
    }

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject.CompareTag("Player")) // Use CompareTag for performance
        {
            Debug.Log("jugador detras del muro");
            RenderMuro.material = MaterialsMuro[0];
        }
        
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player")) // Use CompareTag for performance
        {
            Debug.Log("jugador salio de detras del muro");
            RenderMuro.material = MaterialsMuro[1];
        }
    }



}
