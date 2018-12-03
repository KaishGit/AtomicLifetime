using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [SerializeField]
    private Text _eventUi;
    [SerializeField]
    private Animator _eventUiAnimator;
    [SerializeField]
    private GameObject _atomPlayer;
    [SerializeField]
    private string _celebrationText;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    void Start()
    {

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            SfxManager.Instance.PlaySfxSelect();
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        if (Input.GetKeyDown(KeyCode.M))
        {
            SfxManager.Instance.PlaySfxSelect();
            SceneManager.LoadScene(1);
        }
    }

    private void ShowEventText(string text)
    {
        _eventUi.text = text;

        _eventUiAnimator.SetBool("ShowEvent", false);
        StartCoroutine(WaitForChangeBool());
    }

    public void ShowEventTextRed(string text)
    {
        _eventUi.color = new Color32(252, 50, 50, 255);
        ShowEventText(text);
    }

    public void ShowEventTextBlue(string text)
    {
        _eventUi.color = new Color32(43, 143, 239, 255);
        ShowEventText(text);
    }

    public void ShowEventTextYellow(string text)
    {
        _eventUi.color = new Color32(255, 231, 77, 255);
        ShowEventText(text);
    }

    public void ShowEventTextPink(string text)
    {
        _eventUi.color = new Color32(255, 0, 146, 255);
        ShowEventText(text);
    }

    private IEnumerator WaitForChangeBool()
    {
        yield return new WaitForSeconds(0.1f);
        _eventUiAnimator.SetBool("ShowEvent", true);
    }

    public void LoseStage()
    {
        EffectManager.Instance.CreateExplosionEffect(_atomPlayer.transform.position);
        SfxManager.Instance.PlaySfxExplosion();
        Destroy(_atomPlayer);       
        TimeManager.Instance.StopDecreasingLifetime();
        ShowEventTextRed("It's over, press R to restart...");       
    }

    public void WinStage()
    {
        SfxManager.Instance.PlaySfxWin();
        _atomPlayer.GetComponent<NavMeshAgent>().isStopped = true;
        TimeManager.Instance.StopDecreasingLifetime();
        ShowEventTextPink(_celebrationText);
        StartCoroutine(WaitForGoToMenu());
    }

    private IEnumerator WaitForGoToMenu()
    {
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene(1);
    }
}
