using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {
	public Vector3 inputDir = Vector3.zero;
	public float triggers;
	public float speed;
	public float accel;
	public float drag;
	public float movementMax = 20f;
	private bool rotated = false;
	public float mTime;
	public float mTime2;
	public Vector3 rot;
	public bool rotatingBack;
	public float rotZ;
	private float curVel;
	void Start () {
	
	}

	void Update () {
		triggers = Input.GetAxis ("Triggers");
		inputDir.x = Input.GetAxis ("Horizontal"); 
		inputDir.y = Input.GetAxis ("Vertical");
		if (triggers == -1 && !rotated)
		{
			Rotate (this.transform.rotation.z, 90);
			//rotter til 90 i z
		}
		if (triggers == 1 && !rotated)
		{
			Rotate (this.transform.rotation.z, -90);
			//rotter til 90 i z
		}

//		else if (triggers == 1)
//		{
//			Rotate (this.transform.rotation.z, -90);
//		}

	}

	void FixedUpdate()
	{
//		Debug.Log (inputDir.magnitude);
//			speed = speed + accel * inputDir.magnitude * Time.deltaTime;
//			speed = Mathf.Clamp(speed, 0f, movementMax);
//			speed = speed - speed * Mathf.Clamp01(drag * Time.deltaTime);

//		transform.position += Time.deltaTime * inputDir * speed;
		rigidbody.velocity = inputDir.normalized * speed;
	}

	void Rotate(float from, float to)
	{
		if (mTime < 1)
		{
			mTime += Time.deltaTime;
			rot.z = Mathf.SmoothStep(from,to,mTime);
			this.transform.eulerAngles = rot;
//			
		}
		else
		{
			mTime = 0;
			rotated = true;
		}
	}

}

//speed = speed + accel * inputDir.magnitude * Time.deltaTime;
//speed = Mathf.Clamp(speed, 0f, movementMax);
//speed = speed - speed * Mathf.Clamp01(drag * Time.deltaTime);
////		}
////		else
////		{
////			speed = 0f;	
////		}
////		transform.position = transform.position + (transform.forward * speed) * Time.deltaTime;		
////		rigidbody.AddForce(transform.forward * speed);	
//if(!standStill)
//{
//	rigidbody.velocity = new Vector3(transform.forward.x * speed, gravity, transform.forward.z * speed);
//}
//
//if(inputDir.magnitude > 0f)
//{
//	float newTargetAngle = Mathf.Atan2(inputDir.x, inputDir.y) * Mathf.Rad2Deg;		
//	targetAngle = newTargetAngle;
//}					
//
//angle = Mathf.SmoothDampAngle(angle, targetAngle, ref angularVelocity, angleSmoothDuration, angleMaxSpeed);
////		angle = targetAngle;
////	
//trans
