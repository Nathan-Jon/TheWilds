using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonHandler : MonoBehaviour {


	/// <summary>
    /// Change the scene to the assigned value
    /// </summary>
    /// <param name="sceneNum"></param>
	public void ChangeScene(int sceneNum)
    {
        SceneManager.LoadScene(sceneNum);
    }

    /// <summary>
    /// Closes the application 
    /// </summary>
    public void CloseApplication()
    {
        Application.Quit();
    }
}
