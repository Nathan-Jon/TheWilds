using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Handles which weather affect is currently in place and the temperature in the scene
/// Author : Nathan Robertson - Version 0.1
/// </summary>
public class WeatherManagerScript : MonoBehaviour, IWeatherManager
{

    //enum for the weather state
    WeatherStates weather;
    WeatherStates CurrentWeather;

    //variables for the weather temperatures
    [SerializeField] float CurrentTemp;
    [SerializeField] float CalmTemp;
    [SerializeField] float HighWindsTemp;
    [SerializeField] float StormTemp;


    float time;


    /// <summary>
    /// states for the various weather types
    /// </summary>
    enum WeatherStates
    {
        Calm,
        HighWinds,
        SnowStorm,
    }

    WeatherStates getWeatherState { get { return weather; } set { weather = value; } }
    public float Temperature { get { return CurrentTemp; } set { CurrentTemp = value; } }


    private void Start()
    {
        GameObject.FindGameObjectWithTag("Player").AddComponent<TemperatureHealthScript>().Initialise(this);

        //initialise the weather state
        if (weather != WeatherStates.Calm)
        {
            weather = WeatherStates.Calm;
            CurrentWeather = weather;
        }

        //initialise the current temperature if val = 0
        if (CurrentTemp == 0)
            CurrentTemp = -2f;

        // throw exception if any weather types have no temperature value
        if (HighWindsTemp == 0 || StormTemp == 0)
            throw new Exception("A weather temperature hasn't been set");
    }


    /// <summary>
    /// method to handle the necessary changes in each state
    /// </summary>
    private void ManageStates()
    {
        //
        WeatherCheck(weather);

        //this wil constantly set the values
        switch (weather)
        {
            case WeatherStates.Calm:
                GameObject.Find("WeatherText").gameObject.GetComponent<Text>().text = "calm";
                CurrentTemp = CalmTemp;
                //Update the UI state

                if (time >= 3)
                    weather = WeatherStates.HighWinds;
                
                break;

            case WeatherStates.HighWinds:
                GameObject.Find("WeatherText").gameObject.GetComponent<Text>().text = "High Winds";

                CurrentTemp = HighWindsTemp;
                if (time >= 3)
                    weather = WeatherStates.SnowStorm;
                //Update the UI state
                break;

            case WeatherStates.SnowStorm:
                CurrentTemp = StormTemp;
                GameObject.Find("WeatherText").gameObject.GetComponent<Text>().text = "Storm";

                if (time >= 3)
                    weather = WeatherStates.Calm;
                //Update UI State

                break;

            default:
                Debug.Log(" Weather state improperly set");

                break;
        }
    }


    private void WeatherCheck(WeatherStates _weather)
    {
        if (_weather != CurrentWeather)
        {
            CurrentWeather = weather;
            time = 0;
        }
    }
    private void Update()
    {

        //insert conditions for weather changes
        //<---------------- Need better conditions ------------->
        time += Time.deltaTime;

        ManageStates();



    }
}
