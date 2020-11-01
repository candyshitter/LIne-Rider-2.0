using UnityEngine;

public class SpeedyEffector : MonoBehaviour
{
	[SerializeField] private float acceleration;

	private void OnCollisionStay2D(Collision2D other)
	{
		var rb = other.rigidbody;
		rb.AddForce(rb.velocity.normalized * Time.deltaTime * acceleration);
	}
}
