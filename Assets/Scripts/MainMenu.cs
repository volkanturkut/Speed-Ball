using UnityEngine;
using UnityEngine.SceneManagement;

public class NewMonoBehaviourScript : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKey("escape"))
        {
            SceneManager.LoadScene(0);
        }
    }
    public void PlayApp()
    {
        SceneManager.LoadScene("Level01");
    }

    // Update is called once per frame
    public void AppQuit()
    {
        Application.Quit();
        Debug.Log("Çıkış Yapıldı");
    }

    public void AppMenu()
    {
        SceneManager.LoadScene(0);
    }
}
