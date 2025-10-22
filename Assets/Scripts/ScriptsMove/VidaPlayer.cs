using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VidaPlayer : MonoBehaviour
{
    //Puntos de vida
    public Image[] Corazones;
    public int VidaMaxima = 3;
    public int Vida = 3;

    //Puntos de escudo
    public Image[] Escudos;
    public int EscudoMaxima = 2;
    public int Escudo = 2;



    void Start()
    {

        VidaActual();
    }

    //Prueba
    public void Daño(int Cantidad)
    {
        int EscudoDaño = Cantidad;

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
        }
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

}
