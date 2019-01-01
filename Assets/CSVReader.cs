/*
	CSVReader by Dock. (24/8/11)
	http://starfruitgames.com
 
	usage: 
	CSVReader.SplitCsvGrid(textString)
 
	returns a 2D string array. 
 
	Drag onto a gameobject for a demo of CSV parsing.
*/
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System;
 
public class Station
{
	
	public Station (IEnumerable<string> row)
	{
		
		// cast ienumerable to array - just in case performance, you know...
		var rowArr = row as string[] ?? row.ToArray ();
		
		// basic properties
		Name = rowArr [0];
		
		// lat and long
		double.TryParse (rowArr [3], out Lat);
		double.TryParse (rowArr [4], out Long);
		int.TryParse (rowArr [5], out Zone);
	}
	
	public string Name;
	public double Lat;
	public double Long;
	public int Zone;
	
}

public class CSVReader : MonoBehaviour
{
	public TextAsset csvFile;
	public static GameObject[] Stations;
	public GameObject[] Dstations;
	public static GameObject[] Traffic;
	public static string[,] grid;
	public GUIStyle largeText = new GUIStyle ();
	public GUIStyle smallTextRed = new GUIStyle ();
	public GUIStyle smallTextBlue = new GUIStyle ();
	public GUIStyle redBlock = new GUIStyle ();
	public GUIStyle blueBlock = new GUIStyle ();
	public Texture mytexture;
	int scale = 400;
	public int s = 1;
	public static bool trafficToggle = false;
	public static bool lineToggle = false;
	
	void Start ()
	{
		
		grid = SplitCsvGrid (csvFile.text);
		Stations = new GameObject[grid.Length];
		Dstations = new GameObject[grid.Length];
		Traffic = new GameObject[grid.Length];
		
		// jh
		
		var colIndexes = Enumerable.Range (0, grid.GetLength (0) - 1).ToArray ();
		var rowIndexes = Enumerable.Range (1, grid.GetLength (1) - 1).ToArray ();
		var stations = rowIndexes
			.Select (y => colIndexes.Select (x => grid [x, y]))
			.Select (r => new Station (r))
			.Where (r => r.Name != null)
			.ToDictionary (r => r.Name, r => r);
		
		// now we can find stations by name!
		Debug.Log (stations ["Waterloo"].Zone);
		
		// jh
				
		for (int i = 1, c = grid.GetLength(1); i < c; i++) {
			var StationMaterial = new Material (Shader.Find ("Bumped Specular"));
			Stations [i] = GameObject.CreatePrimitive (PrimitiveType.Capsule);
			renderer.material = StationMaterial;
			Stations [i].renderer.material = StationMaterial;
			Stations [i].renderer.material.mainTexture = mytexture;
			
			if (grid [4, i] != "" && grid [4, i] != null && grid [6, i] != null && grid [6, i] != "" && grid [6, i] != "#DIV/0!") {	
				Stations [i].transform.position = new Vector3 (float.Parse (grid [3, i]) * scale, ((float.Parse (grid [6, i])) / 5.0F) + 1, -float.Parse (grid [4, i]) * scale);
	
				//color by Zone		
				if (grid [5, i] == "1")
					Stations [i].renderer.material.color = new Color (1.0F, 0.9F, 0.9F, 0.5F);
				if (grid [5, i] == "2")
					Stations [i].renderer.material.color = new Color (1.0F, 0.8F, 0.8F, 0.5F);
				if (grid [5, i] == "3")
					Stations [i].renderer.material.color = new Color (1.0F, 0.7F, 0.7F, 0.5F);
				if (grid [5, i] == "4")
					Stations [i].renderer.material.color = new Color (1.0F, 0.6F, 0.6F, 0.5F);
				if (grid [5, i] == "5")
					Stations [i].renderer.material.color = new Color (1.0F, 0.5F, 0.5F, 0.5F);
				if (grid [5, i] == "6")
					Stations [i].renderer.material.color = new Color (1.0F, 0.2F, 0.2F, 0.5F);
				if (grid [5, i] == "7")
					Stations [i].renderer.material.color = new Color (1.0F, 0.1F, 0.1F, 0.5F);
				if (grid [5, i] == "8")
					Stations [i].renderer.material.color = new Color (1.0F, 0.0F, 0.0F, 0.5F);
				if (grid [5, i] == "9")
					Stations [i].renderer.material.color = new Color (1.0F, 0.0F, 0.0F, 0.5F);			
		
								
				if (grid [7, i] != "" && grid [7, i] != null && float.Parse (grid [7, i]) > 7F && grid [7, i] != "#DIV/0!") {
					Dstations [i] = GameObject.CreatePrimitive (PrimitiveType.Capsule);
					Dstations [i].transform.position = new Vector3 (
						float.Parse (grid [3, i]) * scale,
						Math.Min (0.0F, 0.5F * (float.Parse (grid [7, i]) - 100 - float.Parse (grid [6, i]))), 
						-float.Parse (grid [4, i]) * scale);
					Dstations [i].renderer.material.mainTexture = mytexture;
					Dstations [i].renderer.material = StationMaterial;
					Dstations [i].renderer.material.color = new Color (0.0F, 0.0F, 0.8F);
				}
			}
		}
		
		transform.position = new Vector3 (float.Parse (grid [3, 10]) * scale, float.Parse (grid [6, s - 1]) / 5 + 1, -float.Parse (grid [4, 10]) * scale);
	}
	
