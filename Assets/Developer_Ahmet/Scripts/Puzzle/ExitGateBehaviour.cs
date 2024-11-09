using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class ExitGateBehaviour : MonoBehaviour
{
    public Animator Animator { get; set; }
    private void Awake()
    {
        Animator = GetComponent<Animator>();
    }
    public void ExitGateOpened() => StartCoroutine(IEExitGateOpened(0.5f));
    public void ExitGateClosed()
    {
        
    }
    IEnumerator IEExitGateOpened(float _duration)
    {
        yield return new WaitForSeconds(_duration);
        TransitionCamManager.instance.TransCamToPlayer();
    }
}
