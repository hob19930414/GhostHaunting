using UnityEngine;
using System.Collections;

public class AliveNPC : MonoBehaviour {
	GameObject player;
	PlayerController script;

	void Start(){
		player = GameObject.FindGameObjectWithTag ("Player").gameObject;
		script = player.GetComponent<PlayerController> ();
	}
	
	void Update(){
		// Make NPC run in the opposite direction when "scared"
		// For now, it is by distance... This will be more challenging when we do it by "line of sight"
		// Also needs to be "run to another room or out window" or something...
		if (script.scaring){
			if (Vector3.Distance (transform.position,player.transform.position) < 10) {	
				this.transform.rotation = Quaternion.LookRotation(new Vector3(this.transform.position.x - player.transform.position.x,0,this.transform.position.z - player.transform.position.z));
				this.transform.Translate(Vector3.forward * Time.deltaTime);
		}
		}
		
	}
}
