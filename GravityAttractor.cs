using UnityEngine;
using System.Collections;

public class GravityAttractor : MonoBehaviour
{
	
	public float gravity = -9.8f;


	public void Attract(Rigidbody rb)
	{
		Vector3 gravityUp = (rb.position - transform.position).normalized;
		Vector3 rbup = rb.transform.up;

		// Apply downwards gravity to body
		rb.AddForce(gravityUp * gravity);
		// Allign bodies up axis with the centre of planet
		Quaternion targetRotation = Quaternion.FromToRotation(rbup, gravityUp) * rb.rotation;
		rb.rotation = Quaternion.Slerp(rb.rotation, targetRotation, 50 * Time.deltaTime);

	}
	
	/*public float gravity = -10f;

	public void Attract(GravityBody body)
	{
		Vector3 gravityUp = (body.transform.position - transform.position).normalized;
		Vector3 bodyUp = body.transform.up;

		body.rb.AddForce(gravityUp * gravity);

		Quaternion targetRotation = Quaternion.FromToRotation(bodyUp, gravityUp) * body.transform.rotation;
		body.transform.rotation = Quaternion.Slerp(body.transform.rotation, targetRotation, 50f * Time.deltaTime);
	}*/
}