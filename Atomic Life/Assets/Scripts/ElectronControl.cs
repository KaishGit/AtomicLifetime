using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElectronControl : MonoBehaviour
{
    [SerializeField]
    private float _speed;

    void Start()
    {
    }

    void Update()
    {
        transform.Rotate(_speed * 100 * Time.deltaTime, 0, 0);
    }

}

