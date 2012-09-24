var levelToLoad : String;
var soundhover : AudioClip;
var beep : AudioClip;
var QuitButton : boolean = false;


function OnMouseEnter(){
audio.PlayOneShot(soundhover);
renderer.material.color = Color.blue;
}

function OnMouseExit(){
renderer.material.color = Color.black;
}
function OnMouseUp(){
audio.PlayOneShot(beep);
yield new WaitForSeconds(0.20);
if(QuitButton){
Application.Quit();
}
else{
Application.LoadLevel(levelToLoad);
Debug.Log("Something");
}
}
@script RequireComponent(AudioSource)