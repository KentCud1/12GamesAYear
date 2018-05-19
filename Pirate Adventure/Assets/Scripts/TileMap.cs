using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileMap : MonoBehaviour {

    public Vector2 map;
    public GameObject tile;
    public string seed;
    public Sprite[] spriteMap;
    public float perlinFloat = 10f;
    public float perlinFreq = 2f;

    float seededRand;
	// Use this for initialization
	void Start () {
        Random.InitState(seed.GetHashCode());
        seededRand = Random.Range(0f,1000f);
        ShowMap();

	}

    public void ShowMap() {
        for (int i = 0; i < map.y; i++) {
            for(int j = 0; j < map.x; j++) {
                GameObject newTile = Instantiate(tile, new Vector2(j, i), Quaternion.identity, transform);
                newTile.name = newTile.name + "(" + j + "," + i + ")";
                if (spriteMap.Length > 0) {
                    float noise = 1f / spriteMap.Length;
                    float perlin = Mathf.PerlinNoise((j/perlinFloat + seededRand) * perlinFreq, (i/perlinFloat + seededRand) * perlinFreq);
                    int noiseValue = (int)(perlin / noise);
                    Debug.Log(perlin);

                    Sprite temp = newTile.GetComponent<SpriteRenderer>().sprite = spriteMap[noiseValue];

                    float deltaX = temp.bounds.size.x * j + (temp.bounds.size.x / 2);
                    float deltaY = temp.bounds.size.y * i + (temp.bounds.size.y / 2);
                    newTile.transform.position = new Vector2(deltaX - (temp.bounds.size.x * map.x/2), deltaY - (temp.bounds.size.y * map.y/2));
                }
            }
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
