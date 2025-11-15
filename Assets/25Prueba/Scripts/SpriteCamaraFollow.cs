
using UnityEngine;

public class SpriteCamaraFollow : MonoBehaviour
{   
    [SerializeField] private bool FreezeXZAxis = true;

    void LateUpdate()//se actualiza despues del movimineto de la camara

    {
        if (FreezeXZAxis)
        {
            this.transform.rotation = Quaternion.Euler(0f, Camera.main.transform.rotation.y, 0f);//hace que el sprite siga la camara de forma horizontal
        }
        else 
        {
            this.transform.rotation = Camera.main.transform.rotation;//hace que el sprite siga a la camara tanto horizontal como verticalmente          
        }
    }
}
