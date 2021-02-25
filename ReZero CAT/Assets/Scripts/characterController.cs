using UnityEngine;
using UnityEngine.Events;

public class characterController : MonoBehaviour
{
	public float MovementSpeed = 1;
	private Rigidbody2D _rigid;
	public float JumpForce = 1;

	private void Start() {
		_rigid = GetComponent<Rigidbody2D>();
	}

	private void Update() {

		var movement = Input.GetAxis("Horizontal");
		transform.position+= new Vector3(movement,0,0)*Time.deltaTime* MovementSpeed;
		if (Input.GetButtonDown("Jump")&& Mathf.Abs(_rigid.velocity.y)<0.001)
		{
			_rigid.AddForce(new Vector2(0, JumpForce), ForceMode2D.Impulse);
		
		}
	}
}
