﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtomPartnerControl : MonoBehaviour
{
    void Start()
    {

    }

    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.Instance.WinStage();
        }
    }
}
