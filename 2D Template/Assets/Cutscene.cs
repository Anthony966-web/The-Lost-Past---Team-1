using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Playables;

public class Cutscene : MonoBehaviour
{
    public GameObject Wizard_0;

    
    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            print("Playing");
            Wizard_0.GetComponent<Animator>().SetBool("Collided", true);
            Wizard_0.GetComponent<PlayableDirector>().Play();
        }
    }
}
