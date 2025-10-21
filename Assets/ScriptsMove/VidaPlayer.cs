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

}
