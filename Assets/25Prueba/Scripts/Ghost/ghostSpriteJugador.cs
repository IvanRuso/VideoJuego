using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ghostSpriteJugador : MonoBehaviour
{
    public static ghostSpriteJugador jugador;
    public GameObject ghost; //se asigana el prefab de ghostSprite
    public List<GameObject> pool = new List<GameObject>();//lista para almacenar los prefabs creados
    private float cronometro; //tiempo en que estan activas la sombras
    public float speed;//regular el timempo 
    public Color _color;

    // Start is called before the first frame update
    private void Awake()
    {
        jugador = this;// podremos llamer el script desde cualqeuir otro
    }

    public GameObject getGhosts()//clase para reutilizar los prefabs generados 
    {
        for (int i = 0; i < pool.Count; i++)
        {
            if (!pool[i].activeInHierarchy)//cada que un objeto de la lista este desactivado
            {
                pool[i].SetActive(true);//se activa el objeto
                pool[i].transform.position = this.transform.position;//se le da la posicion del jugador
                pool[i].transform.rotation = this.transform.rotation;//se le da la rotacion del jugador
                pool[i].GetComponent<SpriteRenderer>().sprite = this.GetComponent<SpriteRenderer>().sprite;//hacemos que el ghost tenga el mismo sprite que el jugadpr 
                pool[i].GetComponent<SolidColor>()._color = _color;// se le asigna el color a la sombra 
                return pool[i];
            }

        }
        //en el caso que los objetos acitivados sean mayor que los de la lista
        GameObject obj = Instantiate(ghost, transform.position, transform.rotation) as GameObject;//se intancio otro objeto ghost con la posion y rotacion del jugador
        obj.GetComponent<SpriteRenderer>().sprite = this.GetComponent<SpriteRenderer>().sprite;//hacemos que el ghost tenga el mismo sprite que el jugadpr 
        obj.GetComponent<SolidColor>()._color = _color;// se le asigna el color a la sombra
        pool.Add(obj);//se agreag este nuevo ghost a la lista
        return obj;
    }

    public void ghost_Skill()
    {
        cronometro += speed * Time.deltaTime;
        if (cronometro > 1)
        {
            getGhosts();
            cronometro = 0; 
        }

    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
