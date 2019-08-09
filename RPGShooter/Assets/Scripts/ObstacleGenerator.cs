using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleGenerator : MonoBehaviour
{
    public Vector2 obstacleMaxRect;
    public Bounds obstacleArea;
    public float gapLength;
    public int maxObstacles;
    public int currentObstacles;
    public GameObject obstaclePrefab;

    public LayerMask laymask;
    // Use this for initialization
    void Start() {
        obstacleArea.extents = Camera.main.ScreenToWorldPoint(new Vector3(Camera.main.scaledPixelWidth, Camera.main.scaledPixelHeight, 10));
    }

    // Update is called once per frame
    void Update() {
        currentObstacles = FindObjectsOfType<ObstacleMovement>().Length;
        if (currentObstacles < maxObstacles)
        {
            GameObject go = Instantiate(obstaclePrefab, new Vector3(
                Random.Range(-obstacleArea.extents.x, obstacleArea.extents.x), obstacleArea.extents.y, 0),
                Quaternion.identity, transform);
            go.transform.localScale = new Vector2(Random.Range(1, obstacleMaxRect.x), Random.Range(1, obstacleMaxRect.y));

            Bounds bound = go.GetComponent<BoxCollider2D>().bounds;

             float cornerLen = Mathf.Sqrt(bound.size.x * bound.size.x +
                bound.size.y * bound.size.y);
            Debug.Log(cornerLen + "\n" + bound.size);

            RaycastHit2D hit = Physics2D.CircleCast(go.transform.position, cornerLen + gapLength, Vector2.zero, 5f, laymask);
            if(hit.transform != null && hit.transform != go.transform)
            {
                Debug.Log("Overlap");
                Destroy(go);
            }
        }

    }

}

