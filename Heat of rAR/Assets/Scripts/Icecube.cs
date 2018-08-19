using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Icecube : MonoBehaviour {

    [SerializeField]
    private float speed = 1.0f;

    [SerializeField]
    private float health = 100.0f;

    [SerializeField]
    private float maxHealth = 100.0f;

    [SerializeField]
    private float shakeStrength = 1.0f;

    [SerializeField]
    Color fullColor;

    [SerializeField]
    Color emptyColor;

    private List<string> names = new List<string>();
    private Transform cubeOrigin;
    private Transform healthBar;
    private RectTransform myCanvas;

    private bool enemyFound;

    // Use this for initialization
    void Start ()
    {
        createRandomNames();
        GetComponentInChildren<Text>().text = getRandomName();

        cubeOrigin = transform.Find("CubeModel");
        healthBar = transform.Find("CubeInformation/HealthBarOuter/HealthBarInner");
        myCanvas = transform.Find("CubeInformation").GetComponent<RectTransform>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (health <= 0.0f)
        {
            Destroy(gameObject);
            return;
        }

        float relativeHealth = health / maxHealth;

        // Scale cube mesh
        cubeOrigin.localScale = new Vector3(
            cubeOrigin.localScale.x,
            relativeHealth * cubeOrigin.localScale.x,
            cubeOrigin.localScale.z
        );

        // Change cube color
        GetComponentInChildren<Renderer>().material.color = Color.Lerp(emptyColor, fullColor, relativeHealth);
        
        // Scale inner health bar
        healthBar.localScale = new Vector3(
            relativeHealth,
            healthBar.localScale.y,
            healthBar.localScale.z
        );

        myCanvas.transform.LookAt(Camera.main.transform);

        //transform.Rotate(new Vector3(1.0f, 0.0f, 1.0f), Mathf.Sin(Time.time) * shakeStrength);
    }

    void FixedUpdate()
    {
        if (!enemyFound)
        {
            float step = speed * Time.deltaTime;
            transform.position += new Vector3(0, 0, -step);
        }
    }




        public void Damage ()
    {
        health--;
    }

    private string getRandomName()
    {
        int index = Random.Range(0, names.Count - 1);
        return names[index];
    }

    private void createRandomNames()
    {
        names.Add("Ice Cube");
        names.Add("Ice T");
        names.Add("Janina");
        names.Add("Katharina");
        names.Add("Stephan");
        names.Add("Paul");
        names.Add("René");
        names.Add("Katharina");
        names.Add("Peter");
        names.Add("Uwe");
        names.Add("Florian");
        names.Add("Steffen");
        names.Add("Ulrich");
        names.Add("Tim");
        names.Add("Sven");
        names.Add("Monika");
        names.Add("Christina");
        names.Add("Birgit");
        names.Add("Uta");
        names.Add("Katrin");
        names.Add("Jana");
    }

    // Here the enemy hits the player
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Temple"))
        {
            enemyFound = true;
          
            GetComponentInChildren<Animator>().SetTrigger("Attack");
            InvokeRepeating("makeDamage", 0, 1f);
            
            //Destroy(gameObject);
        }
    }

    void makeDamage()
    {
        FindObjectOfType<BaseController>().Damage();
    }
}