	void Update ()
	{
	}
	
	void OnGUI ()
	{	
		if (grid [7, s - 1] != "0" && grid [7, s - 1] != "Mean") {
			GUI.Label (new Rect (10, Screen.height - 60, 300, 25), + Math.Round (-Math.Min (0.0F, 0.5F * (float.Parse (grid [7, s - 1]) - 100 - float.Parse (grid [6, s - 1])))) + " meters below station entrance", smallTextBlue);
			GUI.Label (new Rect (320, Screen.height - 30 - float.Parse (grid [6, s - 1]) * 1, 25, -Math.Min (0.0F, 0.5F * (float.Parse (grid [7, s - 1]) - 100 - float.Parse (grid [6, s - 1]))) * 1), "", blueBlock);
		}
		if (grid [7, s - 1] == "0")
			GUI.Label (new Rect (10, Screen.height - 60, 300, 25), "No data available", smallTextBlue);

		
		if (grid [6, s - 1] != "0" && grid [6, s - 1] != "Ground Level outside Station") {
			GUI.Label (new Rect (10, Screen.height - 40, 300, 25), float.Parse (grid [6, s - 1]) + " Meters above sea level", smallTextRed);
			GUI.Label (new Rect (345, Screen.height - 30, 25, -float.Parse (grid [6, s - 1]) * 1), "", redBlock);
		}
		if (grid [6, s - 1] == "0" || grid [6, s - 1] == "")
			GUI.Label (new Rect (10, Screen.height - 40, 300, 25), "No data available", smallTextRed);
		
		GUI.Label (new Rect (10, Screen.height - 110, 300, 25), grid [0, s - 1], largeText);	
		
		
		
		if (GUI.Button (new Rect (Screen.width - 160, Screen.height - 30, 150, 20), ">")) {
			//print(grid[0,s]);
			//Vector3 Start = new Vector3(float.Parse(grid[3,s-1])*scale, 0, float.Parse(grid[4,s-1])*scale);
			s++;
			transform.position = new Vector3 (float.Parse (grid [3, s - 1]) * scale, float.Parse (grid [6, s - 1]) / 5 + 1, -float.Parse (grid [4, s - 1]) * scale);
			
		}
		if (GUI.Button (new Rect (Screen.width - 320, Screen.height - 30, 150, 20), "<")) {
			//print(grid[0,s]);
			if (s != 1)
				s--;
			transform.position = new Vector3 (float.Parse (grid [3, s - 1]) * scale, float.Parse (grid [6, s - 1]) / 5 + 1, -float.Parse (grid [4, s - 1]) * scale);
			
		}
		
		//left buttons
		if (GUI.Button (new Rect (10, 20, 150, 25), "Bank")) {
			
			s = 22;
			transform.position = new Vector3 (float.Parse (grid [3, s - 1]) * scale, float.Parse (grid [6, s - 1]) / 5 + 1, -float.Parse (grid [4, s - 1]) * scale);
		}
		if (GUI.Button (new Rect (10, 50, 150, 25), "Charing Cross")) {
			
			s = 97;
			transform.position = new Vector3 (float.Parse (grid [3, s - 1]) * scale, float.Parse (grid [6, s - 1]) / 5 + 1, -float.Parse (grid [4, s - 1]) * scale);
		}
		if (GUI.Button (new Rect (10, 80, 150, 25), "Green Park")) {
			
			s = 211;
			transform.position = new Vector3 (float.Parse (grid [3, s - 1]) * scale, float.Parse (grid [6, s - 1]) / 5 + 1, -float.Parse (grid [4, s - 1]) * scale);
		}
		if (GUI.Button (new Rect (10, 110, 150, 25), "Liverpool Street")) {
			
			s = 311;
			transform.position = new Vector3 (float.Parse (grid [3, s - 1]) * scale, float.Parse (grid [6, s - 1]) / 5 + 1, -float.Parse (grid [4, s - 1]) * scale);
		}

		if (GUI.Button (new Rect (10, 140, 150, 25), "Russel Square")) {
			
			s = 427;
			transform.position = new Vector3 (float.Parse (grid [3, s - 1]) * scale, float.Parse (grid [6, s - 1]) / 5 + 1, -float.Parse (grid [4, s - 1]) * scale);
		}
		if (GUI.Button (new Rect (10, 170, 150, 25), "St. Pauls")) {
			
			s = 470;
			transform.position = new Vector3 (float.Parse (grid [3, s - 1]) * scale, float.Parse (grid [6, s - 1]) / 5 + 1, -float.Parse (grid [4, s - 1]) * scale);
		}
		if (GUI.Button (new Rect (10, 200, 150, 25), "Tower Hill")) {
			
			s = 513;
			transform.position = new Vector3 (float.Parse (grid [3, s - 1]) * scale, float.Parse (grid [6, s - 1]) / 5 + 1, -float.Parse (grid [4, s - 1]) * scale);
		}
		if (GUI.Button (new Rect (10, 230, 150, 25), "Waterloo")) {
			
			s = 541;
			transform.position = new Vector3 (float.Parse (grid [3, s - 1]) * scale, float.Parse (grid [6, s - 1]) / 5 + 1, -float.Parse (grid [4, s - 1]) * scale);
		}
		if (GUI.Button (new Rect (10, 260, 150, 25), "Random Station")) {
			s = UnityEngine.Random.Range (1, 593);
			transform.position = new Vector3 (float.Parse (grid [3, s - 1]) * scale, float.Parse (grid [6, s - 1]) / 5 + 1, -float.Parse (grid [4, s - 1]) * scale);
		}
		
		
		trafficToggle = GUI.Toggle (new Rect (Screen.width - 160, Screen.height - 80, 160, 30), trafficToggle, "Show Busyness");
		lineToggle = GUI.Toggle (new Rect (Screen.width - 160, Screen.height - 60, 160, 30), lineToggle, "Show Lines");
	}
	

	
	// outputs the content of a 2D array, useful for checking the importer
	static public void DebugOutputGrid (string[,] grid)
	{
		string textOutput = ""; 
		for (int y = 0; y < grid.GetUpperBound(1); y++) {	
			for (int x = 0; x < grid.GetUpperBound(0); x++) {
 
				textOutput += grid [x, y]; 
				textOutput += "|"; 
			}
			textOutput += "\n"; 
		}
		Debug.Log (textOutput);
	}
 
