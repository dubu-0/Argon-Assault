using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Player
{
    public class PlayerShooting : MonoBehaviour
    {
        [SerializeField] private ParticleSystem[] laserEmitters;
        [SerializeField] private float rateOfFire;
        
        private const string Fire1 = nameof(Fire1);

        private Coroutine _shooting;
        private int _emitterIndex;
        private bool _isFiring;

        private void Update()
        {
            StartShooting();
        }

        private void StartShooting()
        {
            if (Input.GetAxis(Fire1) != 0 && !_isFiring)
            {
                _shooting = StartCoroutine(Shooting());
                _isFiring = true;
            }
            else if (Input.GetAxis(Fire1) == 0 && _isFiring)
            {
                StopCoroutine(_shooting);
                _isFiring = false;
                _emitterIndex = Random.Range(0, laserEmitters.Length);
            }
        }
        
        private IEnumerator Shooting()
        {
            while (true)
            {
                laserEmitters[_emitterIndex % laserEmitters.Length].Emit(1);
                _emitterIndex++;
                yield return new WaitForSeconds(1 / rateOfFire);
            }
        }
    }
}
