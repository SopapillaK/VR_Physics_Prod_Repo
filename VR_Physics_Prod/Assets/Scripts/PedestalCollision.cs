using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PedestalCollision : MonoBehaviour
{
    //private enum PillerColor
    //{
    //    Red, Orange
    //}

    //[SerializeField]
    //private PillerColor _color;
    public bool rightCube = false;
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<CubeColor>() != null && this.gameObject.GetComponent<CubeColor>() != null)
        {
            if (collision.gameObject.GetComponent<CubeColor>().GetColor == this.gameObject.GetComponent<CubeColor>().GetColor)
            {
                rightCube = true;
                GameManager.instance.CheckForWin();
            }
        }
    }
    public void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.GetComponent<CubeColor>() != null && this.gameObject.GetComponent<CubeColor>() != null)
        {
            if (collision.gameObject.GetComponent<CubeColor>().GetColor == this.gameObject.GetComponent<CubeColor>().GetColor)
            {
                rightCube = true;
            }
        }
        //switch (_color)
        //{
        //    case PillerColor.Red:
        //        if (collision.gameObject.GetComponent<CubeColor>() != null)
        //        {
        //            if (collision.gameObject.GetComponent<CubeColor>().GetColor == CubeColor.Color.Red)
        //            {
        //                Debug.Log(collision.gameObject.name);
        //                Debug.Log(this.gameObject.name);
        //            }
        //            else
        //            {
        //                Debug.Log("Wrong Cube!");
        //            }
        //        }

        //        break;
        //        case PillerColor.Orange:
        //        if (collision.gameObject.GetComponent<CubeColor>() != null)
        //        {
        //            if (collision.gameObject.GetComponent<CubeColor>().GetColor == CubeColor.Color.Orange)
        //            {
        //                Debug.Log(collision.gameObject.name);
        //                Debug.Log(this.gameObject.name);
        //            }
        //            else
        //            {
        //                Debug.Log("Wrong Cube!");
        //            }
        //        }
        //        break;
        //}

        //if (_color == PillerColor.Red)
        //{
        //    if (collision.gameObject.GetComponent<CubeColor>() != null)
        //    {
        //        if(collision.gameObject.GetComponent <CubeColor>().GetColor == CubeColor.Color.Red)
        //        {

        //        }
        //    }
        //}



        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.GetComponent<CubeColor>() != null && this.gameObject.GetComponent<CubeColor>() != null)
        {
            if (collision.gameObject.GetComponent<CubeColor>().GetColor == this.gameObject.GetComponent<CubeColor>().GetColor)
            {
                rightCube = false;
            }
        }
    }
}
