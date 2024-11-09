using System.Collections.Generic;
using UnityEngine;

public class TargetPointManager : MonoBehaviour
{
    List<TargetPointBehaviour> pointBehaviours = new List<TargetPointBehaviour>();
    public bool AllTargetPointsActivated;
    private void Start()
    {
        AllTargetPointsActivated = false;
        pointBehaviours.Clear();
        int length = transform.childCount;
        for (int i = 0; i < length; i++)
        {
            if (transform.GetChild(i).TryGetComponent(out TargetPointBehaviour pointBehaviour))
            {
                pointBehaviours.Add(pointBehaviour);
            }
        }
    }
    public void TargetPointControl()
    {
        if (pointBehaviours.Count > 0)
        {
            string info = "";
            bool allActivated = true;
            foreach (TargetPointBehaviour pointBehaviour in pointBehaviours)
            {
                if (!pointBehaviour.IsTargetInPoint)
                {
                    allActivated = false;
                    info += $"{pointBehaviour.gameObject.name},";
                    //Debug.Log($"{pointBehaviour.gameObject.name} adli point noktasi aktif degil.");
                }
            }
            if (allActivated)
            {
                AllTargetPointsActivated = true;
                TransitionCamManager.instance.OpenExitGate();
                Debug.Log("Tum hedef noktalari aktiflestirilmis");
            }
            else
            {
                AllTargetPointsActivated = false;
                Debug.Log($"Aktiflestirilmemis hedef noktalari mevcut ({info})");
            }
        }
    }
}