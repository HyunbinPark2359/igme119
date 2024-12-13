using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiritsManager : MonoBehaviour
{
    [SerializeField] private SpiritController fireSpirit;
    [SerializeField] private SpiritController waterSpirit;
    [SerializeField] private SpiritController grassSpirit;
    [SerializeField] private AudioClip toFire;
    [SerializeField] private AudioClip toWater;
    [SerializeField] private AudioClip toGrass;
    private float switchCooldown = 0.3f;
    private float cooldownTimer = Mathf.Infinity;

    private enum SpiritMode
    {
        fire,
        water,
        grass
    }
    private SpiritMode currentlySpawnedSpirit = SpiritMode.fire;

    private void Awake()
    {
        fireSpirit.gameObject.SetActive(true);
        waterSpirit.gameObject.SetActive(false);
        grassSpirit.gameObject.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.X) && cooldownTimer > switchCooldown)
        {
            switchMode();
        }

        cooldownTimer += Time.deltaTime;
    }

    private void switchMode()
    {
        cooldownTimer = 0.0f;

        if (currentlySpawnedSpirit == SpiritMode.fire)
        {
            currentlySpawnedSpirit = SpiritMode.water;
            fireSpirit.gameObject.SetActive(false);
            waterSpirit.gameObject.SetActive(true);
            SetDirectionAndPosition(fireSpirit, waterSpirit);
            SoundManager.instance.PlaySound(toWater);
        }
        else if (currentlySpawnedSpirit == SpiritMode.water)
        {
            currentlySpawnedSpirit = SpiritMode.grass;
            waterSpirit.gameObject.SetActive(false);
            grassSpirit.gameObject.SetActive(true);
            SetDirectionAndPosition(waterSpirit, grassSpirit);
            SoundManager.instance.PlaySound(toGrass);
        }
        else if (currentlySpawnedSpirit == SpiritMode.grass)
        {
            currentlySpawnedSpirit = SpiritMode.fire;
            grassSpirit.gameObject.SetActive(false);
            fireSpirit.gameObject.SetActive(true);
            SetDirectionAndPosition(grassSpirit, fireSpirit);
            SoundManager.instance.PlaySound(toFire);
        }
    }

    private void SetDirectionAndPosition(SpiritController before, SpiritController after)
    {
        if (Mathf.Sign(after.transform.localScale.x) != Mathf.Sign(before.transform.localScale.x))
        {
            after.transform.localScale = new Vector3(-after.transform.localScale.x, after.transform.localScale.y, after.transform.localScale.z);
        }
        if (before.transform.position != after.transform.position)
        {
            after.transform.position = before.transform.position;
        }
    }
}
