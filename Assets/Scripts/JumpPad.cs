using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpPad : MonoBehaviour
{
  public float jumpForce= 15f;

  private void OnCollisionEnter(Collision collision)
  {
    if (collision.gameObject.CompareTag("Player"))
    {
      Rigidbody playerRigidbody = collision.gameObject.GetComponent<Rigidbody>();

      if (playerRigidbody != null)
      {
        playerRigidbody.velocity = new Vector3(playerRigidbody.velocity.x, 0, playerRigidbody.velocity.z);
        playerRigidbody.AddForce((Vector3.up * jumpForce), ForceMode.Impulse);
      }
    }
  }
}
