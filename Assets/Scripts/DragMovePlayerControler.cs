using UnityEngine;
using System.Collections;

public class DragMovePlayerControl : Token {
	// 速度
	Vector2 SPEED = new Vector2(0.08f, 0.08f);
	bool isClicked = false;
	Vector2 currentPoint;
	
	// Use this for initialization
	void Start () {
		SetVelocity(0, 0);
	}
	
	// Update is called once per frame
	void Update () {
		// 移動処理
		Move ();
		if (VX != 0||VY != 0) {
			float dir = Direction+180;
			
			Debug.Log("Player::update-dir="+dir);
			
			if (dir< (90 * 0 + 90 / 2) || dir > (90 * 4 - 90 / 2)) {
				this.GetComponent<Animator> ().SetBool ("_left", true);
			} else if (dir < (90 * 1 + 90 / 2) && dir > (90 * 1 - 90 / 2)) {
				this.GetComponent<Animator> ().SetBool ("_down", true);
			} else if (dir < (90 * 2 + 90 / 2) && dir > (90 * 2 - 90 / 2)) {
				this.GetComponent<Animator> ().SetBool ("_right", true);
			} else if (dir < (90 * 3 + 90 / 2) && dir > (90 * 3 - 90 / 2)) {
				this.GetComponent<Animator> ().SetBool ("_up", true);
			}
		}
		// カメラの左下座標を取得
		Vector2 min = GetWorldMin();
		//		Debug.Log("minの値:" + min);
		
		// カメラの右上座標を取得する
		Vector2 max = GetWorldMax();
		//		Debug.Log("maxの値:" + max);
		if (X < min.x || max.x < X)
		{
			// 画面外に出たので、X移動量を反転する
			VX *= -1;
			// 画面内に移動する
			ClampScreen();
		}
		if (Y < min.y || max.y < Y) {
			// 画面外に出たので、Y移動量を反転する
			VY *= -1;
			// 画面内に移動する
			ClampScreen ();
		}
	}
	
	// 移動関数
	void Move(){
		// 現在位置をPositionに代入
		Vector2 Position = transform.position;
		this.GetComponent<Animator>().SetBool("_left",false);
		this.GetComponent<Animator>().SetBool("_right",false);
		this.GetComponent<Animator>().SetBool("_up",false);
		this.GetComponent<Animator>().SetBool("_down",false);
		
		// Keybord
		// 左キーを押し続けていたら
		if (Input.GetKey ("left")) {
			// 代入したPositionに対して加算減算を行う
			VY= VX = 0 ;
			Position.x -= SPEED.x;
			this.GetComponent<Animator> ().SetBool ("_left", true);
			transform.position = Position;
		} else if (Input.GetKey ("right")) { // 右キーを押し続けていたら
			// 代入したPositionに対して加算減算を行う
			VY= VX = 0 ;
			Position.x += SPEED.x;
			this.GetComponent<Animator> ().SetBool ("_right", true);
			transform.position = Position;
		} else if (Input.GetKey ("up")) { // 上キーを押し続けていたら
			// 代入したPositionに対して加算減算を行う
			VY= VX = 0 ;
			Position.y += SPEED.y;
			this.GetComponent<Animator> ().SetBool ("_up", true);
			transform.position = Position;
		} else if (Input.GetKey ("down")) { // 下キーを押し続けていたら
			// 代入したPositionに対して加算減算を行う
			VY= VX = 0 ;
			Position.y -= SPEED.y;
			this.GetComponent<Animator> ().SetBool ("_down", true);
			transform.position = Position;
		}
	}
	
}