using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserCoords : MonoBehaviour
{
    LineRenderer _lr;

    public Vector3 start;
    public Vector3 end;
    public Transform endAnchor;
    // Start is called before the first frame update
    void Start()
    {
        _lr = GetComponent<LineRenderer>();
        start = _lr.GetPosition(0);
        end = _lr.GetPosition(1);
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.activeSelf) {
            end = endAnchor.localPosition;
            if (_lr.GetPosition(1) != end) {
                _lr.SetPosition(1, end);
            }
        }
    }

}
