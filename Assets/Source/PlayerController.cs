using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public GameObject shot;
	public Transform firePosition;

	// 1. 이동 구현하기 
	float speed = 5;

	// 2. 이동시 기울이기 
	float tilt = 5;


	// Use this for initialization
	void Start () {
	
	}

	// 단순하게 key를 감지할 때 사용
	void Update () {

		if (Input.GetButtonDown("Fire1") == true) {

			Instantiate(shot, firePosition.position, firePosition.rotation);
		}


	}

	// FixedUpdate is used for phisical movement control using rigidbody.
	void FixedUpdate () {

		float dirX = Input.GetAxis ("Horizontal");
		float dirY = Input.GetAxis ("Vertical");

		Vector3 movement = new Vector3 (dirX, 0, dirY);

		// velocity : 속도
		GetComponent<Rigidbody> ().velocity = movement * speed;
		// 여기까지는 정말 많이 쓰는 코드이다.

		// rotation : 회전
		// 기울이기 : quaternion & Euler(오일러) 
		GetComponent<Rigidbody> ().rotation = Quaternion.Euler (0, 0, GetComponent<Rigidbody> ().velocity.x * -tilt);

		// 3. 충돌박스 만들기.
		// Rigibody - Constraints - Freeze Position & Freeze Rotation => 사용하지 않는 축은 막아버린다.
		// Position에서 Y축은 사용하지 않으므로 막는다. 
		// Rotation에서 X, Y축은 회전하지 않으므로 막는다. (사전에 미리 차단해 놓는다.)



	}
}
