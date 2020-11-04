using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class VideoScript : MonoBehaviour
{
    VideoPlayer video;

    void Awake()
    {
        video = GetComponent<VideoPlayer>();
        video.loopPointReached += CheckOver;
    }


    void CheckOver(UnityEngine.Video.VideoPlayer vp)
    {
        int maxRange = SceneManager.sceneCountInBuildSettings - 2;
        int randomLevel = Random.Range(3, maxRange);
        SceneManager.LoadScene(randomLevel);
    }
}
