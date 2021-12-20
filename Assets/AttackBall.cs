using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AttackBall : MonoBehaviour
{
    //[SerializeField] GameObject hero;
    [SerializeField] Animator hero;
    [SerializeField] Animator boss;
    [SerializeField] Slider bossHp;
    [SerializeField] float BossHp1;
    [SerializeField] float BossHpMax1;
    void Start()
    {
        BossHp1 = BossHpMax1;
        bossHp.value = BossHp1 / BossHpMax1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Ball" || collision.tag == "Ballone")
        {
            hero.SetTrigger("attack");
            boss.SetTrigger("hit");
            BossHp1 -= 1*InstBall.instance.attackGas;
            InstBall.instance.attackGas = 1;
            InstBall.instance.attacknub.text = "" + InstBall.instance.attackGas;
            bossHp.value = BossHp1 / BossHpMax1;
        }
            
            
            
    }
}
