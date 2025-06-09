using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class loadLevel : MonoBehaviour
{

    public string loadLevelName;
    
    // Start is called before the first frame update
    void Awake()
    {
        SceneManager.LoadScene(loadLevelName, LoadSceneMode.Additive);
    }


}
