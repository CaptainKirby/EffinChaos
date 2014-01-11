using UnityEngine;
using System.Collections;

public class CurveWorld : MonoBehaviour {
	public static CurveWorld instance;
	public Material[] curveMaterials;
	public Vector4 values;
	public Vector4 target;
	public Vector4 actual;
	Vector2 xLimits = new Vector2(-80, 80);
	Vector2 yLimits = new Vector2(-50, 50);
	float aquireNextTargetTime;
	float aquireNextTargetDuration;
	Vector2 aquireNextTargetDelay = new Vector2(3, 10);

	// Use this for initialization
	void Awake () {
		instance = this;
	}
	
	// Update is called once per frame
	void Update () {
		if (Time.time > aquireNextTargetTime) {
			values = target;
			aquireNextTargetDuration = Random.Range(aquireNextTargetDelay.x, aquireNextTargetDelay.y);
			aquireNextTargetTime += aquireNextTargetDuration;
			target = new Vector4(Random.Range(xLimits.x, xLimits.y), Random.Range(yLimits.x, yLimits.y), 0, 0);
		}
		float t = (aquireNextTargetTime - Time.time) / aquireNextTargetDuration;
		Vector4 p = Vector4.Lerp (values, target, 1-t);
		foreach (Material m in curveMaterials) {
			m.SetVector("_QOffset", p);		
		}

	}
}
