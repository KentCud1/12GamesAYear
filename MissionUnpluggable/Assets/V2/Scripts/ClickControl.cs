using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickControl : MonoBehaviour
{

    public Transform clickTarget;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0)) {
            GetTransformOnClick();
        }
    }

    public static Vector2 ProcessClick() {
        Vector2 mousePos = Input.mousePosition;
        Vector2 worldPos = Camera.main.ScreenToWorldPoint((Vector3)mousePos);
        return worldPos;
    }

    public static Transform GetTransformOnClick() {
        Vector2 clickPos = ProcessClick();
        Collider2D hit = Physics2D.OverlapPoint(clickPos);
        Transform clickTarget = null;
        if(hit != null) {
            clickTarget = hit.transform;
        } else {
            Debug.Log("Click is empty.");
        }

        if(clickTarget != null) {
            return clickTarget;
        } else {
            Debug.Log("No target.");
            return null;
        }
        
    }

    public static Transform GetTransformOnClick(LayerMask lm) {
        Vector2 clickPos = ProcessClick();
        Collider2D hit = Physics2D.OverlapPoint(clickPos, lm);
        Transform clickTarget = null;
        if (hit != null) {
            clickTarget = hit.transform;
        }
        else {
            Debug.Log("Click is empty.");
        }

        if (clickTarget != null) {
            return clickTarget;
        }
        else {
            Debug.Log("No target.");
            return null;
        }

    }
}
