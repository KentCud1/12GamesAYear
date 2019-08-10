using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TileMap : MonoBehaviour {

    public Vector2 map;
    public GameObject tile;
    public string seed;
    public Sprite[] spriteMap;
    public float perlinFloat = 10f;
    public float perlinFreq = 2f;
    public Button uiSubmit;
    public bool checkForLand;
    public GameObject[] tiles;

    public float[] tileMap; 

    public int islandAmount;
    public List<Islands> isleList;


    float seededRand;
	// Use this for initialization
	void Start () {
        tileMap = new float[(int)(map.x * map.y)];
        tiles = new GameObject[(int)(map.x * map.y)];
        Random.InitState(seed.GetHashCode());
        seededRand = Random.Range(0f,1000f);
        ShowMap();
        islandAmount = isleList.Count;
        uiSubmit.onClick.AddListener(ShowMap);
    }

    public void ShowMap() {
        for (int i = 0; i < map.y; i++) {
            for(int j = 0; j < map.x; j++) {
                GameObject newTile = Instantiate(tile, new Vector2(j, i), Quaternion.identity, transform);
                newTile.name = newTile.name + "(" + j + "," + i + ")";
                if (spriteMap.Length > 0) {
                    float noise = 1f / spriteMap.Length;
                    float perlin = Mathf.Clamp01(Mathf.PerlinNoise((j/perlinFloat + seededRand) * perlinFreq, (i/perlinFloat + seededRand) * perlinFreq));
                    int noiseValue = (int)(perlin / noise);

                    Sprite temp = newTile.GetComponent<SpriteRenderer>().sprite = spriteMap[noiseValue];

                    tileMap[(int)(map.x * i + j)] = noiseValue;



                    float deltaX = temp.bounds.size.x * j + (temp.bounds.size.x / 2);
                    float deltaY = temp.bounds.size.y * i + (temp.bounds.size.y / 2);
                    newTile.transform.position = new Vector2(deltaX - (temp.bounds.size.x * map.x/2), deltaY - (temp.bounds.size.y * map.y/2));
                    tiles[(int)(map.x * i + j)] = newTile;
                }
            }
        }
        // Test:
        if (checkForLand) {
            isleList = Islands.FindIslands();
            for (int b = 0; b < isleList.Count; b++) {
                GameObject go = Instantiate(new GameObject(), transform);
                go.name = "Island " + b;
                go.AddComponent<BoxCollider2D>();
                for (int a = 0; a < isleList[b].islandPos.Length; a++) {
                    Vector2 temp = isleList[b].islandPos[a];
                    int index = (int)(map.x * temp.y + temp.x);
                    Color c = new Color(1, 1 - ((float)(b + 1f) / (float)(isleList.Count + 1f)), 1-((float)(b + 1f)/(float)(isleList.Count + 1f)));
                        tiles[index].GetComponent<SpriteRenderer>().color = c;
                    tiles[index].transform.parent = go.transform;
                }
            }
            //if (noiseValue > 2) {
            //    newTile.GetComponent<SpriteRenderer>().color = Color.red;
            //}
            //else {
            //    newTile.GetComponent<SpriteRenderer>().color = Color.green;
            //}
        }
    }
	
	// Update is called once per frame
	void Update () {
	}
}
