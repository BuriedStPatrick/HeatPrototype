using UnityEngine;
using System.Collections;

public class Pulsate : MonoBehaviour {

    public float PulseAmount = 10;
    public  float PulseFrequency = 10;

    private Light light;
    private float defaultSpotAngle;
    private float defaultRange;
    

	// Use this for initialization
	void Start () {
        light = GetComponent<Light>();
        defaultSpotAngle = light.spotAngle;
        defaultRange = light.range;
	}
	
	// Update is called once per frame
	void Update () {
        switch (light.type)
        {
            case LightType.Spot:
                if (light.spotAngle > (defaultSpotAngle + PulseAmount) || light.spotAngle < (defaultSpotAngle - PulseAmount))
                    PulseFrequency *= -1;
                light.spotAngle += PulseFrequency;
                break;
            case LightType.Point:
                if (light.range > (defaultRange + PulseAmount) || light.range < (defaultRange - PulseAmount))
                    PulseFrequency *= -1;
                light.range += PulseFrequency * Time.deltaTime;
                break;
            default:
                Debug.LogError("<font color=red>Pulse not supported for Light:</font> " + light.type);
                break;
        }
	}
}