	// splits a CSV file into a 2D string array
	static public string[,] SplitCsvGrid (string csvText)
	{
		string[] lines = csvText.Split ("\n" [0]); 
 
		// finds the max width of row
		int width = 0; 
		for (int i = 0; i < lines.Length; i++) {
			string[] row = SplitTsvLine (lines [i]); 
			width = Mathf.Max (width, row.Length); 
		}
 
		// creates new 2D string grid to output to
		string[,] outputGrid = new string[width + 1, lines.Length + 1]; 
		for (int y = 0; y < lines.Length; y++) {
			string[] row = SplitCsvLine (lines [y]); 
			for (int x = 0; x < row.Length; x++) {
				outputGrid [x, y] = row [x]; 
 
				// This line was to replace "" with " in my output. 
				// Include or edit it as you wish.
				//outputGrid[x,y] = outputGrid[x,y].Replace("\"\"", "\"");
			}
		}
 
		return outputGrid; 
	}
 
	// splits a TSV row 
	static public string[] SplitTsvLine (string line)
	{
		return (from System.Text.RegularExpressions.Match m in System.Text.RegularExpressions.Regex.Matches (line,
		@"(((?<x>(?=[`t\r\n]+))|""(?<x>([^""]|"""")+)""|(?<x>[^`t\r\n]+)),?)", 
		System.Text.RegularExpressions.RegexOptions.ExplicitCapture)
		select m.Groups [1].Value).ToArray ();
	}
	
	// splits a CSV row 
	static public string[] SplitCsvLine (string line)
	{
		return (from System.Text.RegularExpressions.Match m in System.Text.RegularExpressions.Regex.Matches (line,
		@"(((?<x>(?=[,\r\n]+))|""(?<x>([^""]|"""")+)""|(?<x>[^,\r\n]+)),?)", 
		System.Text.RegularExpressions.RegexOptions.ExplicitCapture)
		select m.Groups [1].Value).ToArray ();
	}
}