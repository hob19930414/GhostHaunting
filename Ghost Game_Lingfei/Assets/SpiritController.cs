using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SpiritController : MonoBehaviour {
	
	public Slider spiritBar;
	public GameObject player;
	float energy;

	void Update(){
		energy = player.GetComponent<PlayerController>().getEnergy();
		spiritBar.value = energy / 100;
	}
}
