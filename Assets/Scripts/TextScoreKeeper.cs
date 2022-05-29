using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class TextScoreKeeper : MonoBehaviour
{
    public PlayerController playerController;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<TMPro.TextMeshProUGUI>().text = "Score: " + 0;
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<TMPro.TextMeshProUGUI>().text = "Score: " + playerController.getScore();
    }
}
