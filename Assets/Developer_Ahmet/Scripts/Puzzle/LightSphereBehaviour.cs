using UnityEngine;

public class LightSphereBehaviour : MonoBehaviour
{
    [SerializeField] LightType light = LightType.None;

    public LightType GetLightType() => light;

    
}
public enum LightType // LightSpheres - ...
{
    None,
    Red,
    Green,
    Blue,
}