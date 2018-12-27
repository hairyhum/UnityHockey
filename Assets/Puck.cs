using System.Collections;
using System.Collections.Generic;
using UnityEngine;

struct Score {
    public int blue;
    public int orange;
}

public class Puck : MonoBehaviour {

    public GameObject BlueGate;
    public GameObject OrangeGate;

    Score score = new Score{blue = 0, orange = 0};

    // Use this for initialization
    void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnCollisionEnter2D(Collision2D col)
    {
        Debug.Log(col.gameObject.name);
        if(col.gameObject == BlueGate){
            score.blue++;
            BlueGate.transform.Find("Score").GetComponent<TextMesh>().text = score.blue.ToString();
        } else if(col.gameObject == OrangeGate)
        {
            score.orange++;
            OrangeGate.transform.Find("Score").GetComponent<TextMesh>().text = score.orange.ToString();
        }
    }
}
