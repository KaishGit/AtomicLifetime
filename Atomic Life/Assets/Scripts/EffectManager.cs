using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectManager : MonoBehaviour
{

    public static EffectManager Instance;

    [SerializeField]
    private GameObject
        _explosionEffectPrefab,
        _shotEffectPrefab,
        _dashEffectPrefab,
        _boxEffectPrefab;


    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    private void CreateEffect(Vector3 position, GameObject effectPrefab)
    {
        //GameObject newEffect = Instantiate(effectPrefab, position, Quaternion.identity);
        GameObject newEffect = Instantiate(effectPrefab, new Vector3(position.x, position.y + 0.5f, position.z), Quaternion.identity);
        Destroy(newEffect, 2);
    }

    public void CreateExplosionEffect(Vector3 position)
    {
        CreateEffect(position, _explosionEffectPrefab);
    }

    public void CreateShotEffect(Vector3 position)
    {
        CreateEffect(position, _shotEffectPrefab);
    }

    public void CreateDashEffect(Vector3 position)
    {
        CreateEffect(position, _dashEffectPrefab);
    }

    public void CreateBoxEffect(Vector3 position)
    {
        CreateEffect(position, _boxEffectPrefab);
    }
}
