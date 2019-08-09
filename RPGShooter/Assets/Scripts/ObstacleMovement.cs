using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMovement : MonoBehaviour {
    public Vector2 direction;
    public float speed;

    float lowerEdge;
    float upperSpriteEdge;


	// Use this for initialization
	void Start () {
        lowerEdge = -Camera.main.ScreenToWorldPoint(new Vector3(0, Camera.main.scaledPixelHeight, 0)).y;
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(direction.normalized * speed * Time.deltaTime);

        upperSpriteEdge = transform.position.y + GetComponent<SpriteRenderer>().bounds.extents.y;
        if (upperSpriteEdge < lowerEdge)
        {
            Destroy(gameObject);
        }
	}
}
