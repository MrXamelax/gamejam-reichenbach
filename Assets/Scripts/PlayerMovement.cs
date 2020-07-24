using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerMovement : MonoBehaviour {

    [SerializeField] Rigidbody rbPlayer;
    [SerializeField] float movementSpeed;
    private float velLastY = 0;
    private bool grounded = true;

    void Start() {

    }

    void Update() {

        if (grounded) {
            if (Input.GetKey("w")) {
                if (Input.GetKey("s")) {

                    // Don't move when w and s are pressed at the same time
                    rbPlayer.velocity = Vector3.zero;
                } else {
                    rbPlayer.velocity = rbPlayer.transform.forward * movementSpeed;
                }
            }

            // Stop sliding upward
            if (Input.GetKeyUp("w")) {
                rbPlayer.velocity = Vector3.zero;
            }

            // Move downward
            if (Input.GetKey("s")) {
                if (Input.GetKey("w")) {

                    // Don't move when w and s are pressed at the same time
                    rbPlayer.velocity = Vector3.zero;
                } else {
                    rbPlayer.velocity = -rbPlayer.transform.forward * movementSpeed;
                }
            }

            // Stop sliding downward
            if (Input.GetKeyUp("s")) {
                rbPlayer.velocity = Vector3.zero;
            }

            // Move to the right
            if (Input.GetKey("d")) {
                if (Input.GetKey("a")) {

                    // Don't move when a and d are pressed at the same time
                    rbPlayer.velocity = Vector3.zero;
                } else {

                    // Move upward right when d and w are pressed at the same time
                    if (Input.GetKey("w")) {
                        rbPlayer.velocity = (rbPlayer.transform.forward + rbPlayer.transform.right) * (movementSpeed * 0.75f);
                    } else {

                        // Move downward right when d and s are pressed at the same time
                        if (Input.GetKey("s")) {
                            rbPlayer.velocity = (-rbPlayer.transform.forward + rbPlayer.transform.right) * (movementSpeed * 0.75f);
                        } else {
                            rbPlayer.velocity = rbPlayer.transform.right * movementSpeed;
                        }
                    }
                }
            }

            // Stop sliding to the right
            if (Input.GetKeyUp("d")) {
                rbPlayer.velocity = Vector3.zero;
            }

            // Move to the left
            if (Input.GetKey("a")) {
                if (Input.GetKey("d")) {

                    // Don't move when a and d are pressed at the same time
                    rbPlayer.velocity = Vector3.zero;
                } else {

                    // Move upward left when w and a are pressed at the same time
                    if (Input.GetKey("w")) {
                        rbPlayer.velocity = (rbPlayer.transform.forward - rbPlayer.transform.right) * (movementSpeed * 0.75f);
                    } else {

                        // Move downward left when s and a are pressed at the same time
                        if (Input.GetKey("s")) {
                            rbPlayer.velocity = (-rbPlayer.transform.forward - rbPlayer.transform.right) * (movementSpeed * 0.75f);
                        } else {
                            rbPlayer.velocity = -rbPlayer.transform.right * movementSpeed;
                        }
                    }
                }
            }

            // Stop sliding to the left
            if (Input.GetKeyUp("a")) {
                rbPlayer.velocity = Vector3.zero;
            }
        }

    }

    private void OnTriggerEnter(Collider col) {
        StartCoroutine(fall());
        StartCoroutine(respawn());
    }

    IEnumerator respawn() {
        yield return new WaitForSeconds(1.5f);
        rbPlayer.useGravity = false;
        rbPlayer.velocity = Vector3.zero;
        rbPlayer.transform.position = new Vector3(0, 1.06f, 0);
        grounded = true;
    }

    IEnumerator fall() {
        grounded = false;
        Debug.Log("Loch!");
        rbPlayer.useGravity = true;
        rbPlayer.velocity = new Vector3(rbPlayer.velocity.x * 0.8f, rbPlayer.velocity.y ,rbPlayer.velocity.z * 0.8f);
        yield return new WaitForSeconds(0.1f);
        rbPlayer.velocity = new Vector3(rbPlayer.velocity.x * 0.8f, rbPlayer.velocity.y, rbPlayer.velocity.z * 0.8f);
        yield return new WaitForSeconds(0.1f);
        rbPlayer.velocity = new Vector3(rbPlayer.velocity.x * 0.8f, rbPlayer.velocity.y, rbPlayer.velocity.z * 0.8f);
        /*
        yield return new WaitForSeconds(0.1f);
        rbPlayer.velocity = new;
        yield return new WaitForSeconds(0.1f);
        rbPlayer.velocity = new;
        yield return new WaitForSeconds(0.1f);
        rbPlayer.velocity = new;
        yield return new WaitForSeconds(0.1f);
        rbPlayer.velocity = new;
        */
    }

}
