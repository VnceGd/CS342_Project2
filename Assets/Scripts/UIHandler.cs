using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIHandler : MonoBehaviour
{
    public GameObject eventManager;
    private EventHandler eventHandler;

    public GameObject blackOutPanel;

    public float panelOpacity;
    private bool fading;

    // Start is called before the first frame update
    public void Start()
    {
        eventHandler = eventManager.GetComponent<EventHandler>();

        panelOpacity = 0.0f;
        blackOutPanel.GetComponent<Image>().color = new Color(0.0f, 0.0f, 0.0f, panelOpacity);

        fading = false;
    }

    // Update is called once per frame
    private void Update()
    {
        if(fading == true)
        {
            if (panelOpacity < 1.0f)
            {
                panelOpacity += Time.deltaTime / 5;
                blackOutPanel.GetComponent<Image>().color = new Color(0.0f, 0.0f, 0.0f, panelOpacity);
            }
            else
            {
                fading = false;
                eventHandler.GameOver();
            }
        }
    }

    public void BlackOut()
    {
        fading = true;
    }
}
