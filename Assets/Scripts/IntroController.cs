using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class IntroController : MonoBehaviour
{
    public VideoPlayer VideoPlayer;
    // Start is called before the first frame update
    void Start()
    {
        VideoPlayer.loopPointReached += LoadScene;
    }

    // Update is called once per frame
    void LoadScene(VideoPlayer vp)
    {
            SceneController.toGame();
    }
}
