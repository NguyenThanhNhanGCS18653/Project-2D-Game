using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameScores : MonoBehaviour
{
    public int gold = 0;
    public Text Goldtext;
    public Text Inputtext;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Goldtext.text = ("Gold: " + gold);
    }
}
