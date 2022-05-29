using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FuelBar : MonoBehaviour
{
    public Slider slider;
    public Gradient gradient;
    public Image fill;

    public void SetFuel(float fuel){
        slider.value = Mathf.Clamp(fuel, slider.minValue, slider.maxValue);
        fill.color = gradient.Evaluate(slider.normalizedValue);
    }

}
