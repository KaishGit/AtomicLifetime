using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InterrupterControl : MonoBehaviour
{
    [SerializeField]
    private GameObject _wallPassage;


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
            Destroy(_wallPassage);
            GetComponent<Collider>().enabled = false;
            //Todo: Animation button down
            TimeManager.Instance.DecreaseTime(10);
            SfxManager.Instance.PlaySfxLoss();
            GameManager.Instance.ShowEventTextRed("10s Lifetime Sacrificed");
        }     
    }
}
