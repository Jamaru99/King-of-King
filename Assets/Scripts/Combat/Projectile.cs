using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] float damage = 5f;
    [SerializeField] float speed;
    [SerializeField] float maxTimeAlive = 5f;
    
    // Essa prefab deveria ficar no Gun e lá chamar o Instantiate 
    // mas kkkkkk to com preguiça de mudar
    [SerializeField] GameObject projectilePrefab;

    float projectileTotalDamage = 0;

    private void Update() 
    {
        Vector2 localRight  = transform.InverseTransformDirection(Vector2.right);
        float frameIndependentSpeed = speed * Time.deltaTime;

        transform.Translate(localRight * frameIndependentSpeed);
    }
    
    public void Shoot(float weaponDamage, Transform gunPipe)
    {
        if (gunPipe == null) { return;}

        projectileTotalDamage += weaponDamage + damage;
        var project = Instantiate(projectilePrefab, gunPipe.position, Quaternion.identity);
        Destroy(project, maxTimeAlive);
    }

    void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.tag == Constants.TagPlayer)
        {
            var player = other.GetComponent<Health>();
            if (player == null) { return;}
            
            player.TakeDamage(damage);
            Destroy(gameObject);
        }
    }
}
