using UnityEngine;
using System.Collections;

public class PlayerControler : Token {
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
		/*
		if (Input.GetKey ("left")) {
			// 代入したPositionに対して加算減算を行う
			VY = VX = 0;
			Position.x -= SPEED.x;
			this.GetComponent<Animator> ().SetBool ("_left", true);
			transform.position = Position;
		} else if (Input.GetKey ("right")) { // 右キーを押し続けていたら
			// 代入したPositionに対して加算減算を行う
			VY = VX = 0;
			Position.x += SPEED.x;
			this.GetComponent<Animator> ().SetBool ("_right", true);
			transform.position = Position;
		} else if (Input.GetKey ("up")) { // 上キーを押し続けていたら
			// 代入したPositionに対して加算減算を行う
			VY = VX = 0;
			Position.y += SPEED.y;
			this.GetComponent<Animator> ().SetBool ("_up", true);
			transform.position = Position;
		} else if (Input.GetKey ("down")) { // 下キーを押し続けていたら
			// 代入したPositionに対して加算減算を行う
			VY = VX = 0;
			Position.y -= SPEED.y;
			this.GetComponent<Animator> ().SetBool ("_down", true);
			transform.position = Position;
		}
		*/
/*
			if(Input.GetMouseButton(0)){
				Vector3 tapPoint = new Vector3(0,0);
				float playerSpeed = 0.1f;
				if (Input.GetMouseButtonDown (0)) {
					//押下した位置を取得
					tapPoint = Input.mousePosition;
				}
				Vector3 currentTapPoint = Input.mousePosition;
				//指をずらしたときのベクトルを取得
				Vector3 mag = currentTapPoint - tapPoint;
				//指を動かしたときのみキャラを操作する
				if(tapPoint!=currentTapPoint){
					//動かした指の位置から角度を計算　　　　　　　　　
					float rad = Mathf.Atan2(currentTapPoint.y - tapPoint.y,currentTapPoint.x - tapPoint.x);
					float rot = (rad *180/Mathf.PI)+90;
					//キャラクターの向きを決定    
					this.transform.rotation = Quaternion.Euler(0f,rot*-1,0f);
					this.transform.Translate(0f,0f,playerSpeed);
					//一定以上画面をドラッグしたときは移動速度を上げる
					if(mag.magnitude < 120f){                 
						this.GetComponent<Animator> ().SetBool("p_walk",true);
						this.GetComponent<Animator> ().SetBool("p_run",false);
						playerSpeed = 0.02f;
					}else
					if(mag.magnitude >= 120f){
						this.GetComponent<Animator> ().SetBool("p_run",true);
						playerSpeed = 0.05f;
					}
				}
			}
			if (Input.GetMouseButtonUp(0)) {
				this.GetComponent<Animator> ().SetBool("p_walk",false);
				this.GetComponent<Animator> ().SetBool("p_run",false);
			}
*/
//	   else {

			// 現在の位置に加算減算を行ったPositionを代入する
			float x = Input.GetAxisRaw ("Horizontal");
		
			// 上・下
			float y = Input.GetAxisRaw ("Vertical");
		
			if (x < 0) {
				// 代入したPositionに対して加算減算を行う
				this.GetComponent<Animator> ().SetBool ("_left", true);
			} else if (x > 0) { // 右キーを押し続けていたら
				// 代入したPositionに対して加算減算を行う
				this.GetComponent<Animator> ().SetBool ("_right", true);
			} else if (y > 0) { // 上キーを押し続けていたら
				// 代入したPositionに対して加算減算を行う
				this.GetComponent<Animator> ().SetBool ("_up", true);
			} else if (y < 0) { // 下キーを押し続けていたら
				// 代入したPositionに対して加算減算を行う
				this.GetComponent<Animator> ().SetBool ("_down", true);
			}

			// 移動する向きを求める
			Position = new Vector2 (x, y).normalized;

//		}
	}

}