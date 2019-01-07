using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TemperatureHealthScript : MonoBehaviour
{


    Image ThermostatUI;
    IWeatherManager weatherManager;

    float temperature;

    IFire fire;

    [SerializeField] float TickTime;
    float time;

    [SerializeField] float maxVal;
    float minVal;
    [SerializeField] float currentVal;
    float weatherTemp;
    float fireTemp;

    public float FireHeat { get { return fireTemp; } set { fireTemp = value; } }
    public float Temperature { get { return temperature; } set { temperature = value; } }
    // Use this for initialization
    void Start()
    {
        ThermostatUI = GameObject.Find("ThermostatUIContent").GetComponent<Image>();
        maxVal = 30;
        minVal = 0;
        currentVal = maxVal;
        ThermostatUI.fillAmount = currentVal / maxVal;
        if (TickTime == 0)
            TickTime = 2;
    }

    public void Initialise(IWeatherManager WeatherMgr)
    {
        weatherManager = WeatherMgr;
    }
    //Calculate Temperature
    void CalculateTemperature()
    {
        if (currentVal <= maxVal)
        {
            currentVal += (temperature + fireTemp);
            Debug.Log(temperature + " + " + fireTemp + " = " + (temperature + fireTemp));

            if (currentVal >= maxVal)
                currentVal = maxVal;
        }
    }

    private void Update()
    {
        time += Time.deltaTime;
        if (time >= TickTime)
        {
            CalculateTemperature();
            time = 0;
           
        }
        //Update UI based on the current temperature
        ThermostatUI.fillAmount = Mathf.Lerp(ThermostatUI.fillAmount, currentVal / maxVal, Time.deltaTime * 0.5f);

    }

}
