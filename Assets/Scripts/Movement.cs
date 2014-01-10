using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {
	public Vector3 inputDir = Vector3.zero;
	public float speed;
	public float accel;
	public float drag;
	public float movementMax = 20f;
	void Start () {
	
	}

	void Update () {
		inputDir.x = Input.GetAxis ("Horizontal"); 
		inputDir.y = Input.GetAxis ("Vertical");
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
