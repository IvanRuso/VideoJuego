using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DañoGranada : MonoBehaviour
{
    private GranadaContador Explosion;

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("ROVICA"))
        {
               other.gameObject.SetActive(false);
            
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
