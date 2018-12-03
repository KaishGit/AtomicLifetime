using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadioativeZone : MonoBehaviour
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
            GameManager.Instance.ShowEventTextYellow("Radioactivite: -70% Speed (3s)");
            SfxManager.Instance.PlaySfxLoss();
            other.GetComponent<AtomControl>().ActiveSlowSpeed();
        }
    }
}
