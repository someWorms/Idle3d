using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
[CreateAssetMenu(fileName ="Worldsettings", menuName ="Scriptables/Worldsettings", order = 1)]
public class Worldsettings : ScriptableObject
{
    public Gradient AmbientColor;
    public Gradient FogColor;
    public Gradient DirColor;
}
