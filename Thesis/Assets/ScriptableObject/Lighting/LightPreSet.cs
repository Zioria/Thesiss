
using UnityEngine;

[System.Serializable]
[CreateAssetMenu(fileName = "LightPreset", menuName = "Scriptables/LightPreset",order = 1)]
public class LightPreSet : ScriptableObject
{
   public Gradient AmbientColor;
   public Gradient DirectionColor;
   public Gradient FogColor;
}
