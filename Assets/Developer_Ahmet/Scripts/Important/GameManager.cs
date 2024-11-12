using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    protected override void Awake()
    {
        base.Awake();
        //...
    }
    public T GetBehaviourFromMeOrChildren<T>(Transform _transform) where T : MonoBehaviour
    {
        T parentScript = _transform.parent.GetComponent<T>();
        if (parentScript != null)
        {
            return parentScript;
        }

        T script = _transform.GetComponent<T>();
        if (script != null)
        {
            return script;
        }
        T childScript = _transform.GetComponentInChildren<T>();

        return childScript; 
    }

}
