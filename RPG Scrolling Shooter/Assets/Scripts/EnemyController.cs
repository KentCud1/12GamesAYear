using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {

    public Bounds bounds;
    public float screenSideSkin;
    public int stepsPerRow;

    public float stepLength;
    public float beginningStepTime;

    public int childrenCount;

    float stepTime;
    bool isSteppingLeft = false;
    Vector2 startPos;
    int currChildren, activeChilds;
    bool forwardStep = false;

    // Use this for initialization
    void Start() {
        stepTime = beginningStepTime;
        CheckBounds();

        SetupSteps();

        Vector2 camMinPos = Camera.main.ScreenToWorldPoint(new Vector2(0, Camera.main.pixelHeight - 1));
        camMinPos += new Vector2((screenSideSkin) + bounds.extents.x, -screenSideSkin - bounds.extents.y);
        startPos = camMinPos;
        transform.position = startPos;
    }

    void CheckBounds() {
        bounds.center = transform.position;
        currChildren = 0;
        for (int i = 0; i < transform.childCount; i++) {
            Transform child = transform.GetChild(i);
            if (child.gameObject.activeInHierarchy) {
                SpriteRenderer sr = child.GetComponent<SpriteRenderer>();
                if (sr != null) {
                    bounds.Encapsulate(sr.bounds);
                }
                currChildren++;
            }
        }
    }

    // Update is called once per frame
    void Update() {
        childrenCount = currChildren;
        Step();
        bounds.center = transform.position;
        Debug.DrawLine(new Vector2(bounds.min.x, bounds.min.y), new Vector2(bounds.min.x, bounds.max.y));
        Debug.DrawLine(new Vector2(bounds.min.x, bounds.min.y), new Vector2(bounds.max.x, bounds.min.y));
        Debug.DrawLine(new Vector2(bounds.max.x, bounds.min.y), new Vector2(bounds.max.x, bounds.max.y));
        Debug.DrawLine(new Vector2(bounds.min.x, bounds.max.y), new Vector2(bounds.max.x, bounds.max.y));

        activeChilds = 0;
        for(int i = 0; i < transform.childCount;i++) {
            if(transform.GetChild(i).gameObject.activeInHierarchy) {
                activeChilds++;
            }
        }
        
        if(currChildren != activeChilds) {
            Debug.Log("Change step");
            CheckBounds();
            SetupSteps();
        }

    }

    public void SetupSteps() {
        Vector2 camMinPos = Camera.main.ScreenToWorldPoint(new Vector2(0, 0));
        camMinPos += new Vector2(screenSideSkin + bounds.extents.x,0);
        float skinnedMin = camMinPos
           .x;
        Vector2 camMaxPos = Camera.main.ScreenToWorldPoint(new Vector2(Camera.main.pixelWidth-1, 0));
        camMaxPos -= new Vector2(screenSideSkin + bounds.extents.x,0);
        float skinnedMax = camMaxPos.x;
        float skinRange = skinnedMax - skinnedMin;

        Debug.Log(skinRange);

        stepLength = skinRange / stepsPerRow ;

    } 


    public void Step() {
        if (stepTime <= 0f) {
            Vector2 stepPosition = transform.position;

                if (isSteppingLeft == false) {
                    stepPosition += new Vector2(stepLength, 0);
                }
                else {
                    stepPosition -= new Vector2(stepLength, 0);
                }

                Vector2 skinSideVector = new Vector2(screenSideSkin, 0);

                float camXPosMin = Camera.main.WorldToScreenPoint(stepPosition - (Vector2)bounds.extents).x;
                float camXPosMax = Camera.main.WorldToScreenPoint(stepPosition + (Vector2)bounds.extents).x;
                if ((isSteppingLeft == false && camXPosMax > Camera.main.pixelWidth) || (isSteppingLeft == true && camXPosMin < 0)) {
                   
                    forwardStep = true;

                }

                if (forwardStep == true) {
                    stepPosition = transform.position;
                    stepPosition += new Vector2(0, -stepLength);
                    isSteppingLeft = !isSteppingLeft;
                    forwardStep = false;
                }

                Debug.Log("Step");

                transform.position = stepPosition;
                stepTime = beginningStepTime - stepTime;
            }


        stepTime -= Time.deltaTime;

    }

    public void SetStepTime() {

    }

    public void SetStepLength() {
       
    }
}
