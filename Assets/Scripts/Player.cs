using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public float jumpForce = 10f;

    public Rigidbody2D rb;
    public SpriteRenderer sr;

    public string currentColor;

    public Color colorCyan;
    public Color colorYellow;
    public Color colorMagenta;
    public Color colorPink;

    void Start ()
    {
        SetRandomColor();
    }

// Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Jump") || Input.GetMouseButtonDown(0))
        {
            rb.velocity = Vector2.up * jumpForce;
        }

        // To stop player from going below the lowest point in this level. This makes it easy to play
        if(transform.position.y < -2f)
        {
            transform.position = new Vector2(0,-2f); 
        }

    }

    void OnTriggerEnter2D (Collider2D col)
    {
        if (col.tag == "ColorChanger")
        {
            SetRandomColor();
            Destroy(col.gameObject);
            return;
        }
        if (col.tag != currentColor && col.tag !=  "Ground")
        {
            Debug.Log("GAME OVER!" + col.name);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);  
        }
        if(col.tag == "Next Level")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); 
        }
    }

    void SetRandomColor ()
    {
        int index = Random.Range(0, 4);
    

        switch (index)
        {
            case 0:
                currentColor = "Cyan";
                sr.color = colorCyan;
                break;
            case 1:
                currentColor = "Yellow";
                sr.color = colorYellow;
                break;
            case 2:
                currentColor = "Magenta";
                sr.color = colorMagenta;
                break;
            case 3:
                currentColor = "Pink";
                sr.color = colorPink;
                break;
        }
    }
}
