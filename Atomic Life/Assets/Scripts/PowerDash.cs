using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerDash : MonoBehaviour
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
            GameManager.Instance.ShowEventTextBlue("+1 Dash Power");
            SfxManager.Instance.PlaySfxPowerUp();
            PowerUpManager.Instance.AddPowerUp(PowerUp.Dash);
            EffectManager.Instance.CreateDashEffect(transform.position);
            Destroy(gameObject);
        }
    }
}
