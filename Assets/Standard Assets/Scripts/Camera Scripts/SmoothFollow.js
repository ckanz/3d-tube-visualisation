var target : Transform;
static var distance = 150.0;
var height = 1.0;
var heightDamping = 2.0;
var rotationDamping = 3.0;
@script AddComponentMenu("Camera-Control/Smooth Follow")


function LateUpdate () {
	
	if(distance>20 && distance<200)
	{
	if (Input.GetKey ("s")){
        distance++;
        }
        if (Input.GetKey ("w")){
        distance--;
    }
    if(distance>20 && distance<200)distance+=(Input.GetAxis("Mouse ScrollWheel")*10);
    }
    
	if (Input.GetKey (KeyCode.UpArrow)){
        transform.position.x++;
        }
        if (Input.GetKey (KeyCode.DownArrow)){
        transform.position.x--;
    }
    if (Input.GetKey (KeyCode.RightArrow)){
        transform.position.z--;
        }
        if (Input.GetKey (KeyCode.LeftArrow)){
        transform.position.z++;
    }
    if(distance<=20)distance++;
	if(distance>=200)distance--;	
    
    
	
		
	if(Input.GetMouseButton(1)==false && Input.GetKey(KeyCode.UpArrow)==false && Input.GetKey(KeyCode.DownArrow)==false && Input.GetKey(KeyCode.RightArrow)==false && Input.GetKey(KeyCode.LeftArrow)==false){
	
	if (!target)
		return;
		
	var currentHeight = transform.position.y;

    currentHeight = transform.position.y;

	var wantedposx = target.position.x + height;
	var currentposx = transform.position.x;

	currentposx = Mathf.Lerp (currentposx, wantedposx, 2.0 * Time.deltaTime);

	var wantedposz = target.position.z + height;
	var currentposz = transform.position.z;

	currentposz = Mathf.Lerp (currentposz, wantedposz, 2.0 * Time.deltaTime);

	transform.position.y = distance;
	transform.position.x = currentposx;
	transform.position.z = currentposz;
	
		
	
	    
}
}

function Update(){
	
	//transform.rotation = Quaternion.Euler (90, 90, 0);


}


