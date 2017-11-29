using UnityEngine;

public class Waypoints : MonoBehaviour {

    //Created points array to load waypoints into
	public static Transform[] points;  

    //Using Awake method to initialize points array before the game starts
	void Awake(){
        //Loading Waypoints children into points array
		points = new Transform[transform.childCount];
        //Iterating through each child of the Waypoints object and
        //pushing each child into the points array one by one
		for (int i = 0; i < points.Length; i++) 
        {
			points[i] = transform.GetChild (i);  
		}
	}
}
