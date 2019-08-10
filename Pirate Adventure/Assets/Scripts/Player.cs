using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    public Vector2 pos;
    TileMap tmp;
    public int posIndex;
    public bool isSelected;


    public int speedPerTurn;
	// Use this for initialization
	void Start () {
        tmp = FindObjectOfType<TileMap>();
        pos = SetPosition();
        transform.position = tmp.tiles[posIndex].transform.position;
        GetComponent<SpriteRenderer>().sortingOrder = 1;
	}
	
    public Vector2 SetPosition() {
        Random.State randState = Random.state;
        Random.InitState(System.DateTime.Now.Millisecond);
        pos = new Vector2((int)Random.Range(0, tmp.map.x - 2), (int)Random.Range(0, tmp.map.y - 2));
        Debug.Log(pos.ToString());
        posIndex = (int)(tmp.map.x * pos.y + pos.x);
        Random.state = randState;
        if (tmp.tileMap[posIndex] > 2) {
            Vector2 newPos = SetPosition();
            return newPos;
        }
            return pos;
    }

    public void CheckMove() {

        if(isSelected) {
            Debug.Log("Stop");
            if (Input.GetButtonDown("Jump")) {
                Debug.Log("Clear");
                isSelected = false;
            }
            return;
        }

        if(Input.GetMouseButtonDown(0)) {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D[] hits = Physics2D.BoxCastAll(mousePos, Vector2.one/2f, 0f,Vector2.zero);
            Debug.Log(hits.Length);
            foreach(RaycastHit2D hit in hits) {
                if(hit.transform == transform) {
                    isSelected = true;
                }
            }
        }
    }
	// Update is called once per frame
	void Update () {
        CheckMove();
	}
}
