#pragma strict

var text : GameObject;
var activateText : boolean = false;

function Start () {
	text.SetActive(false);
}

function Update () {
	if (activateText && Input.GetKeyDown (KeyCode.F)) 
	{
		text.SetActive(true);
	}
}

function OnTriggerExit ()
{
	text.SetActive(false);
}

function OnTriggerEnter () 
{
 	text.SetActive(true);

 	if(Input.GetKeyDown(KeyCode.F)) 
 	{
		activateText = true;
 	}
}