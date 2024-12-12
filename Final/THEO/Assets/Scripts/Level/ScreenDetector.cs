using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenDetector : MonoBehaviour
{
    public float screenLeft;
    public float screenTop;
    public float screenRight;
    public float screenBottom;

    private void Awake()
    {
        Vector3 screenBottomLeft = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, Camera.main.nearClipPlane));
        Vector3 screenTopRight = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.nearClipPlane));

        screenLeft = screenBottomLeft.x;
        screenRight = screenTopRight.x;
        screenBottom = screenBottomLeft.y;
        screenTop = screenTopRight.y;
    }
}
