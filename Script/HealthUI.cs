using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthUI : MonoBehaviour
{
    public Slider slider;
    public Gradient gradientcolor;
    public Image full;

    // Start is called before the first frame update
    void Start()
    {
        slider = GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {


    }
    public void healthsetting(int HP)
    {
        slider.value = HP;
        full.color = gradientcolor.Evaluate(slider.normalizedValue);
    }
    public void maxhealth(int HP)
    {
        slider.value = HP;
        slider.maxValue = HP;
        full.color = gradientcolor.Evaluate(1f);
    }
}
