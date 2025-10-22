using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;
//using UnityEngine.InputSystem;

public class FullScreenController : MonoBehaviour
{
    [Header("Stats de Tiempo")]
    [SerializeField] private float healDisplayTime = 1.5f;
    [SerializeField] private float healFadeOutTime = 0.5f;

    [Header("Referencias")]
    //[SerializeField] private UniversalRendererData rendererData;
    [SerializeField] private ScriptableRendererFeature fullScreenShield;
    [SerializeField] private ScriptableRendererFeature fullScreenHeal;
    [SerializeField] private ScriptableRendererFeature fullScreenDamage;
    [SerializeField] private Material material;
    [SerializeField] private Material[] materials;

   
    
    

    [Header("Stats de Intensidad")]
    [SerializeField] private float voronolIntensityStat = 2.5f;
    [SerializeField] private float vignetteIntensityStat = 1.25f;

    private int voronolIntensity = Shader.PropertyToID("_VoronolIntensity");
    private int vignetteIntensity = Shader.PropertyToID("_VignetteIntensity");

    // Start is called before the first frame update
    void Start()
    {
        fullScreenHeal.SetActive(false);//inicializa el script desactivado
        fullScreenShield.SetActive(false);
        fullScreenDamage.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator Status(int estado)
    {
        switch (estado)
        {
            case 1:
                material = materials[0];
                fullScreenHeal.SetActive(true);
                break;
            case 2:
                material = materials[1];
                fullScreenShield.SetActive(true);
                break;
            case 3:
                material = materials[2];
                fullScreenDamage.SetActive(true);
                break;
            default:
                break;
        }
        material.SetFloat(voronolIntensity, voronolIntensityStat);
        material.SetFloat(vignetteIntensity, vignetteIntensityStat);

        yield return new WaitForSeconds(healDisplayTime);

        float elapsedTime = 0f;
        while (elapsedTime < healFadeOutTime)
        {
            elapsedTime += Time.deltaTime;

            float LerpedVonorol = Mathf.Lerp(voronolIntensityStat, 0f, (elapsedTime / healFadeOutTime));
            float LerpedVignette = Mathf.Lerp(vignetteIntensityStat, 0f, (elapsedTime / healFadeOutTime));
            material.SetFloat(voronolIntensity, LerpedVonorol);
            material.SetFloat(vignetteIntensity, LerpedVignette);

            yield return null;
        }
        switch (estado)
        {
            case 1:
                fullScreenHeal.SetActive(false);
                break;
            case 2:
                fullScreenShield.SetActive(false);
                break;
            case 3:
                fullScreenDamage.SetActive(false);
                break;
            default:
                break;
        }
    }

   

    /*private IEnumerator heal()
    {
        material = materials[0];
        fullScreenHeal.SetActive(true);
        material.SetFloat(voronolIntensity, voronolIntensityStat);
        material.SetFloat(vignetteIntensity, vignetteIntensityStat);

        yield return new WaitForSeconds(healDisplayTime);

        float elapsedTime = 0f;
        while (elapsedTime < healFadeOutTime)
        {
            elapsedTime += Time.deltaTime;

            float LerpedVonorol = Mathf.Lerp(voronolIntensityStat, 0f, (elapsedTime / healFadeOutTime));
            float LerpedVignette = Mathf.Lerp(vignetteIntensityStat, 0f, (elapsedTime / healFadeOutTime));
            material.SetFloat(voronolIntensity, LerpedVonorol);
            material.SetFloat(vignetteIntensity, LerpedVignette);

            yield return null;
        }
        fullScreenHeal.SetActive(false);
       
        coroutine = null;
    }

    private IEnumerator shield()
    {
        material = materials[1];
        fullScreenShield.SetActive(true);
        material.SetFloat(voronolIntensity, voronolIntensityStat);
        material.SetFloat(vignetteIntensity, vignetteIntensityStat);

        yield return new WaitForSeconds(healDisplayTime);

        float elapsedTime = 0f;
        while (elapsedTime < healFadeOutTime)
        {
            elapsedTime += Time.deltaTime;

            float LerpedVonorol = Mathf.Lerp(voronolIntensityStat, 0f, (elapsedTime / healFadeOutTime));
            float LerpedVignette = Mathf.Lerp(vignetteIntensityStat, 0f, (elapsedTime / healFadeOutTime));
            material.SetFloat(voronolIntensity, LerpedVonorol);
            material.SetFloat(vignetteIntensity, LerpedVignette);

            yield return null;
        }

        fullScreenShield.SetActive(false);
    }

    private IEnumerator damage()
    {
        material = materials[2];
        fullScreenDamage.SetActive(true);
        material.SetFloat(voronolIntensity, voronolIntensityStat);
        material.SetFloat(vignetteIntensity, vignetteIntensityStat);

        yield return new WaitForSeconds(healDisplayTime);

        float elapsedTime = 0f;
        while (elapsedTime < healFadeOutTime)
        {
            elapsedTime += Time.deltaTime;

            float LerpedVonorol = Mathf.Lerp(voronolIntensityStat, 0f, (elapsedTime / healFadeOutTime));
            float LerpedVignette = Mathf.Lerp(vignetteIntensityStat, 0f, (elapsedTime / healFadeOutTime));
            material.SetFloat(voronolIntensity, LerpedVonorol);
            material.SetFloat(vignetteIntensity, LerpedVignette);

            yield return null;
        }

        fullScreenDamage.SetActive(false);
    }*/
}
