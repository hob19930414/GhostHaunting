using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

	public float speed;
	public float rotationSpeed;
	public Text helpText;

	GameObject host;
	bool possession = false;
	bool possessible = false;
	public bool scaring = false;
	float energy = 100;
	public float rate;
	public Text possessText;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
			possessText.text="";

			// This stops the dead NPC from flying away but might cause some problems later...
			host.rigidbody.velocity=new Vector3(0,0,0);
			host.rigidbody.angularVelocity=new Vector3(0,0,0);

		if (possession){
			possessText.text="Press \"Z\" to Exit";
			//GetComponent("Halo").GetType().GetProperty("enabled").SetValue("Halo",false,null);

			// Move NPC instead
			host.transform.Translate (Vector3.forward * Time.deltaTime * Input.GetAxis ("Vertical") * speed);
			host.transform.Rotate (new Vector3 (0, Input.GetAxis ("Horizontal"), 0) * rotationSpeed * Time.deltaTime);

			// Allow vertical movement if its not a human
			if(host.tag == "Object"){
				host.transform.Translate (Vector3.down * Time.deltaTime * Input.GetAxis ("AltVertical") * speed);
				transform.position = host.transform.position;
			}else{
			// Move yourself with the NPC
			transform.position = host.transform.position + Vector3.up*2;
			}
			transform.rotation = host.transform.rotation;

			energy -= Time.deltaTime * rate;
		
			// Exit body 
			if(Input.GetKeyDown(KeyCode.Z) || energy <= 0){
			possession = false;
			renderer.enabled=true;
			if (host.tag == "Human")
				transform.position += Vector3.up *-2 + Vector3.back ;
			transform.rotation = transform.rotation;
			}
		}else {
			//GetComponent("Halo").GetType().GetProperty("enabled").SetValue("Halo",true,null);

			// 3D movement
			transform.Translate(Vector3.forward * Time.deltaTime * Input.GetAxis("Vertical") * speed);
			transform.Rotate(new Vector3 (0,Input.GetAxis("Horizontal"),0) * rotationSpeed * Time.deltaTime);
			transform.Translate (Vector3.down * Time.deltaTime * Input.GetAxis ("AltVertical") * speed);

			// Recharge energy
			if (energy <= 100)
				energy += Time.deltaTime * rate;

			if (Input.GetKeyDown(KeyCode.X)){
				if (energy >= 10){
				energy -= 10;
				StartCoroutine(scare());
				}
			}

			// If the user is within distance from the NPC (This will have to be changed later when there are multiple NPC's)
			//if (Vector3.Distance (transform.position,NPC.transform.position) < 3) {
			//Debug.Log(possessible);
			if (possessible){
				if (energy >= 25){
						possessText.text="Press \"Z\" to Possess";
						if (Input.GetKeyDown(KeyCode.Z) && !possession){
							possession = true;
							renderer.enabled=false;
							transform.position = host.transform.position + Vector3.up*2;
							transform.rotation = host.transform.rotation;
						}
					}
			}
		}

	}

	public float getEnergy(){
		return energy;
	}

	public void setPossessible(GameObject host,bool value){
		if (!possessible){
			this.host = host;
			possessible = value;
		}

		if (this.host == host && possessible){
			possessible = value;
		}
	}

	private IEnumerator scare(){
		this.gameObject.renderer.material.color = Color.red;
		scaring = true;
		yield return new WaitForSeconds(2);
		scaring = false;
		this.gameObject.renderer.material.color = Color.white;

	}


}
