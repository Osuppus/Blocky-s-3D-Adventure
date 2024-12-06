using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinCollect : MonoBehaviour
{
    [SerializeField] AudioSource coinFX; 
   
   void OnTriggerEnter(Collider other)
   {
     coinFX.Play();
     this.gameObject.SetActive(false);
   } 
}
