using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteAlways]
public class WorldsettingsController : MonoBehaviour
{

    [SerializeField] private Light DirLight;
    [SerializeField] private Worldsettings Ws;
    [SerializeField, Range(0, 24)] private float TimeOfDay;

    private void Update()
    {
        if(Ws== null) return; 

        if (Application.isPlaying)
        {
            TimeOfDay += Time.deltaTime;
            TimeOfDay %= 24;
            UpdateLighting(TimeOfDay / 24f);
        }
        else 
        {
            UpdateLighting(TimeOfDay / 24f);
        }
    }

    private void UpdateLighting(float timePercent)
    {
        RenderSettings.ambientLight = Ws.AmbientColor.Evaluate(timePercent);
        RenderSettings.fogColor = Ws.FogColor.Evaluate(timePercent);

        if(DirLight!= null)
        {
            DirLight.color = Ws.DirColor.Evaluate(timePercent);
            DirLight.transform.localRotation = Quaternion.Euler(new Vector3((timePercent * 360f) - 90f, 170f, 0));
        }
    }

    private void OnValidate()
    {
        if(DirLight != null) { return; }
        if(RenderSettings.sun != null) { DirLight= RenderSettings.sun; }
        else
        {
            Light[] lights = GameObject.FindObjectsOfType<Light>();
            foreach(Light light in lights)
            {
                if(light.type == LightType.Directional)
                {
                    DirLight = light;
                    return;
                }
            }
        }
    }
}
