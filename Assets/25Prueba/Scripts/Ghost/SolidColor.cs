using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SolidColor : MonoBehaviour
{
    private SpriteRenderer myRenderer;
    private Shader myMaterial;
    public Color _color;

    // Start is called before the first frame update
    void Start()
    {
        myRenderer = this.GetComponent<SpriteRenderer>();
        myMaterial = Shader.Find("GUI/Text Shader"); 
    }

    void ColorSprite()
    {
        myRenderer.material.shader = myMaterial;
        myRenderer.color = _color;
    }

    public void Finish() //desactiva la sombra al final de la animacion
    {
        this.gameObject.SetActive(false);
    }
        
    // Update is called once per frame
    void Update()
    {
        ColorSprite();
    }
}
