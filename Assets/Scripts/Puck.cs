using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

struct Score {
    public int blue;
    public int orange;
}

public class Puck : MonoBehaviour {

    public GameObject BlueGate;
    public GameObject OrangeGate;

    public Text BlueScore;
    public Text OrangeScore;

    Score score = new Score{blue = 0, orange = 0};

    // Use this for initialization
    void Start () {
        UpdateScore();
	}

    void UpdateScore(){
        BlueScore.text = score.blue.ToString();
        OrangeScore.text = score.orange.ToString();
    }
	
	// Update is called once per frame
	void Update () {
		
	}



    void OnCollisionEnter2D(Collision2D col)
    {
        Debug.Log(col.gameObject.name);
        if(col.gameObject == BlueGate){
            score.blue++;
        } else if(col.gameObject == OrangeGate)
        {
            score.orange++;
        }
        UpdateScore();
    }
}
