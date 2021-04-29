using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIScript : MonoBehaviour
{
    public GridScript gridScript;

    public GameObject playButton;
    public GameObject retryButton;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (gridScript.playing)
        {
            playButton.SetActive(false);
            retryButton.SetActive(true);
        }
        else
        {
            playButton.SetActive(true);
            retryButton.SetActive(false);
        }
    }
}
