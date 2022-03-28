using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 
/// </summary>
public class Germ : Enemy
{
    protected override void Start()
    {
        StartCoroutine(Attack());
        base.Start();
    }

    protected override IEnumerator Attack()
    {
        for (int i = 0;i < 3 ;i++)
        {

            GameObject bullet = Instantiate(base.bullet, transform.position, transform.rotation);

            Bullet bulletLogic = bullet.GetComponent<Bullet>();

            bulletLogic.power = this.power;

            yield return new WaitForSeconds(1f);
        }

    }
}
