using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletTarget : MonoBehaviour
{
    private ThirdPersonShooterController shooterController;

    void Start()
    {
        shooterController = FindObjectOfType<ThirdPersonShooterController>();
    }

    public void OnDefeated() {
        shooterController.EnemyDefeated();
    }


}
