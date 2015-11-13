using UnityEngine;
using System.Collections;

public class bg_back : Token {
	public GameObject player ;
	bool isClicked = false;
	bool isDrag = false;

	Vector2 currentPoint;
	void Start () {
		int enemycnt = 0 ;
		int enemymax = 10 ;
		if(enemycnt < enemymax) {
			for (; enemycnt < enemymax; enemycnt++) {
				Enemy.Add (Random.Range (100, 300), Random.Range (100, 300));
			}
			enemycnt--;
		}

		//		player = GameObject.Find("Player");
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetMouseButtonDown(0)){
			OnMouseDown();
		}
		if(Input.GetMouseButton(0)){
			OnMouseDrag();
		}
		if(Input.GetMouseButtonUp(0)){
			OnMouseUp();
		}
	}
	void OnMouseDown(){
		float spd = 0;
		Token _toToken;
		_toToken = player.GetComponent<Token>();
		_toToken.SetVelocity(0, spd);

		Vector3 screenPoint = Camera.main.WorldToScreenPoint(player.transform.position);
		Vector3 newVector = Camera.main.ScreenToWorldPoint( new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
		
		Vector2 tapPoint = new Vector2(newVector.x, newVector.y);

//		Debug.Log("OnMouseDown:"+newVector.x+","+newVector.y);
		currentPoint = new Vector2(tapPoint.x, tapPoint.y);
		isClicked = true;

	}
	
	void OnMouseDrag(){
		if(!isClicked){
			return;
		}
		isDrag = true;
		Debug.Log("OnMouseDrag");

	}
	
	void OnMouseUp(){
		isClicked = false;

		isDrag = false;
		Vector3 screenPoint = Camera.main.WorldToScreenPoint(player.transform.position);
		Vector3 newVector = Camera.main.ScreenToWorldPoint( new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
		
		Vector2 tapPoint = new Vector2(newVector.x, newVector.y);

		if(Vector2.Distance(currentPoint, tapPoint)<0.1){
			VY= VX = 0 ;
			return;
		}
		float r = Mathf.Atan2(tapPoint.x-currentPoint.x, currentPoint.y-tapPoint.y);
		float dir = (r * 180 / Mathf.PI)+90;

//		Debug.Log("OnMouseUp:"+dir);

		// 速さは2		
		float spd = 1;
		Token _toToken;
		_toToken = player.GetComponent<Token>();
		_toToken.SetVelocity(dir, spd);

		currentPoint = tapPoint;
	}	
}
