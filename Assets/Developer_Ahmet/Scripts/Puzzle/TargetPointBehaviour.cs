using UnityEngine;

public class TargetPointBehaviour : MonoBehaviour
{
    [SerializeField] LightType targetLight = LightType.None;
    [SerializeField] LayerMask targetLayer;
    [SerializeField] bool isTargetInPoint;
    TargetPointManager pointManager;
    public bool IsTargetInPoint { 
        get{
            return isTargetInPoint;
        } 
        set{
            isTargetInPoint = value;
            pointManager.TargetPointControl();
        } 
    }
    private void Awake()
    {
        pointManager = GetComponentInParent<TargetPointManager>();
    }
    private void Start()
    {
        IsTargetInPoint = false;
    }
    private void OnTriggerEnter(Collider other)
    {
        if ((targetLayer.value & (1 << other.gameObject.layer)) > 0)
        {//obje hedeflenen layerda.
            if(other.TryGetComponent(out LightSphereBehaviour lightSphere))
            {
                if(lightSphere.GetLightType() == targetLight)
                {
                    Debug.Log($"{lightSphere.GetLightType()} tipinde ki isik kuresi hedeflenen noktaya girdi.");
                    IsTargetInPoint = true;                    
                }
                else
                    Debug.Log($"{lightSphere.GetLightType()} tipinde ki isik kuresi yanlis hedef noktasinda. (Hedeflenen isik tipi [{targetLight}])");
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if ((targetLayer.value & (1 << other.gameObject.layer)) > 0)
        {//obje hedeflenen layerda.
            if (other.TryGetComponent(out LightSphereBehaviour lightSphere))
            {
                if (lightSphere.GetLightType() == targetLight)
                {
                    Debug.Log($"{lightSphere.GetLightType()} tipinde ki isik kuresi hedeflenen noktadan cikti.");
                    IsTargetInPoint = false;
                }
            }
        }
    }
}
