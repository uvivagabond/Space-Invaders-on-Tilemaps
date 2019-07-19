using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class ResizeCamera : MonoBehaviour
{
    public float targetWidth=100;
    public float pixelsToUnits = 100;

    private void Update()
    {
        Scale();
    }

    void Scale()
    {
        float height = Mathf.RoundToInt(targetWidth / (float) Screen.width * Screen.height);
        this.GetComponent<Camera>().orthographicSize = height / pixelsToUnits *0.5f;
    }
}