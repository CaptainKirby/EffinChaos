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
	public Vector3 rot;
	public bool pressedTrigger;
	public float rotTo;
	public float rotationDur = 7f;
	public bool isRunning;
	public Quaternion startRot;
	public bool sloppyBool;
	private bool pressedDown;
	private bool pressedUp;
	void Start () {
	
	}

	void Update () {
		triggers = Input.GetAxis ("Triggers");
		inputDir.x = Input.GetAxis ("Horizontal"); 
		inputDir.y = Input.GetAxis ("Vertical");

		if (!isRunning) 
		{
			startRot = this.transform.rotation;
//			mTime = 0;
			if(!pressedTrigger)
			{
				sloppyBool = true;
			}
		}
		if (pressedTrigger) 
		{
			if(!pressedDown)
			{
				pressedDown = true;
			}
			if(sloppyBool)
			{
				mTime = 0;
				sloppyBool = false;
			}
//			StartCoroutine("Rotate", rotTo);
			Quaternion rot;
			Quaternion newRot = Quaternion.Euler (this.transform.rotation.x, this.transform.rotation.y, rotTo);
//			startRot = this.transform.rotation;
			//		while (true)
			//		{
			if(mTime < 1)
			{
				isRunning = true;
				mTime += Time.deltaTime / rotationDur;
				rot = Quaternion.Lerp(startRot,newRot, mTime);
				this.transform.rotation = rot;
				//				mTime += Time.deltaTime;
				//				float curRotZ = transform.rotation
				//				rot.z = Mathf.SmoothDamp(this.transform.rotation,to, ref curVel,1);
				//				this.transform.eulerAngles = rot;
			}
			else{ isRunning = false;}
		}


//		else StartCoroutine("Rotate", rotTo);

		if (triggers == -1)
		{
			pressedTrigger = true;
			rotTo = -90;
//			StartCoroutine("Rotate", 90);
			//rotter til 90 i z
		}
		if (triggers == 1) 
		{
			pressedTrigger = true;
			rotTo = 90;
		}
		if ((int)triggers == 0) 
		{
			pressedTrigger = false;
			rotTo = 0;
//			mTime = 0;

		}
//		if (triggers == 1 && !rotated)
//		{
//			Rotate (this.transform.rotation.z, -90);
//			//rotter til 90 i z
//		}

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

//	IEnumerator Rotate(float to)
//	{
//		float newRot = Mathf.SmoothDamp (transform.rotation.z, to, ref curVel, 1);
//		test = Mathf.DeltaAngle(,to);
//		rot.z = newRot;
//		yield return null;
//		mTime = 0;
//		float prevZ = this.transform.rotation.z;

//		Quaternion rot;
//		Quaternion newRot = Quaternion.Euler (this.transform.rotation.x, this.transform.rotation.y, to);
//		Quaternion startRot = this.transform.rotation;
////		while (true)
////		{
//			if(mTime < 1)
//			{
//				mTime += Time.deltaTime / rotationDur;
//				rot = Quaternion.Lerp(startRot,newRot, mTime);
//				this.transform.rotation = rot;
////				mTime += Time.deltaTime;
////				float curRotZ = transform.rotation
////				rot.z = Mathf.SmoothDamp(this.transform.rotation,to, ref curVel,1);
////				this.transform.eulerAngles = rot;
//			}
//		else mTime = 0;
//
//			yield return null;
//		}
//		if (mTime < 1)
//		{
//			mTime += Time.deltaTime;
//			rot.z = Mathf.SmoothStep(from,to,mTime);
//			this.transform.eulerAngles = rot;
////			
//		}
//		else
//		{
//			mTime = 0;
//			rotated = true;
//		}
//	}

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
