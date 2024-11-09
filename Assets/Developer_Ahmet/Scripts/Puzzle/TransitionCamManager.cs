using System.Collections;
using UnityEngine;

public class TransitionCamManager : MonoBehaviour
{
    [SerializeField] ExitGateBehaviour exitGate;
    [SerializeField] Camera levelEndCam;
    public static TransitionCamManager instance { get; private set; }
    private void Awake()
    {
        if (instance)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
    }
    private void Start()
    {
        levelEndCam.gameObject.SetActive(false);
        exitGate.Animator.enabled = false;
    }
    public void OpenExitGate() => StartCoroutine(IEOpenExitGate(0.5f));
    IEnumerator IEOpenExitGate(float _duration)
    {
        levelEndCam.gameObject.SetActive(true);
        yield return new WaitForSeconds(_duration);
        exitGate.Animator.enabled = true;
    }
    public void TransCamToPlayer()
    {
        levelEndCam.gameObject.SetActive(false);
    }
}
