using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadLevel : MonoBehaviour
{
    public string LevelToLoad;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       // Katsotaan aina Map scene avattaessa, ett‰ onko Game Managerissa merkattu, ett‰ kyseinen taso on l‰p‰isty
       //Jos on l‰p‰isty, ajetaan Cleared funktio, joka tekee muutokset Level Cleared kuvaan ja collideriin.
       if(GameManager.manager.GetType().GetField(LevelToLoad).GetValue(GameManager.manager).ToString() == "True")
        {
            // T‰m‰ taso on l‰pi
            Cleared(true);
            
        }
    }

    public void Cleared(bool isClear)
    {
        if (isClear)
        {
            // Asetetaan Game Managerissa oikea boolean arvo trueksi esim. Level1
            GameManager.manager.GetType().GetField(LevelToLoad).SetValue(GameManager.manager, true);
            // Laitetaan levelcleared kyltti n‰kyviin
            transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().enabled = true;
            // Taso p‰‰sty l‰pi. Laitetaan circle collider pois p‰‰lt‰, ettei tasoon en‰‰ menn‰.
            GetComponent<CircleCollider2D>().enabled = false;
            
            
        }
    }
}
