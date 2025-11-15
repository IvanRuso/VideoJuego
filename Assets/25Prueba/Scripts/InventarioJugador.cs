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
    private int espacioInventario = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //desplazmiento a la izquierda en el inventario
        if (Input.GetKeyDown(KeyCode.Q) || Input.GetKeyDown(KeyCode.Joystick1Button4))//cuando se presione q o lb/l1 
        {
            if (espacioInventario > 0)
            {
                espacioInventario--;//se movera al espacio a la izquierda en el inventario siempre y cuabdo este en una posion mayor a 0()extremo izquerdo del inventario
            }
            else 
            {
                espacioInventario = unidades.Length - 1;//lo desplaza al otro extremo del invetario
            }
        }

        //desplazmiento a la derecha en el inventario
        if (Input.GetKeyDown(KeyCode.E) || Input.GetKeyDown(KeyCode.Joystick1Button5))//cuando se presione q o lb/l1 
        {
            if (espacioInventario < unidades.Length-1)
            {
                espacioInventario++;//se movera al espacio a la derecha en el inventario siempre y cuabdo este en una posion menor a extremo derecho del inventario
            }
            else
            {
                espacioInventario = 0;//lo desplaza al otro extremo del invetario
            }
        }

        if (Input.GetKeyDown(KeyCode.F) || Input.GetKeyDown(KeyCode.Joystick1Button0))//cuando se presione F o A/ equis
        {
            UsarItem(espacioInventario);
        }


    }

    private void UsarItem( int itemId) 
    {
        switch (itemId) 
        {
            case 0:
                Debug.Log("espacio en el inventario "+ (itemId+1) + "/" + unidades.Length + " : se uso botiquin");
                break;
            case 1:
                Debug.Log("espacio en el inventario " + (itemId + 1) + "/" + unidades.Length + " : se uso escudo");
                break;
            case 2:
                Debug.Log("espacio en el inventario " + (itemId + 1) + "/" + unidades.Length + " : se uso tarjeta de acceso");
                break;
            case 3:
                Debug.Log("espacio en el inventario " + (itemId + 1) + "/" + unidades.Length + " : se uso granada electrica");
                break;
            case 4:
                Debug.Log("espacio en el inventario " + (itemId + 1) + "/" + unidades.Length + " : se uso granada de humo");
                break;
        }
    }


}
