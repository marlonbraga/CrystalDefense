using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenTrapdoor : MonoBehaviour {

	private void OnTriggerStay(Collider other) {
		GetComponent<HingeJoint>().useMotor = true;
	}
	private void OnTriggerExit(Collider other) {
		GetComponent<HingeJoint>().useMotor = false;
	}
}

//Mass=100
//Collision Detection=Continous Dynamic
//  Hinge Joint
//Target Velocity = 10000
//Force = 25
//Use Limits = true
//Min = 0
//Max = 60
//

