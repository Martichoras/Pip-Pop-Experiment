using UnityEngine;

public class Rotate : MonoBehaviour 
{
	public float speed;
	public bool reverse;
	void Update() 
	{
		// Rotate the object around its local X axis at 1 degree per second
		if(reverse){
			transform.Rotate(Vector3.forward * Time.deltaTime * speed);
		} else {
			transform.Rotate(-Vector3.forward * Time.deltaTime * speed);
		}


		// ...also rotate around the World's Y axis
		//transform.Rotate(Vector3.out * Time.deltaTime*10.0f, Space.World);
	}
}