using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayGm : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadSceneAsync(1);
    }
}
