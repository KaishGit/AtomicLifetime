using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxControl : MonoBehaviour
{
    private GameObject _player;


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
            DisableBoxComponent();
            _player = other.gameObject;
            TimeManager.Instance.DecreaseTime(10);
            GameManager.Instance.ShowEventTextRed("10s Lifetime Sacrificed");
            SfxManager.Instance.PlaySfxLoss();
            EffectManager.Instance.CreateBoxEffect(transform.position);
            StartCoroutine(WaitForShowEvent());
        }
    }

    private IEnumerator WaitForShowEvent()
    {
        yield return new WaitForSeconds(1.5f);
        if (_player != null)
            SortDrop();
        Destroy(gameObject);
    }

    private void DisableBoxComponent()
    {
        Destroy(transform.GetChild(0).gameObject);
        Destroy(transform.GetChild(1).gameObject);
        GetComponent<Collider>().enabled = false;
    }

    private void SortDrop()
    {
        BoxDrop sortedDrop = (BoxDrop)Random.Range(0, 5);

        if (sortedDrop == BoxDrop.ExtraTimeLife)
        {
            GameManager.Instance.ShowEventTextBlue("Box: +20s Lifetime");
            SfxManager.Instance.PlaySfxPowerUp();
            TimeManager.Instance.IncreaseTime(20);
        }
        else if (sortedDrop == BoxDrop.ShotPower)
        {
            GameManager.Instance.ShowEventTextBlue("Box: +1 Shot Power");
            SfxManager.Instance.PlaySfxPowerUp();
            PowerUpManager.Instance.AddPowerUp(PowerUp.Shot);
        }
        else if (sortedDrop == BoxDrop.DashPower)
        {
            GameManager.Instance.ShowEventTextBlue("Box: +1 Dash Power");
            SfxManager.Instance.PlaySfxPowerUp();
            PowerUpManager.Instance.AddPowerUp(PowerUp.Dash);
        }
        else if (sortedDrop == BoxDrop.Radiation)
        {
            GameManager.Instance.ShowEventTextYellow("Box: -70% Speed (3s)");
            SfxManager.Instance.PlaySfxLoss();
            _player.GetComponent<AtomControl>().ActiveSlowSpeed();
        }
        else if (sortedDrop == BoxDrop.Empty)
        {
            GameManager.Instance.ShowEventTextYellow("Box: Empty");
            SfxManager.Instance.PlaySfxLoss();
        }
    }

}

public enum BoxDrop
{
    ExtraTimeLife,
    ShotPower,
    DashPower,
    Radiation,
    Empty
}
