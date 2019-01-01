var target : Transform;
var damping = 6.0;
var smooth = true;

@script AddComponentMenu("Camera-Control/Smooth Look At")

var starti;

function LateUpdate () {
	
	
	if(starti<360)
	{
		//transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler (0, starti, starti/4), Time.deltaTime * damping);
		transform.position.y = starti/2-50;
		starti+=2;
		transform.LookAt(target);
	}
	
	
	
	if(Input.GetMouseButton(1)==false && starti==360){
	
	
	if (target) {

		if (smooth)
		{
			// Look at and dampen the rotation
			var rotation = Quaternion.LookRotation(target.position - transform.position);
			//transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * damping);
			transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler (90, 90, 0), Time.deltaTime * damping);
		}
		else
		{
			// Just lookat
		    transform.LookAt(target);
		}
		
		//transform.LookAt(target);
	}
}

}

function Start () {
	// Make the rigid body not change rotation
   	if (rigidbody)rigidbody.freezeRotation = true;
   	starti=0;
}