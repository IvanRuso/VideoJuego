using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MovePlayer : MonoBehaviour
{
    private Rigidbody rb;

    //MOVIMIENTO
    [SerializeField] private float velocidadMovimiento = 5;   //etiqueta para ver la variable velocidadMovimiento dentro de Unity 
    private float h, v; //h=horizontal v=vertical
    private Vector3 direccion; //variable donde se guarda el vector del movimiento
    [SerializeField] private float velocidadRotacion = 5;
    private Quaternion rotacion;

    //correr
    [SerializeField] private float velocidadSprint = 0.5f;    //Se refiere a cuanto sera el aumento de velocidad al correr (en %)
    private bool corriendo = false;
    private float correrStamina = 20; //establece cuanta stamina conume correr

    //agacharse
    [SerializeField] private float velocidadAgachar = 0.3f;    //Se refiere a cuanto sera la disminucion de velocidad al agacharse (en %) 
    [SerializeField] private float agacharYEscala = 0.5f;
    private float originalYEscala;
    private bool agachado = false;

    /*public Vector3 escalaFinal; // La escala a la que queremos llegar
    public float duracion = 0.5f; // El tiempo que tardará en alcanzar la escala final
    private Vector3 escalaInicial;
    private float tiempoTranscurrido;
    private float progreso;*/

    //dash
    private bool dashDisponible = true;
    private bool dash;
    [SerializeField] private float dashFuerza = 15f;
    [SerializeField] private float dashDuracion = 0.5f;
    [SerializeField] private float dashCooldown = 1f;
    private Vector3 dashDireccion;


    //SALTO
    [SerializeField] private float fuerzaSalto = 1;
    private bool quiereSaltar = false;

    public LayerMask capaSuelo;
    public Transform detectorSuelos;
    private float radioDetectorsuelos = 0.01f;
    private bool tocandoSuelo = false;

    [SerializeField] private float tiempoInicioSalto = 0.25f; //cuanto timepo queremos mantener el salto
    private float tiempoSaltando = 0; //medir el tiempo desde que se comenzo el salto
    //private bool estaSaltando; //saber si el usario esta saltando                                 //

    [SerializeField] public static int maxSaltos = 1;    //cuantos saltos podemos hacer antes de tocar el suelo
    private int numeroSalto; //cuantos saltos ha hecho el personaje antes de tocar el suelo

    //ELEMNETOS DE INTERFAZ

    //barra de stamina
    private float maxStamina = 100;
    private float staminaActual;
    public Slider barraStamina;
    

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();   //Busca el componente en el mismo nivel/inspector del obejor en el que se encuentra
        originalYEscala = transform.localScale.y;  //Guarda la escala en Y del jugador original

        //inicializando barra de stamina
        staminaActual = maxStamina;
        barraStamina.maxValue = maxStamina;
        barraStamina.value = staminaActual;
    }

    // Update is called once per frame
    void Update() //LOGICA
    {
        //evita que el jugador haga alguna accion mientras se hace el dash
        if (dash)
        {
            return;
        }

        //detccion del movimiento horizontal y vertical
        h = Input.GetAxisRaw("Horizontal"); // lee los controles que el usuario pulsa vlaores de 0 a 1/-1 en un framae
        v = Input.GetAxisRaw("Vertical");// los valores van incrementando poco a poco 


        //salto
        quiereSaltar = Input.GetButton("Jump");  // GetButtonDown ---> registra true cuanado se pulsa el boton solo una vez cada que se pulsa

        //tocando suelo
        tocandoSuelo = Physics.CheckSphere( //crea una esfera que avisa cuanod esta en contactocon algo
                detectorSuelos.position,    //posicion del centro de la esfera 
                radioDetectorsuelos,        //radio de detecion del suelo
                capaSuelo);                 //solo regresa respuesta si la esfera toca algo       

        if (Input.GetButtonUp("Jump")) // registra cuando el boton de salto dejo de ser pulsado
        {
            tiempoSaltando = 0;
            if (numeroSalto < maxSaltos) //si el numero de saltos que dio el personaje es nemor a la cantidad de saltos maximos pertidos antes de tocar el suelo (evita que se agregen saltos extra a los permitidos)
            {
                numeroSalto++;  //aumenta el numero de saltos dados por el usuario 
            }
        }
        if (tocandoSuelo == true)
        {  //reinicia la cantidad de saltos dados por el usuario cuando toca el suelo
            numeroSalto = 0;
        }

        //detecta cuando se esta agachado
        if (Input.GetButtonDown("Crouch"))
        {
            agachado = true;
        }
        if (Input.GetButtonUp("Crouch"))
        {
            agachado = false;
        }

        //detecta cuando se esta corriendo

        if (staminaActual > 0 ) // solo se puede correr cuabdo la stamina es mayor a 0 
        {
            if (Input.GetButtonDown("Sprint") && agachado == false)//solo se puede correr cuando no esta agachado 
            {
                corriendo = true;
            }
            if (Input.GetButtonUp("Sprint") && agachado == false)
            {
                corriendo = false;
            }
        }
        else { Debug.Log("no hay stamina"); }
        

        //dectecta cuando se hace el dash
        if (Input.GetButtonDown("Dash") && dashDisponible)
        {
            StartCoroutine(Dash());
        }
    }

    private void FixedUpdate()//FISICAS
    {
        //evita que el jugador haga alguna accion mientras se hace el dash
        if (dash)
        {
            return;
        }

        //moviminto horizontal y vertical
        direccion = new Vector3       //asigan la velocidad a jugador en los distintos ejes
            (h,   //eje x sentido se usa para invertir los controles cuando se tome el debuff de invertir controles
             0,   //eje y 
             v);  //eje z

        //Modificacion de la velocidad del jugador en basa a si esta corriendo, agachado o caminando
        if (corriendo && direccion.magnitude > 0.1f && barraStamina.value > 0)//detecta cuabdo se presion el boton de strpint(left shift) y evita gastar stamina si no se esta en movimiento 
        {
            rb.MovePosition(rb.position + direccion.normalized * (velocidadMovimiento * (1 + velocidadSprint)) * Time.fixedDeltaTime);//movimento al correr
            staminaActual -= correrStamina * Time.deltaTime;// cada segundo se consume la estamina equivalente al costo de correr (en este caso es 25, por lo cual puede correr por 4s)
            barraStamina.value = staminaActual;
            Debug.Log(staminaActual + "corriendo");
        }
        else if (agachado)//velocidad al agacharse
        {
            rb.MovePosition(rb.position + direccion.normalized * (velocidadMovimiento * (1 - velocidadAgachar)) * Time.fixedDeltaTime);//movimento al agacharse
        } else
        {
            rb.MovePosition(rb.position + direccion.normalized * velocidadMovimiento * Time.fixedDeltaTime);//movimento al caminar
        }

        //Modifica el tamaño del jugador al agacharse
        if (!agachado)//si no esta agachado la escala en y es la original
        {
            /*escalaInicial = new Vector3(transform.localScale.x, agacharYEscala, transform.localScale.z);
            escalaFinal = new Vector3(transform.localScale.x, originalYEscala, transform.localScale.z);
            
            // Calcula el progreso de la interpolación (un valor entre 0 y 1)
            tiempoTranscurrido += Time.deltaTime;
            progreso = Mathf.Clamp01(tiempoTranscurrido / duracion);

            // Interpola la escala actual entre la escala inicial y la final
            transform.localScale = Vector3.Lerp(escalaInicial, escalaFinal, progreso);*/
            transform.localScale = new Vector3(transform.localScale.x, originalYEscala, transform.localScale.z);
        }
        else if (agachado)//si esta agachado la escala en y es la escala agachada
        {
            transform.localScale = new Vector3(transform.localScale.x, agacharYEscala, transform.localScale.z);
        }

        //Rotacion del jugador en la direccion que se mueve
        if (direccion.magnitude > 0.1f) //si la magnitud del vector de direccion es mayor que 0.1f el personaje rotara es esa direccion, manteniedo la rotacion
        {
            rotacion = Quaternion.LookRotation(direccion);  //obtiene la rotacion ue tendra el presonaje en base a al vector generado en el movimiento
            rb.transform.rotation = Quaternion.Slerp(transform.rotation, rotacion, velocidadRotacion * Time.fixedDeltaTime); //suavica la animacion de rotacion del personaje 
        }


        //salto
        if (quiereSaltar)
        {
            if (tocandoSuelo || numeroSalto < maxSaltos)
            {
                saltoCargado();
            }
        }
    }

    private void saltoCargado()
    {
        if (tiempoSaltando < tiempoInicioSalto)
        {
            rb.velocity = new Vector3(0, fuerzaSalto, 0);   //salto
            tiempoSaltando += Time.fixedDeltaTime;  //se le suma el timepo que se lleva desde que se inicio el salto
        }
    }

    private IEnumerator Dash()
    {
        dashDisponible = false;
        dash = true;
        dashDireccion = transform.forward;
        rb.AddForce(dashDireccion * dashFuerza, ForceMode.VelocityChange);//aplicando impluso 
        Debug.Log("dash no disponible");
        yield return new WaitForSeconds(dashDuracion);//solo se aplica por la duracion del dash

        dash = false;
        yield return new WaitForSeconds(dashCooldown);

        dashDisponible = true;
        Debug.Log("dash disponible");
    }
}
