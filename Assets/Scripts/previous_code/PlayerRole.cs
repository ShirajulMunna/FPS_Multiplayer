using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerRole : MonoBehaviour
{
    public void OnClick_Instructor() 
    {
        SceneManager.LoadScene("Instructor_UI");
    }

    public void OnClick_Trainee() 
    {
        SceneManager.LoadScene("TraineeUI");
    }
}
