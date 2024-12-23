using System;
using System.Collections;
using System.Collections.Generic;
using TopDownShooter;
using UnityEngine;
using static UnityEngine.EventSystems.EventTrigger;

public class BulletProjectile : MonoBehaviour {

    [SerializeField] private Transform vfxHitGreen;
    [SerializeField] private Transform vfxHitRed;

    private Rigidbody bulletRigidbody;

    private void Awake() {
        bulletRigidbody = GetComponent<Rigidbody>();
    }

    private void Start() {
        float speed = 50f;
        bulletRigidbody.velocity = transform.forward * speed;
    }

    private void OnTriggerEnter(Collider other) {
        if (other.GetComponent<BulletTarget>() != null) {
            Instantiate(vfxHitRed, transform.position, Quaternion.identity);
            GameObject hitEnemy = other.gameObject;
            hitEnemy.SetActive(false);
            StartCoroutine(RespawnEnemy(hitEnemy));
            ThirdPersonShooterController shooterController = FindObjectOfType<ThirdPersonShooterController>();
            shooterController.EnemyDefeated();
        }else if (other.GetComponent<CubeTrigger>()) {
            Instantiate(vfxHitGreen, transform.position, Quaternion.identity);
            Debug.Log("Hit the cube");
        }
        Destroy(gameObject);
    }

    private IEnumerator RespawnEnemy(GameObject enemy) {
        yield return new WaitForSeconds(1f);
        if (enemy != null)
        {
            enemy.SetActive(true);
        }
    }

}