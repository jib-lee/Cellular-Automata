using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playerDrawing : MonoBehaviour
{
    public Camera cam;
    public lifeDrawer lifeDraw;
    public lifeManager lifeMana;

    void Start()
    {
        
    }

    void Update()
    {
        PlayerDrawLogic();

        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene("start");
        }

    }


    void PlayerDrawLogic()
    {
        if (!Input.GetMouseButton(0)) return;

        RaycastHit hit;
        if (!Physics.Raycast(cam.ScreenPointToRay(Input.mousePosition), out hit)) return;

        Vector2 cellpos = ConvertCoordtoWorldCell(hit.textureCoord);
        lifeMana.DrawLife((int)cellpos.x, (int)cellpos.y, lifeMana.celltype);

        //Debug.Log(hit.textureCoord.ToString());
    }

    public void golButton()
    {
        lifeMana.celltype = lifeManager.Cell.Type.GOL;
    }
    public void sandButton()
    {
        lifeMana.celltype = lifeManager.Cell.Type.sand;
    }
    public void antButton()
    {
        lifeMana.celltype = lifeManager.Cell.Type.ant_hill;
    }

    Vector2 ConvertCoordtoWorldCell(Vector2 coord)
    {
        Vector2 toreturn = Vector2.zero;
        toreturn.x = Mathf.FloorToInt(coord.x * lifeMana.width);
        toreturn.y = Mathf.FloorToInt(coord.y * lifeMana.height);


        return toreturn;
    }
}
