using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Tutorial_Controlador : MonoBehaviour
{
    public TextMeshProUGUI TutorialText;
    

    private const string M2 = "Desplázate con la cruceta y navega por tu inventario con Q y E";
    private const string M3 = "Presiona Shift para correr" +
                              " Ctrl para barrerte";
    private const string M4 = "Presiona F para utilizar el inventario";

   

    private const float Espera = 5f;
    // Start is called before the first frame update
    void Start()
    {
        if (TutorialText != null)
        {
            StartCoroutine(SecuenciaTutorial());
        }
        else
        {
            Debug.LogError("No asignado");
        }
    }
    
    private IEnumerator SecuenciaTutorial()
    {

        TutorialText.text = M2;
        yield return new WaitForSeconds(Espera);

        // 3. Mostrar Mensaje 3
        TutorialText.text = M3;
        yield return new WaitForSeconds(Espera);

        // 4. Mostrar Mensaje 4
        TutorialText.text = M4;
        yield return new WaitForSeconds(Espera);

        // 5. Opcional: Desaparecer el texto al finalizar
        TutorialText.gameObject.SetActive(false);

        Debug.Log("Secuencia de tutorial finalizada.");
    }
}
