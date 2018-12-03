using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonLoadScene : MonoBehaviour
{
    [SerializeField]
    private string _sceneName;
    [SerializeField]
    private int _buildIndex;

    public void LoadScene()
    {
        SfxManager.Instance.PlaySfxSelect();
        //SceneManager.LoadScene(_sceneName); //Bug
        SceneManager.LoadScene(_buildIndex);
    }
}
