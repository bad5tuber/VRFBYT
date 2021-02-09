using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Weapon : MonoBehaviour
{
    public float recoil = 1.0f;
    public Transform barrel = null;
    public GameObject projectilePrefab = null;

    private XRGrabInteractable interactable = null;
    private Rigidbody rigidBody = null;

    // He uses Awake for getting components and setting up functionality itself
    private void Awake()
    {
        interactable = GetComponent<XRGrabInteractable>();
        rigidBody = GetComponent<Rigidbody>();
    }

    // whenever enabled, it will hook itself up to interactable
    // when disabled
    // same as process where we clicked an object in heirarchy and drag into inspector
    // instead of On Select Enter and On Select Exited, OnEnable and OnDisable
    private void OnEnable()
    {
        interactable.onActivate.AddListener(Fire);
    }

    private void OnDisable()
    {
        interactable.onActivate.RemoveListener(Fire);
    }

    // create a firing functionality (function)
    private void Fire(XRBaseInteractor interactor)
    {
        CreateProjectile();
        ApplyRecoil();
    }

    private void CreateProjectile()
    {
        GameObject projectileObject = Instantiate(projectilePrefab, barrel.position, barrel.rotation);
        Projectile projectile = projectileObject.GetComponent<Projectile>();
        projectile.Launch();
    }    
    // using Vector3.right as we're wanting to go in the backward direction of the bullet
    private void ApplyRecoil()
    {
        rigidBody.AddRelativeForce(Vector3.right * recoil, ForceMode.Impulse);
    }
}

