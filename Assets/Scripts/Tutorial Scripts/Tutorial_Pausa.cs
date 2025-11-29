using UnityEngine;
using TMPro;

public class Tutorial_Pausa : MonoBehaviour
{
    // Asigna este TextMeshProUGUI en el Inspector
    public TextMeshProUGUI TutorialText;

    // Una variable booleana para rastrear si el texto está visible
    private bool isTextVisible = true;



    // Start se llama antes del primer frame update
    void Start()
    {
        if (TutorialText != null)
        {
            // Establecer el texto inicial y asegurarse de que esté visible al inicio
            TutorialText.gameObject.SetActive(true);
        }
        else
        {
            Debug.LogError("TutorialText no asignado en el Inspector.");
            enabled = false; // Desactivar el script si falta la referencia
        }
    }

    // Update se llama una vez por frame
    void Update()
    {
        // 1. Detectar si se presiona la tecla ESC
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            // 2. Llamar a la función para alternar la visibilidad
            ToggleTextVisibility();
        }
    }

    private void ToggleTextVisibility()
    {
        // Invertir el estado
        isTextVisible = !isTextVisible;

        // Aplicar el nuevo estado al objeto del texto
        TutorialText.gameObject.SetActive(isTextVisible);

        if (isTextVisible)
        {
            Debug.Log("Tutorial Estático Visible.");
        }
        else
        {
            Debug.Log("Tutorial Estático Oculto (Pausado).");
        }
    }
}