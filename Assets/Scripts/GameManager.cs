using UnityEngine;
using UnityEngine.SceneManagement;
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class GameManager : MonoBehaviour
{

    public static GameManager manager;

    public string currentLevel;

    public float health;
    public float previousHealth;
    public float maxHealth;

    // Jokaista tasoa varten tarvitaan boolean muuttuja. Muuttujan nimi tulee olla
    // Sama kuin mapissa olevan triggerobjektin levelToLoad muutujan nimi eli esim. Level1, Level2, Level3, huomaa iso L
    public bool Level1;
    public bool Level2;
    public bool Level3;

    private void Awake()
    {
        // Singleton
        // Tarkastetaan onko olemassa manageria
        if (manager == null)
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

    public void Save()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/playerInfo.Dat");
        PlayerData data = new PlayerData();
        // Siirret‰‰n tieto Game Managerista data:an
        data.health = health;
        data.previousHealth = previousHealth;
        data.maxHealth = maxHealth;
        data.Level1 = Level1;
        data.Level2 = Level2;
        data.Level3 = Level3;
        data.currentLevel = currentLevel;
        // Serialisointi
        bf.Serialize(file, data);
        file.Close();

    }

    public void Load()
    {
        // Tarkastetaan onko edes olemassa tiedostoa, josta voidaan ladata dataa.
        if (File.Exists(Application.persistentDataPath + "/playerInfo.dat"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/playerInfo.dat", FileMode.Open);
            PlayerData data = (PlayerData)bf.Deserialize(file);
            file.Close();

            // Siirret‰‰n data takaisin Game Manageriin, joka voi hyˆdynt‰‰ tiedon peliss‰
            health = data.health;
            previousHealth = data.previousHealth;
            maxHealth = data.maxHealth;
            Level1 = data.Level1;
            Level2 = data.Level2;
            Level3 = data.Level3;
            currentLevel = data.currentLevel;
        }

    }
}

// Uusi luokka, joka on serialisoitavissa. Pit‰‰ sis‰l‰‰n vain sen datan mit‰ tallennetaan
[Serializable]
class PlayerData
{
    public string currentLevel;
    public float health;
    public float previousHealth;
    public float maxHealth;
    public bool Level1;
    public bool Level2;
    public bool Level3;

}