using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour
{
    public GameScores gs;
    // Start is called before the first frame update
    void Start()
    {
        gs = GameObject.FindWithTag("Gamescores").GetComponent<GameScores>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    

    public void OnTriggerStay2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            gs.Inputtext.text = ("Input Q LoadLv2");
            if (Input.GetKeyDown(KeyCode.Q))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
        }
    }
    public void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            gs.Inputtext.text = ("");
        }
    }
}
