using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateSprite : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        //rotates the object this script is attached to on the Z-axis
        transform.Rotate(new Vector3(0, 0, 45) * Time.deltaTime);
    }
}
