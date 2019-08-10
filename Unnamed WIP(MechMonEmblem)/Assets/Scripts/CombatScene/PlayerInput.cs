using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    Vector2 inputVect;
    CombatMovement _cMove;
    // Start is called before the first frame update
    void Start()
    {
        _cMove = GetComponent<CombatMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        inputVect = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        _cMove.inputVector = inputVect;

    }
}
