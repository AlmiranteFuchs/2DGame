using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GolpeBeh : SkllBehaviour
{
    [SerializeField]
    float circleRadius;
    public override void Behaviour()
    {
        base.Behaviour();
        Debug.Log("Gira gira gira");
        Collider2D[] enemies = Physics2D.OverlapCircleAll(skillParent.controller.charStats.gameObject.transform.position,
         circleRadius);
        if (enemies.Length != 0)
        {
            for (int i = 0; i < enemies.Length; i++)
            {
                if (enemies[i].CompareTag("Enemy"))
                {
                    //"Explosion" like
                    Vector2 dir= enemies[i].transform.position - skillParent.controller.charStats.gameObject.transform.position;
                    enemies[i].GetComponent<Rigidbody2D>().AddForce(dir*2,ForceMode2D.Impulse);
                    enemies[i].GetComponent<CharacterStats>().TakeDamage(skillParent.skillDmg);
                    Debug.Log(enemies[i].gameObject.name + "Has taken dmg");
                }
            }
        }
        else
        {
            Debug.Log("Nenhum enemy");
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(Vector2.zero,
         circleRadius);
    }
}
