using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour {

   
    public Image progressIcon;
    private float barProgress;
    public GameObject startPoint;
    public GameObject endPoint;
    public Transform playerPosition;
    private float totalDistance;
    private float playerDistance;
    private float playerProgress;


	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {

        totalDistance = endPoint.transform.position.x - startPoint.transform.position.x;
       // Debug.Log(totalDistance);
        playerDistance = playerPosition.transform.position.x - startPoint.transform.position.x;
       // Debug.Log(playerDistance);
        playerProgress = playerDistance / totalDistance * 100;
        //Debug.Log(playerProgress);
        barProgress = playerProgress / 100 * 732.1f;
        //progressIcon.transform.position = new Vector3( barProgress, progressIcon.transform.position.y, progressIcon.transform.position.z);

	}
}
