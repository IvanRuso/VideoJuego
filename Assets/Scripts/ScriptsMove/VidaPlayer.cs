using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class VidaPlayer : MonoBehaviour
{
    //Puntos de vida
    public Image[] Corazones;
    public int VidaMaxima = 3;
    private int Vida = 3;

    //Puntos de escudo
    public Image[] Escudos;
    public int EscudoMaxima = 2;
    public int Escudo = 2;

    private FullScreenController FullScreenController;

    void Start()
    {
        GameObject playerObject = GameObject.FindGameObjectWithTag("ScreenEffect");
        if (playerObject != null)
        {
            FullScreenController = playerObject.GetComponent<FullScreenController>();
        }
        else
        {
            Debug.LogError("No se encontro un objeto con la etiqueta 'Player' que tenga el script VidaJugador");
        }

        VidaActual();
    }

    //Prueba
    public void Daño(int Cantidad)
    {
        if (Escudo >= 1)
        {
            Escudo -= Cantidad;
            StartCoroutine(FullScreenController.Status(3));
        }
        else
        {
            Vida -= Cantidad;
            StartCoroutine(FullScreenController.Status(3));
        }

        if (Vida < 0)
        {
            Vida = 0;
        }
        if (Escudo < 0)
        {
            Escudo = 0;
        }




        VidaActual();

        /*int EscudoDaño = Cantidad;

        if (Escudo > 0)
        {
            Escudo -= EscudoDaño;
            Debug.Log("Daño recibido al Escudo. Escudo actual: " + Escudo);

            if (Escudo < 0)
            {
                EscudoDaño = Mathf.Abs(Escudo); // Lo que queda de daño
                Escudo = 0;
            }
            else
            {
                EscudoDaño = 0; // Todo el daño fue absorbido por el escudo
            }
        }

        // 2. Aplicar el daño restante a la Vida
        if (EscudoDaño > 0)
        {
            Vida -= EscudoDaño;
            Debug.Log("Daño recibido a la Vida. Vida actual: " + Vida);
        }

        // 3. Chequear el límite de vida y actualizar UI
        if (Vida < 0)
        {
            Vida = 0;
        }

        VidaActual(); // Llama a tu función para actualizar los corazones/escudos en la UI

        if (Vida == 0)
        {
            Debug.Log("Sin vida (muerte)");
            // Aquí va tu código de muerte
        }*/
    } //Prueba

    private void VidaActual()
    {
        //puntos de vida
        for (int i = 0; i < VidaMaxima; i++) 
        {
            if (i < Vida)
            {
                Corazones[i].enabled = true;
            }
            else
            {
                Corazones[i].enabled = false;
            }
        }
        //puntos de escudo
        for (int i = 0; i < EscudoMaxima; i++)
        {
            if (i < Escudo)
            {
                Escudos[i].enabled = true;
            }
            else
            {
                Escudos[i].enabled = false;
            }
        }
    }

    public bool RecuperarVida(int amount)
    {

        if (Vida >= VidaMaxima)
        {
            Debug.Log("Maximo");
            return false;
        }


        Vida += amount;


        if (Vida > VidaMaxima)
        {
            Vida = VidaMaxima;
        }


        VidaActual();

        Debug.Log("Vida Curada. Vida actual: " + Vida);
        return true;
    }

    public bool RecuperarEscudo(int amount)
    {

        if (Escudo >= EscudoMaxima)
        {
            Debug.Log("Maximo");
            return false;
        }


        Escudo += amount;


        if (Escudo > EscudoMaxima)
        {
            Escudo = EscudoMaxima;
        }


        VidaActual();

        Debug.Log("Escudo Regenerado. Escudo actual: " + Vida);
        return true;
    }
    /*private void OnParticleCollision(GameObject other)
        {
            int Particulas = 1;
            damage(Particulas);

            Debug.Log("Player fue golpeado por partícula de Electricidad!");
        }
    /*
        public void damage(int amount)
        {
            Vida -= amount;

            if (Vida < 0)
            {
                Vida = 0;
            }


            VidaActual();

            Debug.Log("Vida Perdida. Vida actual: " + Vida);

            if (Vida == 0)
            {

                Debug.Log("Sin vida");
            }
        }
        */
    void Update()
    {
        if(Vida == 0)
        {
            string sceneName = SceneManager.GetActiveScene().name;
            SceneManager.LoadScene(sceneName, LoadSceneMode.Single);
        }
        
    }

}
