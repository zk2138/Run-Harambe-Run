using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using System.IO;
using UnityEngine.SceneManagement;

public class CollisionDetection : MonoBehaviour
{

    //public TextAsset dictionaryTextFile;
    private GameObject meni;
    float score;

    public void OnTriggerEnter(Collider other)
    {
        
        if (gameObject.tag == "Enemy")
        {
            SceneManager.LoadScene("MenuDeath");
        }
        else if (gameObject.tag == "Bonus1")
        {
            AudioSource audio = gameObject.AddComponent<AudioSource>();
            audio.PlayOneShot((AudioClip)Resources.Load("/Sounds/bonus"));
            Destroy(this.gameObject);
            Score.score += 10;
        }
        else if(gameObject.tag == "Bonus")
        {
            Destroy(this.gameObject);
            Score.score += 20;
        }


    }
}
