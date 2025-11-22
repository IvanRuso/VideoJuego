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
    public Material[] contorno;
    private int espacioInventario = 0;
    private int espacioAnterior = 1;


    //lista de items

    private BotiquinContador botiquin;
    private EscudoContador escudo;
    private GranadaContador granada;
    private TAccesoContador tAcceso;
    //lista de items


    // Start is called before the first frame update
    void Start()
    {
        botiquin = this.GetComponent<BotiquinContador>();
        escudo = this.GetComponent<EscudoContador>();
        granada= this.GetComponent<GranadaContador>();
        tAcceso = this.GetComponent<TAccesoContador>();

        //se hace trasparente todos los contornos ecepto en donde esta el espacioInventario (en este caso es el primer item, pero puede cambiarse)
        Color contornoApagar;
        contornoApagar = contorno[2].GetColor("_OutlineColor");
        contornoApagar.a = 0f;
        contorno[2].SetColor("_OutlineColor", contornoApagar);

        contornoApagar = contorno[3].GetColor("_OutlineColor");
        contornoApagar.a = 0f;
        contorno[3].SetColor("_OutlineColor", contornoApagar);

        contornoApagar = contorno[4].GetColor("_OutlineColor");
        contornoApagar.a = 0f;
        contorno[4].SetColor("_OutlineColor", contornoApagar);

    }

    // Update is called once per frame
    void Update()
    {
        //actualiza las imagens de los items cuando estos tinee 0 se oscurece
        disponibleItem();

        //desplazmiento a la izquierda en el inventario

        if (Input.GetKeyDown(KeyCode.Q) || Input.GetKeyDown(KeyCode.Joystick1Button4))//cuando se presione q o lb/l1 
        {
            if (espacioInventario > 0)
            {
                espacioAnterior = espacioInventario;
                espacioInventario--;//se movera al espacio a la izquierda en el inventario siempre y cuabdo este en una posion mayor a 0()extremo izquerdo del inventario
            }
            else
            {
                espacioAnterior = espacioInventario;
                espacioInventario = unidades.Length - 1;//lo desplaza al otro extremo del invetario
            }

            //Debug.Log("espacio en el inventario " + (espacioInventario + 1) + "/" + unidades.Length);
        }

        //desplazmiento a la derecha en el inventario
        if (Input.GetKeyDown(KeyCode.E) || Input.GetKeyDown(KeyCode.Joystick1Button5))//cuando se presione q o lb/l1 
        {
            if (espacioInventario < unidades.Length - 1)
            {
                espacioAnterior = espacioInventario;
                espacioInventario++;//se movera al espacio a la derecha en el inventario siempre y cuabdo este en una posion menor a extremo derecho del inventario
            }
            else
            {
                espacioAnterior = espacioInventario;
                espacioInventario = 0;//lo desplaza al otro extremo del invetario
            }
            //Debug.Log("espacio en el inventario " + (espacioInventario + 1) + "/" + unidades.Length);
        }
        seleccionItem(espacioInventario, espacioAnterior);

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
                //Debug.Log("espacio en el inventario "+ (itemId+1) + "/" + unidades.Length + " : se uso botiquin");
                break;
            case 1:
                escudo.RecuperarEscudo();
                //Debug.Log("espacio en el inventario " + (itemId + 1) + "/" + unidades.Length + " : se uso escudo");
                break;
            case 2:
                tAcceso.ActivaPuerta();
                //Debug.Log("espacio en el inventario " + (itemId + 1) + "/" + unidades.Length + " : se uso tarjeta de acceso");
                break;
            case 3:
                Debug.Log("espacio en el inventario " + (itemId + 1) + "/" + unidades.Length + " : se uso granada electrica");
                break;
            case 4:
                granada.LanzaGranada();
                //Debug.Log("espacio en el inventario " + (itemId + 1) + "/" + unidades.Length + " : se uso granada de humo");
                break;
        }
    }

    private void disponibleItem()//se encarga de oscurecer icono del item en el invtario cuando este sea 0 (el contorno aun es visible)
    {
        //botiquin
        if (botiquin.BotiquinJugador != 0)
        {
            inventario[0].color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
        }
        else
        {
            inventario[0].color = new Color(0.5f, 0.5f, 0.5f, 1.0f);
        }
        //escudos
        if (escudo.EscudosJugador != 0)
        {
            inventario[1].color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
        }
        else
        {
            inventario[1].color = new Color(0.5f, 0.5f, 0.5f, 1.0f);
        }
        //tarjeta acceso
        if (tAcceso.TAccesoJugador != 0)
        {
            inventario[2].color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
        }
        else
        {
            inventario[2].color = new Color(0.5f, 0.5f, 0.5f, 1.0f);
        }
        /*granada electrica
        if (botiquin.BotiquinJugador != 0)
        {
            inventario[3].color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
        }
        else
        {
            inventario[3].color = new Color(0.5f, 0.5f, 0.5f, 1.0f);
        }*/
        //granad Humo
        if (granada.GranadasJugador != 0)
        {
            inventario[4].color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
        }
        else
        {
            inventario[4].color = new Color(0.5f, 0.5f, 0.5f, 1.0f);
        }
    }

    private void seleccionItem(int itemId, int anteriorItemId)//se encarga de hacer el contorno del item seleccionado minetra que el anterior se hace tranparente
    {
        Color contornoItemActual;
        contornoItemActual = contorno[itemId].GetColor("_OutlineColor");
        contornoItemActual.a = 0.8f;
        contorno[itemId].SetColor("_OutlineColor", contornoItemActual);

        Color contornoItemAnterior;
        contornoItemAnterior = contorno[anteriorItemId].GetColor("_OutlineColor");
        contornoItemAnterior.a = 0f;
        contorno[anteriorItemId].SetColor("_OutlineColor", contornoItemAnterior);
    }


}
