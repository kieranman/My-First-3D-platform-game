using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour
{

    bool dead = false;

    private void Update()
    {
        if (transform.position.y < -3f && !dead) {
            Die();
        }
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy Body")) {
            Die();
        }
    }
    void Die() {
        // removes the mesh of the player model
        // basically just allows player to disappear once death occurs
        GetComponent<MeshRenderer>().enabled = false;
        //Stops player from being pushed around by other objects once death occurs
        GetComponent<Rigidbody>().isKinematic = true;
        // Stops player movement
        GetComponent<PlayerMovement>().enabled = false;
        dead = true;
        Invoke(nameof(ReloadLevel),1.3f);

    }

    void ReloadLevel() {
        // get currently active scene and get the name
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}
