using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using TMPro;
using UnityEngine;

public class GranadaContador : MonoBehaviour
{
    public TextMeshProUGUI Granadas;
    public int GranadasJugador = 0;

    //Prueba
    public GameObject GranadaPrefab;
    public Transform PuntoLanzamiento;
    public float FLanzamiento = 5f;

    public float Explosion = 3f;
    // Start is called before the first frame update
    void Start()
    {
        ActualizarPantalla();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha3) || Input.GetKeyDown(KeyCode.Keypad3))
        {
            LanzaGranada();
        }
    }

    private void LanzaGranada()
    {
        if (GranadasJugador == 0)
        {
            //mensajePantalla.mensaje = "No Hay Botiquin";
            Debug.Log(" X " + GranadasJugador);
            return;
        }

        if (GranadasJugador >= 0)
        {
            if(GranadaPrefab == null)
            {
                return;
            }
            Vector3 PosicionSpawn = (PuntoLanzamiento != null) ? PuntoLanzamiento.position : transform.position;

            //Prueba Granada Nueva
            GameObject GranadaNueva = Instantiate(
                GranadaPrefab,
                PosicionSpawn,
                Quaternion.identity
                );
           
            GranadaNueva.tag = "ProyectilGranada";
            Destroy(GranadaNueva.GetComponent<Granadas>());

            //Prueba
            GranadaExplosion Efecto = GranadaNueva.GetComponent<GranadaExplosion>();

            if (Efecto != null)
            {
                Efecto.Explota = true;
            }
            //Prueba

            Rigidbody rb = GranadaNueva.GetComponent<Rigidbody>();
            if (rb!=null)
            {
                rb.useGravity = true;
                rb.AddForce(transform.forward * FLanzamiento, ForceMode.Impulse);
            }

            Destroy(GranadaNueva, Explosion);

            //Termina Prueba

            GranadasJugador--;
            ActualizarPantalla();

            Debug.Log(" X " + GranadasJugador);
        }
    }

    public void Actualiza(int Agrega=1)
    {
        GranadasJugador += Agrega;
        ActualizarPantalla();
    }
    private void ActualizarPantalla()
    {
        if (Granadas != null)
        {
            Granadas.text = "X " + GranadasJugador.ToString();
        }
        else
        {
            Debug.LogError("El TextMeshProUGUI no esta asignado en el Inspector.");
        }
    }

}
