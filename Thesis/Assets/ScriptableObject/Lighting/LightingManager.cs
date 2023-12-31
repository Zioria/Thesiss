using System;
using Unity.Mathematics;
using UnityEngine;


public class LightingManager : MonoBehaviour
{
    //Scene References
    [SerializeField] private Light DirectionalLight;
    [SerializeField] private LightPreSet Preset;
    //Variables
    [SerializeField, Range(0,5000)] private float TimeOfDay;
    [SerializeField] private float DayMin;
    [SerializeField] private float MintoTick;
    [SerializeField] private float CurrenTick;

    public SkyboxBlender skybox;
     bool isStopped;

   
     private void Start()
    {
        MintoTick = DayMin * 60f;
        //TimeOfDay += MintoTick / 4;
        //CurrenTick += MintoTick / 6;

    }

    private void Update()
    {
        
        //MintoTick = DayMin * 60f;
        
        
        
        if (Preset == null)
            return;

        if (Application.isPlaying)
        {
            //(Replace with a reference to the game time)
            
            TimeOfDay += Time.deltaTime;
            CurrenTick += Time.deltaTime;
            if (CurrenTick >= MintoTick/8 )
            {
                skybox.Blend(true);
                CurrenTick = 0f;
                
            }
            
            TimeOfDay %= MintoTick;
            
            UpdateLighting(TimeOfDay / MintoTick);
            
        }
        else
        {
            UpdateLighting(TimeOfDay / MintoTick);
        }
        
        
        
        
        
    }
    
    

    private void UpdateLighting(float timePercent)
    {
        //Set ambient and fog
        RenderSettings.ambientLight = Preset.AmbientColor.Evaluate(timePercent);
        RenderSettings.fogColor = Preset.FogColor.Evaluate(timePercent);
        
        //If the directional light is set then rotate and set it's color, I actually rarely use the rotation because it casts tall shadows unless you clamp the value
        if (DirectionalLight != null)
        {
            DirectionalLight.color = Preset.DirectionColor.Evaluate(timePercent);

            DirectionalLight.transform.localRotation = Quaternion.Euler(new Vector3((timePercent * 360f) - 0, 170f, 0));
        }

    }

    //Try to find a directional light to use if we haven't set one
    private void OnValidate()
    {
        if (DirectionalLight != null)
            return;

        //Search for lighting tab sun
        if (RenderSettings.sun != null)
        {
            DirectionalLight = RenderSettings.sun;
        }
        //Search scene for light that fits criteria (directional)
        else
        {
            Light[] lights = GameObject.FindObjectsOfType<Light>();
            foreach (Light light in lights)
            {
                if (light.type == LightType.Directional)
                {
                    DirectionalLight = light;
                    return;
                }
            }
        }
    }
}
