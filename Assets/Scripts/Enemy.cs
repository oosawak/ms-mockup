using UnityEngine;
using System.Collections;

/// 敵
public class Enemy : Token {
	/// プレハブ
	static GameObject _prefab = null;

	// Use this for initialization
	void Start () {
		// ランダムな方向に移動する
		// 方向をランダムに決める
		float dir = Random.Range(0, 359);	// 指定した引数の範囲をランダムで返す関数
		// 速さは2
		float spd = 1;
		SetVelocity(dir, spd);
	}
	
	// Update is called once per frame
	void Update () {
		// カメラの左下座標を取得
		Vector2 min = GetWorldMin();
//		Debug.Log("minの値:" + min);

		// カメラの右上座標を取得する
		Vector2 max = GetWorldMax();
//		Debug.Log("maxの値:" + max);
		/*
		if (X < min.x || max.x < X)
		{
			// 画面外に出たので、X移動量を反転する
			VX *= -1;
			// 画面内に移動する
			ClampScreen();
		}
		if (Y < min.y || max.y < Y)
		{
			// 画面外に出たので、Y移動量を反転する
			VY *= -2;
			// 画面内に移動する
			ClampScreen();
		}
		*/

	}
	public static Enemy Add(float x, float y)
	{
		// プレハブを取得
		_prefab = GetPrefab(_prefab, "Enemy");
		// プレハブからインスタンスを生成
		return CreateInstance2<Enemy>(_prefab, x, y);
	}
	/// クリックされた
	public void OnMouseDown()
	{
		// パーティクルを生成
		for (int i = 0; i < 32; i++)
		{
			Particle.Add(X, Y);
		}
		Enemy.Add (Random.Range (100, 300), Random.Range (100, 300));
		// 破棄する
//		DestroyObj();
	}
}
