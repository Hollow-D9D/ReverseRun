using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RopeColorController : MonoBehaviour
{
    [SerializeField] private Material ropeMaterial;

    [SerializeField] private Color ropeStartColor;
    [SerializeField] private Color ropeTargetColor;

    public void ChangeColor(float value) {
        ropeMaterial.color=Color.Lerp(ropeStartColor,ropeTargetColor,value);
    }
}
