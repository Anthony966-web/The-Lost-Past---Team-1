using UnityEngine;
using UnityEngine.SceneManagement;

public class Teleport : MonoBehaviour
{
    public string SceneName; // Has to be exact
    public bool sameScene;
    public Transform player;
    public Vector3 tpPosition;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            player = collision.gameObject.transform;
            TP(SceneName);
        }
    }

    public void TP(string sceneName)
    {
        if(sameScene)
        {
            player.position = new Vector3(tpPosition.x, tpPosition.y, tpPosition.z);
        }
        else
        {
            SceneManager.LoadScene(sceneName);
        }
    }

    public void CloseGame() // this is here because it was just easier instead of makeing a whole new script just for this
    {
        Application.Quit();
    }
}
