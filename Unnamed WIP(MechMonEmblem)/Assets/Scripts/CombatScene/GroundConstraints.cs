using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundConstraints : MonoBehaviour
{
    Bounds bounds;
    public Vector2 constrainedArea;
    // Start is called before the first frame update
    void Start()
    {
        bounds = GetComponent<MeshFilter>().mesh.bounds;
        constrainedArea = new Vector2(bounds.size.x, bounds.size.z);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
