using UnityEngine;
using UnityEngine.SceneManagement;

public class Teleport : MonoBehaviour
{
    public string SceneName; // Has to be exact

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            TP(SceneName);
        }
    }

    public void TP(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void CloseGame() // this is here because it was just easier instead of makeing a whole new script just for this
    {
        Application.Quit();
    }
}
