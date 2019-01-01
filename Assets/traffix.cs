using UnityEngine;
using System.Collections;

public class traffix : MonoBehaviour
{

	private int resolution = 2000;
	private ParticleSystem.Particle[] points;
	GameObject[] positions;
	string[,] content;
	public bool on = false;
	public Vector3 up = new Vector3 (0, 2000, 0);
	
	void Start ()
	{
		
		points = new ParticleSystem.Particle[resolution];
		content = CSVReader.grid;
		positions = CSVReader.Stations;
		for (int i=1; i<resolution; i++) {
			points [i].position = positions [i].transform.position;
			
			points [i].color = new Color (1.0F, 1.0f, 1.0f);
			points [i].size = float.Parse (content [8, i]) / 2000;
		}
		
	}
	
	void Update ()
	{
		if (CSVReader.trafficToggle == false && on == false) {
			showpoints ();
			particleSystem.SetParticles (points, points.Length); 
			on = true;
		}
		
		if (CSVReader.trafficToggle == true && on == true) {
			hidepoints (); 
			particleSystem.SetParticles (points, points.Length); 
			on = false;			
		}
	}
	
	void showpoints ()
	{
		content = CSVReader.grid;
		for (int i=5; i<resolution; i++) {
			points [i].position = points [i].position - up;
		}	
	}
	
	void hidepoints ()
	{
		for (int i=1; i<resolution; i++) {
			points [i].position = points [i].position + up;
		}
	}
}
