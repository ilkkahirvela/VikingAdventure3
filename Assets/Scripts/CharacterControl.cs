using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CharacterControl : MonoBehaviour
{

    public float moveSpeed;
    public float jumpForce;

    public Animator animator; // Animattori, t‰t‰ kutsutaan jos halutaan muokata animaatioiden ajoa
    public Rigidbody2D rb2D; // Fysiikka, t‰ll‰ laitetaan hahmo hypp‰‰m‰‰n. 

    public Transform groundCheckPosition;
    public float groundCheckRadius;
    public LayerMask groundCheckLayer;
    public bool grounded;
    public float maxCounter;
    public Image filler;
    public float counter;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animator = GetComponent<Animator>();
        rb2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

        // Ground test, ollaanko maassa vai ilmassa?
        if(Physics2D.OverlapCircle(groundCheckPosition.position, groundCheckRadius, groundCheckLayer))
        {
            grounded = true;

        }
        else
        {
            grounded = false;
        }


        transform.Translate(Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime, 0, 0);

        if(Input.GetAxisRaw("Horizontal") != 0)
        {
            // Meill‰ on joko a tai d pohjassa = ollaan liikkeess‰
            transform.localScale = new Vector3(Input.GetAxisRaw("Horizontal"), 1, 1);
            animator.SetBool("Walk", true);
        }
        else
        {
            // Else ajetaan vain jos ei liikuta
            animator.SetBool("Walk", false);
        }

        if (Input.GetButtonDown("Jump") && grounded == true)
        {
            // V‰lilyˆnti painettu t‰ll‰ framella
            rb2D.velocity = new Vector2(0, jumpForce);
            animator.SetTrigger("Jump");


        }

        if(counter > maxCounter)
        {
            GameManager.manager.previousHealth = GameManager.manager.health;
            counter = 0;
        }
        else
        {
            counter += Time.deltaTime;
        }

        filler.fillAmount = Mathf.Lerp(GameManager.manager.previousHealth/ GameManager.manager.maxHealth, GameManager.manager.health /GameManager.manager.maxHealth, counter/maxCounter);
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("LevelEnd"))
        {
            SceneManager.LoadScene("Map");

        }


    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Trap"))
        {
            TakeDamage(15);
        }
    }

    public void TakeDamage(float dmg)
    {
        GameManager.manager.previousHealth = filler.fillAmount * GameManager.manager.maxHealth;
        counter = 0;
        GameManager.manager.health -= dmg;

    }
}
