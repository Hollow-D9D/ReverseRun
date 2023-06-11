using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (fileName = "ProgressData", menuName = "Data/ProgressData")]
public class ProgressData : ScriptableObject
{
    public float[] endPos = { -240, -260, -280, -300, -320 };
    public float[] energyGain = { 10, 12, 14, 16, 18, 20 };
    public float[] energyLose = { -10, -9, -8, -7, -6, -5, -4};
    public float[] launchSpeed = { 10000, 11000, 12000, 13000, 14000};
    public int[] endPosCost = { 2000, 4000, 8000, 16000, 32000 };
    public int[] energyGainCost = { 2000, 4000, 8000, 16000, 32000 };
    public int[] energyLoseCost = { 1000, 2000, 4000, 8000, 16000 };
    public int[] launchSpeedCost = { 4000, 8000, 16000, 32000, 64000 };
    
    public int money = 0;
}
