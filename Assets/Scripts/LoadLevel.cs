using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadLevel : MonoBehaviour
{
    public string LevelToLoad;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       
    }

    public void Cleared(bool isClear)
    {
        if (isClear)
        {

            // Laitetaan levelcleared kyltti n‰kyviin
            transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().enabled = true;
            // Taso p‰‰sty l‰pi. Laitetaan circle collider pois p‰‰lt‰, ettei tasoon en‰‰ menn‰.
            GetComponent<CircleCollider2D>().enabled = false;


        }
    }
}
