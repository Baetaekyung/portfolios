using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GhostPicture : MonoBehaviour
{
    public GameObject searchingPanel;
    public GameObject namepanel;
    public TextMeshProUGUI ghostName;

    private void Awake()
    {
        searchingPanel.SetActive(true);
        namepanel.SetActive(false);
    }

    private void Update()
    {
        if(GameManager.Instance.ghostName == "")
        {
            ghostName.text = "???";
        }
        else
        {
            searchingPanel.SetActive(false);
            namepanel.SetActive(true);
            ghostName.text = GameManager.Instance.ghostName;
        }
    }
}
