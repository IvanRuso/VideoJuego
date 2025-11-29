using UnityEngine;

public class DireccionAnimacion : MonoBehaviour
{
    public Animator RSE;
    public SpriteRenderer Renderizado;
    //public GameObject ROVICA;
    public AIROVICA AIAngulo;
   

    void Update()
    {

        Vector3 f = transform.forward;
        float ang = AIAngulo.AnguloFrontal;
        if (ang < 0) ang += 360;

        float x = 0;
        float y = 0;

        if (ang >= 337.5f || ang < 22.5f)
        { x = 0; y = 1; }
        else if (ang >= 22.5f && ang < 67.5f)
        { x = 1; y = 1; }
        else if (ang >= 67.5f && ang < 112.5f)
        { x = 1; y = 0; }
        else if (ang >= 112.5f && ang < 157.5f)
        { x = 1; y = -1; }
        else if (ang >= 157.5f && ang < 202.5f)
        { x = 0; y = -1; }
        else if (ang >= 202.5f && ang < 247.5f)
        { x = -1; y = -1; }
        else if (ang >= 247.5f && ang < 292.5f)
        { x = -1; y = 0; }
        else if (ang >= 292.5f && ang < 337.5f)
        { x = -1; y = 1; }

        RSE.SetFloat("moveX", x);
        RSE.SetFloat("moveY", y);
    }
    private void Start()
    {
        
        AIAngulo = this.GetComponentInParent<AIROVICA>();
        RSE = this.GetComponent<Animator>();
        Renderizado = this.GetComponent <SpriteRenderer>();
    }
}