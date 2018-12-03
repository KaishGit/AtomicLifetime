using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerUpManager : MonoBehaviour
{
    public static PowerUpManager Instance;

    [SerializeField]
    private Text 
        _moveUiNumber, 
        _DashUiNumber, 
        _ShotUiNumber,
        _ShieldUiNumber;

    private int
        MoveNumber,
        DashPowerNumber,
        ShotPowerNumber,
        ShieldPowerNumber;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    public void AddPowerUp(PowerUp powerUpType)
    {
        ChangePowerUpValue(powerUpType, +1);
    }

    public void SubPowerUp(PowerUp powerUpType)
    {
        ChangePowerUpValue(powerUpType, -1);
    }

    private void ChangePowerUpValue(PowerUp powerUpType, int value)
    {
        if (powerUpType == PowerUp.Move)
        {
            MoveNumber += value;
            _moveUiNumber.text = MoveNumber.ToString();
        }
        else if (powerUpType == PowerUp.Dash)
        {
            DashPowerNumber += value;
            _DashUiNumber.text = DashPowerNumber.ToString();
        }
        else if (powerUpType == PowerUp.Shot)
        {
            ShotPowerNumber += value;
            _ShotUiNumber.text = ShotPowerNumber.ToString();
        }
        else if (powerUpType == PowerUp.Shield)
        {
            ShieldPowerNumber += value;
            _ShieldUiNumber.text = ShieldPowerNumber.ToString();
        }
    }

    public bool HasPowerUp(PowerUp powerUpType)
    {

        if (powerUpType == PowerUp.Dash && DashPowerNumber > 0)
        {
            return true;
        }
        else if (powerUpType == PowerUp.Shot && ShotPowerNumber > 0)
        {
            return true;
        }
        else if (powerUpType == PowerUp.Shield && ShieldPowerNumber > 0)
        {
            return true;
        }

        return false;
    }

}

public enum PowerUp
{
    Move,
    Dash,
    Shot,
    Shield
}