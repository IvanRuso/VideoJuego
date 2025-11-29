using System.Collections;
using UnityEngine;
using TMPro;

public class Tutorial_Controlador : MonoBehaviour
{
    public TextMeshProUGUI TutorialText;

    // Variables para controlar la corutina y la pausa
    private Coroutine tutorialCoroutine;
    private bool isPaused = false;

    // Almacena el paso actual de la secuencia
    private int currentStep = 0;

    // Array de mensajes para iterar más fácilmente
    private string[] tutorialMessages;

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
            // Inicializar el array de mensajes
            tutorialMessages = new string[] { M2, M3, M4 };

            // Almacenar la referencia a la corutina
            tutorialCoroutine = StartCoroutine(SecuenciaTutorial());
        }
        else
        {
            Debug.LogError("TutorialText no asignado en el Inspector.");
        }
    }

    // Update se llama una vez por frame
    void Update()
    {
        // Detectar si se presiona la tecla ESC
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePause();
        }
    }

    private void TogglePause()
    {
        isPaused = !isPaused; // Invertir el estado de pausa

        if (isPaused)
        {
            // Pausar: Detener la corutina y hacer desaparecer el texto.
            if (tutorialCoroutine != null)
            {
                StopCoroutine(tutorialCoroutine);

                // ⭐ CAMBIO CLAVE: Hacemos desaparecer el objeto de texto
                TutorialText.gameObject.SetActive(false);
                // Alternativamente, podrías dejarlo activo pero con el texto vacío:
                // TutorialText.text = ""; 

                Debug.Log("Tutorial Pausado en el paso: " + currentStep + ". Texto oculto.");
            }
        }
        else
        {
            // Reanudar: Volver a hacer visible el objeto y reanudar la corutina.
            // ⭐ CAMBIO CLAVE: Volver a hacer visible el objeto de texto
            TutorialText.gameObject.SetActive(true);

            tutorialCoroutine = StartCoroutine(SecuenciaTutorial());
            Debug.Log("Tutorial Reanudado desde el paso: " + currentStep);
        }
    }

    private IEnumerator SecuenciaTutorial()
    {
        // Aseguramos que el componente de texto esté visible
        // (Esto es necesario para el caso de reanudar)
        TutorialText.gameObject.SetActive(true);

        // Bucle que itera desde el 'currentStep' registrado hasta el final
        for (int i = currentStep; i < tutorialMessages.Length; i++)
        {
            // 1. ACTUALIZAR PASO: Guardar el índice actual
            currentStep = i;

            // 2. Mostrar el mensaje
            TutorialText.text = tutorialMessages[i];

            // 3. Esperar
            yield return new WaitForSeconds(Espera);
        }

        // Si el bucle finaliza:

        // 4. Limpiar y desaparecer el texto al finalizar
        TutorialText.gameObject.SetActive(false);
        TutorialText.text = "";

        // 5. Resetear el paso y la referencia de corutina
        currentStep = 0;
        tutorialCoroutine = null;

        Debug.Log("Secuencia de tutorial finalizada.");
    }
}