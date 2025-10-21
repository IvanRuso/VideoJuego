using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamaraSegimiento : MonoBehaviour
{
    [SerializeField] private Transform target;
    private Vector3 offset;

    void LateUpdate()
    {
        transform.position = target.position + offset;
    }

}
