using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterBallGame : MonoBehaviour
{
    public Transform shootAt;
    public Transform shooter0;
    public Transform shooter1;
    public float speed = 5.0f;
    public float interval = 3f;

    private float nextBallTime = 0f;
    private ObjectPooler objectPooler;
    private AudioSource soundEffect;
    private int shooterId;

    void Start()
    {
        if (shootAt == null)
            shootAt = Camera.main.transform;

        soundEffect = GetComponent<AudioSource>();
        if (soundEffect == null)
            Debug.LogError("Requires AudioSource component");

        objectPooler = GetComponent<ObjectPooler>();
        if (objectPooler == null)
            Debug.LogError("Requires ObjectPooler component");

        if (shooter0 == null || shooter1 == null)
            Debug.LogError("Requires shooter transforms");

        Time.fixedDeltaTime = 0.001f;

        AudioProcessor processor = FindObjectOfType<AudioProcessor>();
        //processor.onBeat.AddListener(OnBeatDetected);
        StartCoroutine(Shoot());
    }

    private IEnumerator Shoot()
    {
        while (true)
        {
            OnBeatDetected();
            yield return new WaitForSeconds(0.25f);
        }
    }

    void OnBeatDetected()
    {
        if (Random.value < 0.5f)
        {
            ShootBall(shooter0);
        }
        else
        {
            ShootBall(shooter1);
        }
    }

    //void Update()
    //{
    //    if (Time.time > nextBallTime)
    //    {
    //        if (shooterId == 0)
    //        {
    //            ShootBall(shooter0);
    //            shooterId = 1;
    //        }
    //        else
    //        {
    //            ShootBall(shooter1);
    //            shooterId = 0;
    //        }

    //        nextBallTime = Time.time + interval;
    //    }
    //}

    private void ShootBall(Transform shooter)
    {
        GameObject ball = objectPooler.GetPooledObject();
        if (ball != null)
        {
            ball.transform.position = shooter.position;
            ball.transform.rotation = Quaternion.identity;

            Rigidbody rb = ball.GetComponent<Rigidbody>();
            rb.angularVelocity = Vector3.zero;
            shooter.transform.LookAt(shootAt);
            rb.velocity = shooter.forward * speed;

            ball.SetActive(true);
            soundEffect.Play();
        }
    }
}
