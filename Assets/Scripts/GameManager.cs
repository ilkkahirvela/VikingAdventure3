using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public static GameManager manager;


    private void Awake()
    {
        // Singleton
        // Tarkastetaan onko olemassa manageria
        if(manager == null)
        {
            // Jos ei ole manageria, kerrotaan ett‰ t‰m‰ luokka on manageri. 
            // M‰‰ritell‰‰n, ett‰ t‰m‰ objekti ei tuhoudu scenevaihdon v‰lill‰.
            DontDestroyOnLoad(gameObject);
            manager = this;
        }
        else
        {
            // T‰m‰ else ajetaan jos on jo olemassa manageri ja yritet‰‰n luoda toinen manageri. T‰m‰ ei k‰y.
            // Tuhotaan toinen manageri heti pois, j‰‰ vain ensimm‰inen.
            Destroy(gameObject);

        }


    }


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            // M-kirjainta painettu, siirryt‰‰n Main Menu sceneen. 
            SceneManager.LoadScene("MainMenu");
        }


    }
}
