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
    public void Da�o(int Cantidad)
    {
        int EscudoDa�o = Cantidad;

        if (Escudo > 0)
        {
            Escudo -= EscudoDa�o;
            Debug.Log("Da�o recibido al Escudo. Escudo actual: " + Escudo);

            if (Escudo < 0)
            {
                EscudoDa�o = Mathf.Abs(Escudo); // Lo que queda de da�o
                Escudo = 0;
            }
            else
            {
                EscudoDa�o = 0; // Todo el da�o fue absorbido por el escudo
            }
        }

        // 2. Aplicar el da�o restante a la Vida
        if (EscudoDa�o > 0)
        {
            Vida -= EscudoDa�o;
            Debug.Log("Da�o recibido a la Vida. Vida actual: " + Vida);
        }

        // 3. Chequear el l�mite de vida y actualizar UI
        if (Vida < 0)
        {
            Vida = 0;
        }

        VidaActual(); // Llama a tu funci�n para actualizar los corazones/escudos en la UI

        if (Vida == 0)
        {
            Debug.Log("Sin vida (muerte)");
            // Aqu� va tu c�digo de muerte
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

            Debug.Log("Player fue golpeado por part�cula de Electricidad!");
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
