using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerShot : MonoBehaviour
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
            GameManager.Instance.ShowEventTextBlue("+1 Shot Power");
            SfxManager.Instance.PlaySfxPowerUp();
            PowerUpManager.Instance.AddPowerUp(PowerUp.Shot);
            EffectManager.Instance.CreateShotEffect(transform.position);
            Destroy(gameObject);
        }
    }
}
