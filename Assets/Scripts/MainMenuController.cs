using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviour
{
    // Start is called before the first frame update
    public void StartGame()
    {
        SceneManager.LoadScene(1);
        //gameObject.GetComponent<Button>().onClick.AddListener(OnButtonClick);
    }

    public void onQuitButton()
    {
        Application.Quit();
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
