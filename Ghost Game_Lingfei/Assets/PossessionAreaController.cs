using UnityEngine;
using System.Collections;

public class PossessionAreaController : MonoBehaviour {
	GameObject player;
	PlayerController script;

//	void OnTriggerEnter(Collider other){
//	 	Debug.Log ("???");
//		other.GetComponent<PlayerController> ().setPossessible (this.transform.parent.gameObject,true);
//	}
//
//	void OnTriggerExit(Collider other){
//		Debug.Log ("???");
//		other.GetComponent<PlayerController> ().setPossessible (this.transform.parent.gameObject,false);
//	}
	void Start(){
		player = GameObject.FindGameObjectWithTag ("Player").gameObject;
		script = player.GetComponent<PlayerController> ();
	}

	void Update(){

		script.setPossessible (this.gameObject,false);
		if (Vector3.Distance (transform.position,player.transform.position) < 3) {
			script.setPossessible (this.gameObject,true);

		}

	}
}
