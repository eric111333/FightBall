using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InstBall : MonoBehaviour
{
    [SerializeField]public float attackGas =1;
    [SerializeField]public Text attacknub;
    [SerializeField] GameObject heroGas;
    private SpriteRenderer heroGasspr;
    static public InstBall instance = null;
    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        heroGasspr = heroGas.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        heroGasspr.color = new Color(1, 1, 1, (attackGas * 0.1f));
        if(attackGas>10)
            heroGasspr.color = new Color(0.9f, 0.3f, 0.3f, (attackGas * 0.1f));        
        if(attackGas>100)
            heroGasspr.color = new Color(0.2f, 0.3f, 0.8f, (attackGas * 0.1f));
        if(attackGas>1000)
            heroGasspr.color = new Color(0.9f, 0.9f, 0.03f, (attackGas * 0.1f));
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Ball" || collision.tag == "Ballone")
        {
            attackGas *= 2f;
            attacknub.text = "" + attackGas;
            //testFloat.ToString("0")¡÷1
        }
    }
}
