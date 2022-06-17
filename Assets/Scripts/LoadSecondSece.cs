using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSecondSece : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("LoadNextScene",3f);
    }

    // Update is called once per frame
   void LoadNextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
