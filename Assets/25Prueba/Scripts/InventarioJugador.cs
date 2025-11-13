using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class InventarioJugador : MonoBehaviour
{
    public Image[] inventario;
    public TextMeshProUGUI[] unidades;
    private int espacioInventario;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //desplazmiento a la izquierda en el inventario
        if (Input.GetButtonDown("InventarioIzquierda"))//cuando se presione q o lb/l1 
        {
            if (espacioInventario >= 0)
            {
                espacioInventario--;//se movera al espacio a la izquierda en el inventario siempre y cuabdo este en una posion mayor a 0()extremo izquerdo del inventario
            }
            else 
            {
                espacioInventario = unidades.Length - 1;//lo desplaza al otro extremo del invetario
            }
        }

        //desplazmiento a la derecha en el inventario
        if (Input.GetButtonDown("InventarioDerecha"))//cuando se presione q o lb/l1 
        {
            if (espacioInventario <= unidades.Length-1)
            {
                espacioInventario++;//se movera al espacio a la derecha en el inventario siempre y cuabdo este en una posion menor a extremo derecho del inventario
            }
            else
            {
                espacioInventario = 0;//lo desplaza al otro extremo del invetario
            }
        }

        Debug.Log(espacioInventario);
    }


}
