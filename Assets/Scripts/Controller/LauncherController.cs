using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LauncherController : MonoBehaviour
{
    public Collider ballCollider;
    public KeyCode input;
    public float maxForce;
    public float maxHoldTime;

    private bool isHold = false; //default value

    private void OnCollisionStay(Collision collision)
    {
        if (collision.collider == ballCollider)
        {
            ReadInput(collision);
        }
    }
    private void ReadInput(Collision collision)
    {
        if (Input.GetKey(input) && !isHold)
        {
            StartCoroutine(Hold(collision));
        }
    }

    private IEnumerator Hold(Collision bola)
    {
        float force = 0.0f;
        float holdTime = 0.0f;

        isHold = true;

        //menghitung force selama input ditekan
        while (Input.GetKey(input))
        {
            //menghitung force dengan perubahan konstan force terhadap perubahan waktu 
            force = Mathf.Lerp(0.0f, maxForce, holdTime / maxHoldTime); //(nilai awal, nilai maks, persentase terhadap force)

            yield return new WaitForEndOfFrame();
            holdTime += Time.deltaTime;
        }
        isHold = false;
        bola.gameObject.GetComponent<Rigidbody>().AddForce(transform.forward * force);
    }
}
