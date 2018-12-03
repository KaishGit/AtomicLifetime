using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeManager : MonoBehaviour
{
    public static TimeManager Instance;

    [SerializeField]
    private int _startTimeLife;
    [SerializeField]
    private Text _currentTimeLifeText;

    private int _currentTimeLife;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    void Start()
    {
        _currentTimeLife = _startTimeLife;
        _currentTimeLifeText.text = _currentTimeLife.ToString();

        InvokeRepeating("DecreaseTime", 1f, 1f);
    }

    void Update()
    {

    }

    private void DecreaseTime()
    {
        DecreaseTime(1);
    }

    public void DecreaseTime(int timeToDescrease)
    {
        _currentTimeLife -= timeToDescrease;

        if (_currentTimeLife < 0)
        {
            _currentTimeLife = 0;
        }

        _currentTimeLifeText.text = _currentTimeLife.ToString();

        if (_currentTimeLife == 0)
        {
            GameManager.Instance.LoseStage();
        }
    }

    public void IncreaseTime(int timeToIncrease)
    {
        print(_currentTimeLife);
        _currentTimeLife += timeToIncrease;
        print(_currentTimeLife);

        _currentTimeLifeText.text = _currentTimeLife.ToString();
    }

    public void StopDecreasingLifetime()
    {
        CancelInvoke("DecreaseTime");
    }
}