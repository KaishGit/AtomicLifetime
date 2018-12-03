using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TipManager : MonoBehaviour
{
    [SerializeField]
    private string _tipText;
    [SerializeField]
    private Text _tipTextUi;
    [SerializeField]
    private float _timeToVanish;

    private int _tipTextPosition;
    private bool _isVanishing;

    void Start()
    {
        _tipTextPosition = 0;
    }

    void Update()
    {
        if(_tipTextPosition < _tipText.Length)
        {
            _tipTextUi.text += _tipText[_tipTextPosition];
            _tipTextPosition++;
        }
        else
        {
            if (_isVanishing)
                return;

            StartCoroutine(WaitingForVanish(_timeToVanish));
            _isVanishing = true;
        }
    }

    private IEnumerator WaitingForVanish(float time)
    {
        yield return new WaitForSeconds(time);
        _tipTextUi.gameObject.SetActive(false);
        Destroy(gameObject);
    }
}
