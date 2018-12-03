using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotControl : MonoBehaviour
{
    [SerializeField]
    private float _speed;

    void Start()
    {
        Destroy(gameObject, 5);
    }

    void Update()
    {
        transform.Translate(Vector3.forward * _speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            return;
        }

        if (other.CompareTag("Enemy"))
        {
            if (other.isTrigger)
                return;

            GameManager.Instance.ShowEventTextBlue("Decayment: +10s Lifetime");
            SfxManager.Instance.PlaySfxExplosion();
            TimeManager.Instance.IncreaseTime(10);
            EffectManager.Instance.CreateExplosionEffect(other.gameObject.transform.position);
            other.gameObject.GetComponent<EnemyAtomControl>().ActiveIdleState();
            Destroy(gameObject);
        }

    }
}
