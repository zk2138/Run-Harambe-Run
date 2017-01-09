using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamFollowing : MonoBehaviour {

    private Transform lookAt;
    private Vector3 offSet;

    private float transition = 0.0f;
    private float animationDuration = 1.5f;
    private Vector3 animationOffSet = new Vector3(0, 5, -3);

    private Vector3 moveVector;
	// Use this for initialization
	void Start () {
        lookAt = GameObject.FindGameObjectWithTag("Player").transform;
        offSet = transform.position - lookAt.position;
	}
	
	// Update is called once per frame
	void Update () {
        moveVector = lookAt.position + offSet;
        moveVector.x = lookAt.position.x;
        moveVector.y = Mathf.Clamp(moveVector.y, 3, 5);
        if (transition > 1.0f)
        {
            transform.position = moveVector;
        }
        else
        {
            Score.score = 0.0f;
            transform.position = Vector3.Lerp(moveVector + animationOffSet, moveVector,transition);
            transition += Time.deltaTime * 1 / animationDuration;
            transform.LookAt(lookAt.position);
        }
	}
}
