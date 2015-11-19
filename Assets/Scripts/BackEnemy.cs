using UnityEngine;
using System.Collections;

public class BackEnemy : Token {

	static GameObject _prefab = null;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Move ();
	}
	void Move(){

		Vector2 Position = transform.position;

		bg_back o = GameObject.FindGameObjectWithTag("BG_Enemy").GetComponent<bg_back>();
		Debug.Log ("" + o.stage_p);
		Position.x-=o.stage_p;

		transform.position = Position;

	}
	public static BackEnemy Add(float x, float y)
	{
		// プレハブを取得
		_prefab = GetPrefab(_prefab, "BackEnemy");
		// プレハブからインスタンスを生成
		return CreateInstance2<BackEnemy>(_prefab, x, y);
	}
}