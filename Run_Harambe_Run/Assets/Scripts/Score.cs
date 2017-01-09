using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Score : MonoBehaviour {

    static public float score = 0.0f;
    public Text scoreText;
    public Animator animator;
    private float multiply = 1.0f;
    private int level = 1;
    private int scoreToNext = 20;

    // Use this for initialization
    void Start () {
        //anim.speed = 2.0f;
    }
	
	// Update is called once per frame
	void Update () {
        if(score >= scoreToNext)
        {
            scoreToNext *= 2;
            level++;
            ChangeStateSpeed();
        }
        score += Time.deltaTime * level;
        scoreText.text = ((int)score).ToString();

	}
    void ChangeStateSpeed()
    {
        multiply = multiply + 0.25f;
        animator.SetFloat("Speed", multiply);
    }
}
