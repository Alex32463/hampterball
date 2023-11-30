using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderConnect : MonoBehaviour
{

    [SerializeField] private Collider collider;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        collider.transform.position = transform.position;
        collider.transform.rotation = transform.rotation;
    }
}
