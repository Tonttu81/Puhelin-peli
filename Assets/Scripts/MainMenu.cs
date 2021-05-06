using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public Camera cam;
    public GameObject Explosion;

    public GameObject brokenButtonPrefab;

    public GameObject panel1;
    public GameObject panel2;

    private void Start()
    {
        
    }

    private void Update()
    {
        
    }

    public void PlayGame()
    {
        //Vector3 temp = cam.ScreenToWorldPoint(Input.mousePosition);
        //Vector3 pos = new Vector3(temp.x, temp.y, 0f);
        //Instantiate(brokenButtonPrefab, pos, Quaternion.identity);

        //Destroy();

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        
    }
    public void ExitGame()
    {
        //Vector3 temp = cam.ScreenToWorldPoint(Input.mousePosition);
        //Vector3 pos = new Vector3(temp.x, temp.y, 0f);
        //Instantiate(brokenButtonPrefab, pos, Quaternion.identity);

        Application.Quit();
    }
}
