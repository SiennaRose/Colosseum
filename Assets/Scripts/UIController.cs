using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{
    public static UIController instance = null;
    public PlayerState myPlayer;
    public AudioClip startSound;

    public static UIController Instance
    {
        get { return instance; }
    }

    public void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            if (instance != this)
                Destroy(gameObject);
        }
        myPlayer = gameObject.AddComponent<PlayerState>() as PlayerState;
        AudioSource audio = GetComponent<AudioSource>();
        audio.PlayOneShot(startSound);
    }

    void Start()
    {
        StartCoroutine(Splash());
    }

    public IEnumerator Splash()
    {
        yield return new WaitForSeconds(5);
        SceneManager.LoadScene(1);
    }

    public void PlayGame()
    {
        SceneManager.LoadScene(2);
    }

    public void QuitGame()
    {
        #if UNITY_EDITOR
                        UnityEditor.EditorApplication.isPlaying = false;
        #else
                Application.Quit();
        #endif
    }

    public void Back()
    {
        SceneManager.LoadScene(1);
    }

    public void Died()
    {
        SceneManager.LoadScene(3);
    }

}
