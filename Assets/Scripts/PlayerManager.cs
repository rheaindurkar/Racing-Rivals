using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerManager : MonoBehaviour
{ 
    public static bool isWin;
    public GameObject winscreen;

    private void Awake(){
        isWin = false;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isWin){
            winscreen.SetActive(true);

        }
        
    }

    public void ReplayLevel(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }
}
