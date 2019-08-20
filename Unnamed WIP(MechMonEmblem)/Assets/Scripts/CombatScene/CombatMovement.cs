using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatMovement : MonoBehaviour
{
    public int speed;
    public Vector2 inputVector;
    Rigidbody _rb;
    Vector2 skin;
    GroundConstraints _gc;
    // Start is called before the first frame update
    void Start()
    {
        MeshFilter mf = GetComponent<MeshFilter>();
        skin = new Vector2(mf.mesh.bounds.extents.x, mf.mesh.bounds.extents.z);
        _rb = GetComponent<Rigidbody>();

        _gc = FindObjectOfType<GroundConstraints>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 pos = transform.position + new Vector3(inputVector.x, 0, 0) * speed * Time.deltaTime;
        pos.x = Mathf.Clamp(pos.x, -_gc.constrainedArea.x / 2 + skin.x, _gc.constrainedArea.x / 2 - skin.y);
        pos.z = Mathf.Clamp(pos.z, -_gc.constrainedArea.y / 2 + skin.x, _gc.constrainedArea.y / 2 - skin.y);
        _rb.MovePosition(pos);
    }
}
