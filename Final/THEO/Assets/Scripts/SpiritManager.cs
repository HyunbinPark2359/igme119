using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiritManager : MonoBehaviour
{
    [SerializeField] private Transform spiritPoint;

    void Start()
    {
        transform.position = spiritPoint.position;
    }

    void Update()
    {
        transform.position = spiritPoint.position;

        float horizontalInput = Input.GetAxis("Horizontal");
        if (horizontalInput > 0.01f && transform.localScale.x < 0f)
        {
            Vector3 ITemp = transform.localScale;
            ITemp.x = Mathf.Abs(ITemp.x);
            transform.localScale = ITemp;
        }
        else if (horizontalInput < -0.01f && transform.localScale.x > 0f)
        {
            Vector3 ITemp = transform.localScale;
            ITemp.x *= -1;
            transform.localScale = ITemp;
        }
    }
}
