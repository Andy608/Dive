using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementScript : MonoBehaviour
{
	public Vector3 acceleration;
	public Vector3 velocity;
	private Vector3 position;

	private const float DAMPING = 0.999f;
	public float dragForce = 1.0f;

	void Start()
	{
		position = this.transform.position;
	}

	void LateUpdate()
	{
		velocity += acceleration * Time.deltaTime;
		velocity *= dragForce;//Mathf.Pow(dragForce, deltaTime);
		velocity *= DAMPING;
		position += velocity * Time.deltaTime;
		//this.transform.position = position;

		acceleration.x = 0;
		acceleration.y = 0;

		velocity.x = 0;
		velocity.y = 0;
	}

	public void setDrag(float drag)
	{
		dragForce = drag;
	}

	public void setAcceleration(float x, float y)
	{
		acceleration.x = x;
		acceleration.y = y;
		//Debug.Log("SET ACCELERATION " + acceleration);
	}

	public void setAcceleration(Vector2 vec)
	{
		setAcceleration(vec.x, vec.y);
		//Debug.Log("SET ACCELERATION " + acceleration);
	}

	public void addAcceleration(float x, float y)
	{
		acceleration.x += x;
		acceleration.y += y;
	}

	public void addAcceleration(Vector2 vec)
	{
		addAcceleration(vec.x, vec.y);
	}

	public void setVelocity(float x, float y)
	{
		velocity.x = x;
		velocity.y = y;
	}

	public void setVelocity(Vector2 vec)
	{
		setVelocity(vec.x, vec.y);
	}

	public void setPosition(Vector3 vec)
	{
		setPosition(vec.x, vec.y, vec.z);
	}

	public void setPosition(float x, float y)
	{
		setPosition(x, y, this.transform.position.z);
	}

	public void setPosition(float x, float y, float z)
	{
		position.x = x;
		position.y = y;
		position.z = z;
	}

	public void resetToZero()
	{
		//reset = true;
		setPosition(0, 0);
		setVelocity(0, 0);
		setAcceleration(0, 0);
	}

	public Vector3 getPosition()
	{
		return position;
	}

	public Vector3 getVelocity()
	{
		return velocity;
	}

	public Vector3 getAcceleration()
	{
		return acceleration;
	}
}
