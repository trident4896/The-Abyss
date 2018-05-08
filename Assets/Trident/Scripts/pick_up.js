var onhand : Transform;

function Update () {

}

function Start () {

GetComponent.<Rigidbody> ().constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezePositionY;

}

function OnMouseDown () {
	GetComponent.<Rigidbody> ().useGravity = false;
	this.transform.position = onhand.position;
	this.transform.parent = GameObject.Find("FPSController").transform;
	this.transform.parent = GameObject.Find("FirstPersonCharacter").transform;
	GetComponent.<Rigidbody> ().constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezePositionY;
} 

function OnMouseUp () {
	this.transform.parent = null;
	GetComponent.<Rigidbody> ().useGravity = true;
	GetComponent.<Rigidbody> ().constraints = RigidbodyConstraints.None;
}