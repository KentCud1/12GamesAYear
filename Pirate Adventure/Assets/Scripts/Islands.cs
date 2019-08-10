using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Islands {

    public Vector2[] islandPos;

    public static List<Islands> islandList;

	// Use this for initialization
	void Start () { 
        FindIslands();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void CheckForIslands(Vector2 pos) {
        TileMap tmp = GameObject.FindObjectOfType<TileMap>();
        if(tmp.tileMap[(int)(tmp.map.x * pos.y + pos.x)] > 2) {

        }

    }

    public static List<Islands> FindIslands() {
        TileMap tmp = GameObject.FindObjectOfType<TileMap>();
        List<Islands> currentIslands = new List<Islands>();
        List<Vector3> openList = new List<Vector3>();
        List<Vector3> usedCoords = new List<Vector3>();
        List<Vector3> currentIslandCoords = new List<Vector3>();

        bool islandFound = false;
        int currentIndex = 0;
        for(int i = 0; i < tmp.map.y; i++) {
            for(int j = 0; j < tmp.map.x; j++) {
                Vector2 currentPos = new Vector2(j, i);

                if(usedCoords.Contains(currentPos)) {
                    continue;
                }

                if(tmp.tileMap[currentIndex] > 2) {
                    Islands currIsle = new Islands();
                    islandFound = true;
                    Vector2 islandPos = currentPos;
                    openList.Add(islandPos);
                    List<Vector3> deleteInts = new List<Vector3>();
                    int count = 0;
                    while(islandFound == true) {
                        if (count > 100) {
                            Debug.Log("Count break");
                            islandFound = false;
                            break;
                        }

                        count++;

                        for (int x = 0; x < openList.Count; x++) {



                            if(usedCoords.Contains(openList[x])) {
                                deleteInts.Add(openList[x]);
                                continue;
                            }
                            if(openList[x].x < 0 || openList[x].y < 0 || openList[x].x >= tmp.map.x || openList[x].y >= tmp.map.y) {
                                deleteInts.Add(openList[x]);
                                usedCoords.Add(openList[x]);
                                continue;
                            }
                            usedCoords.Add(openList[x]);

                            if (tmp.tileMap[(int)(tmp.map.x * openList[x].y + openList[x].x)] > 2) {
                                openList.Add(new Vector2(openList[x].x - 1, openList[x].y));
                                openList.Add(new Vector2(openList[x].x + 1, openList[x].y));
                                openList.Add(new Vector2(openList[x].x, openList[x].y + 1));
                                openList.Add(new Vector2(openList[x].x, openList[x].y - 1));
                                currentIslandCoords.Add(openList[x]);
                                deleteInts.Add(openList[x]);
                            } else {
                                deleteInts.Add(openList[x]);
                            }

                        }
                        for(int y = 0; y < deleteInts.Count; y++) {
                            openList.Remove(deleteInts[y]);
                        }

                        if(openList.Count <1) {
                            currIsle.islandPos = new Vector2[currentIslandCoords.Count];
                            for(int z = 0; z < currentIslandCoords.Count;z++) {
                                currIsle.islandPos[z] = currentIslandCoords[z];
                            }
                            if (currIsle.islandPos.Length > 0) {
                                currentIslands.Add(currIsle);
                        }
                        currentIslandCoords.Clear();
                            islandFound = false;
                            break;
                        }
                    }
                }
                currentIndex++;
            }
        }

        return currentIslands;
        
    }
}
