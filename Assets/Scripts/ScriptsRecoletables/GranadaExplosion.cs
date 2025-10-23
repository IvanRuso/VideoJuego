using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GranadaExplosion : MonoBehaviour
{
    public GameObject ExplosionGranada;

    [HideInInspector]
    public bool Explota = false;
    public float Explosion = 1f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnDestroy()
    {
        if (Application.isPlaying && ExplosionGranada != null && Explota)
        {
            GameObject efecto = Instantiate(
            ExplosionGranada,
            transform.position,
            Quaternion.identity
            );


            Destroy(efecto, Explosion);
        }
    }
}
