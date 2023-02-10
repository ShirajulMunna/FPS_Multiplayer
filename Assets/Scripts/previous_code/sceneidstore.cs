using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class sceneidstore : MonoBehaviour
{
    public static sceneidstore Instance;
    
    void Awake()
    {
       
        
        if (Instance != null)
        {
            Destroy(gameObject);
        }
        else  
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
    public int sceneId;

    void  munna()
    {
        if (sceneId == 1)
        {
            SceneManager.LoadScene("Instructor_UI");
        }

        if (sceneId == 2) 
        {

            SceneManager.LoadScene("TraineeUI");
        }
    }
}
