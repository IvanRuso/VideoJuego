using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using static UnityEditor.Progress;

public class InventarioJugador : MonoBehaviour
{
    public Image[] inventario;
    public TextMeshProUGUI[] unidades;
    private int espacioInventario = 0;

    //lista de items

    private BotiquinContador botiquin;
    private EscudoContador escudo;
    private GranadaContador granada;
    private TAccesoContador tAcceso;

    // Start is called before the first frame update
    void Start()
    {
        botiquin = this.GetComponent<BotiquinContador>();
        escudo = this.GetComponent<EscudoContador>();
        granada= this.GetComponent<GranadaContador>();
        tAcceso = this.GetComponent<TAccesoContador>();
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
            Debug.Log("espacio en el inventario " + (espacioInventario + 1) + "/" + unidades.Length);
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
            Debug.Log("espacio en el inventario " + (espacioInventario + 1) + "/" + unidades.Length);
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
                botiquin.RecuperarVida();
                Debug.Log("espacio en el inventario "+ (itemId+1) + "/" + unidades.Length + " : se uso botiquin");
                break;
            case 1:
                escudo.RecuperarEscudo();
                Debug.Log("espacio en el inventario " + (itemId + 1) + "/" + unidades.Length + " : se uso escudo");
                break;
            case 2:
                tAcceso.ActivaPuerta();
                Debug.Log("espacio en el inventario " + (itemId + 1) + "/" + unidades.Length + " : se uso tarjeta de acceso");
                break;
            case 3:
                Debug.Log("espacio en el inventario " + (itemId + 1) + "/" + unidades.Length + " : se uso granada electrica");
                break;
            case 4:
                granada.LanzaGranada();
                Debug.Log("espacio en el inventario " + (itemId + 1) + "/" + unidades.Length + " : se uso granada de humo");
                break;
        }
    }


}
