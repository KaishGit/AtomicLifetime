using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AtomControl : MonoBehaviour
{
    [SerializeField]
    private GameObject _shotPrefab;
    [SerializeField]
    private Transform _targetNewPosition;
    [SerializeField]
    private GameObject _dashParticle, _radioactiveParticle;
    [SerializeField]
    private GameObject _eyes;
    [SerializeField]
    private Material _redColor, _purpleColor;

    private NavMeshAgent _navMeshAgent;
    private float _normalSpeed;
    private float _fastSpeed;
    private float _slowSpeed;
    private bool _canMove;
    private Renderer _targetMaterial;

    void Start()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();

        _normalSpeed = _navMeshAgent.speed;
        _fastSpeed = _normalSpeed * 6;
        _slowSpeed = _normalSpeed / 3;

        _canMove = true;
        PowerUpManager.Instance.AddPowerUp(PowerUp.Move);

        _targetMaterial = _targetNewPosition.GetComponent<Renderer>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (_canMove)
            {
                RaycastHit hit;

                if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 100))
                {
                    _navMeshAgent.destination = hit.point;
                    _targetNewPosition.position = new Vector3(hit.point.x, 0, hit.point.z);

                    //--
                    StartCoroutine(RestaureMovement(2));
                    PowerUpManager.Instance.SubPowerUp(PowerUp.Move);
                    _canMove = false;

                    SfxManager.Instance.PlaySfxPoint();
                    _targetMaterial.material = _redColor;
                }
            }

        }

        if (Input.GetKeyDown(KeyCode.Z))
        {
            if (PowerUpManager.Instance.HasPowerUp(PowerUp.Dash))
            {
                _navMeshAgent.speed = _fastSpeed;
                StartCoroutine(RestaureNormalSpeed(0.5f));

                PowerUpManager.Instance.SubPowerUp(PowerUp.Dash);
                SfxManager.Instance.PlaySfxDash();
                _dashParticle.SetActive(true);
                StartCoroutine(DisableGameObject(1, _dashParticle));
            }

        }

        if (Input.GetMouseButtonDown(1))
        {
            if (PowerUpManager.Instance.HasPowerUp(PowerUp.Shot))
            {
                RaycastHit hit;

                if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 100))
                {
                    GameObject newShot = Instantiate(_shotPrefab, transform.position, Quaternion.identity);
                    newShot.transform.LookAt(new Vector3(hit.point.x, 0.5f, hit.point.z));
                    Quaternion newShotRotation = newShot.transform.rotation;
                    newShot.transform.rotation = new Quaternion(0, newShotRotation.y, 0, newShotRotation.w);

                    PowerUpManager.Instance.SubPowerUp(PowerUp.Shot);
                    SfxManager.Instance.PlaySfxShot();
                }

            }

        }
    }

    private IEnumerator RestaureNormalSpeed(float time)
    {
        yield return new WaitForSeconds(time);
        _navMeshAgent.speed = _normalSpeed;
    }

    private IEnumerator RestaureMovement(float time)
    {
        yield return new WaitForSeconds(time);
        _canMove = true;
        PowerUpManager.Instance.AddPowerUp(PowerUp.Move);
        _targetMaterial.material = _purpleColor;
    }

    private IEnumerator DisableGameObject(float time, GameObject component)
    {
        yield return new WaitForSeconds(time);
        component.SetActive(false);
    }

    public void ActiveSlowSpeed()
    {
        _navMeshAgent.speed = _slowSpeed;
        SfxManager.Instance.PlaySfxLoss();
        _radioactiveParticle.SetActive(true);
        StartCoroutine(DisableGameObject(3, _radioactiveParticle));
        StartCoroutine(RestaureNormalSpeed(3));
    }

    public void CloseEyes()
    {
        _eyes.SetActive(false);
        StartCoroutine(WaitForOpenEyes());
    }

    private IEnumerator WaitForOpenEyes()
    {
        yield return new WaitForSeconds(0.5f);
        _eyes.SetActive(true);
    }
}
