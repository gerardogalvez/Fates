using UnityEngine;
using System.Collections;

//Este Script Pertenece a la Camara

public class RayCasting : MonoBehaviour {

    #region Declarations

    //Tiles Guardadas en Buffer, SON GAMEOBJECTS DE TIPO TILE!
    private GameObject gbjStoredHighlighted;
    private GameObject gbjStoredClicked;

    //Sprites de las Tiles
    public Material mtrlGrass;
    public Material mtrlClickedGrass;

    //Unidades Guardadas/Selecionadas
    public GameObject gbjSelectedUnit;

    #endregion

    void Update()
    {

        //Generate a raycast from the camera aiming at the mouse
        Ray CameraRay = Camera.main.ScreenPointToRay(Input.mousePosition);

        //Raycast hit information is stored here
        RaycastHit hitInfo;

        //If the raycast hitted something
        if (Physics.Raycast(CameraRay, out hitInfo))
        {
            //Store the GameObject that was hitted
            GameObject gbjHitted = hitInfo.collider.transform.gameObject;

            /////// HIGHLIGHTING SEGMENT START/////////////

            #region Highlighting_Tiles

            //Ask if object is a tile, and its the first tile to get hit 
            if (gbjHitted.tag == "Tile" && gbjStoredHighlighted == null)
            {
                //Highlight the tile
                Component halo = gbjHitted.GetComponent("Halo");
                halo.GetType().GetProperty("enabled").SetValue(halo, true, null);

                //Store the tile
                gbjStoredHighlighted = gbjHitted;

            } //Ask if the object is a tile, but it wasn't the first to get hit 
            else if (gbjHitted.tag == "Tile" && gbjStoredHighlighted != null)
            {
                //Unhighlight previous tile
                Component halo = gbjStoredHighlighted.GetComponent("Halo");
                halo.GetType().GetProperty("enabled").SetValue(halo, false, null);

                //Highlight the Hitted Tile
                Component halo2 = gbjHitted.GetComponent("Halo");
                halo2.GetType().GetProperty("enabled").SetValue(halo2, true, null);

                //Make the Hitted Tile now the stored Tile
                gbjStoredHighlighted = gbjHitted;
            }
            #endregion

            /////// HIGHLIGHTING END/////////////

            /////// CLICKING TILES SEGMENT START/////////////

            #region Clicking_Tiles

            //If the User Clicks on the raycasted Object
            if (Input.GetMouseButtonDown(0))
            {
                //Ask if that Object is a tile and its the first tile to get clicked and there is no unit selected
                if (gbjHitted.tag == "Tile" && gbjStoredClicked == null && gbjSelectedUnit == null)
                {
                    gbjHitted.GetComponent<Renderer>().material = mtrlClickedGrass;

                    //Store Clicked Tile
                    gbjStoredClicked = gbjHitted;

                    //Display info in the Debug log
                    DisplaySelectedTile(gbjHitted.transform.parent.gameObject);

                }
                //Ask if the object is a tile, but its not the same tile as before and there is no unit selected
                else if (gbjHitted.tag == "Tile" && gbjStoredClicked != gbjHitted && gbjSelectedUnit == null)
                {
                    //Make Previous Clicked Tile unclicked again
                    gbjStoredClicked.GetComponent<Renderer>().material = mtrlGrass;

                    //Make clicked tile 'Clicked'
                    gbjHitted.GetComponent<Renderer>().material = mtrlClickedGrass;

                    //Make the Clicked Tile now the stored Tile
                    gbjStoredClicked = gbjHitted;

                    //Display info in the Debug log
                    DisplaySelectedTile(gbjHitted.transform.parent.gameObject);

                } //Ask if the object is a tile, and its the same tile as the one previously clicked and there is no unit selected
                else if (gbjHitted.tag == "Tile" && gbjStoredClicked == gbjHitted && gbjSelectedUnit == null)
                {
                    //Unselect the tile
                    gbjHitted.GetComponent<Renderer>().material = mtrlGrass;

                    //Remove that tile from the Selected tile storage
                    gbjStoredClicked = null;

                    //Display info in the Debug log
                    DisplaySelectedTile(null);
                }
                #endregion
                /////// CLICKING TILES END/////////////

                ///////Clicking Friendly Units/////////
                #region Clicking_Friendly

                //Si seleccionamos una unidad y no teniamos unidad anteriormente seleccionada y No tenemos una tile Seleccionada
                if (gbjHitted.tag == "Friendly" && gbjSelectedUnit == null && gbjStoredClicked == null)
                {
                    gbjSelectedUnit = gbjHitted;
                    DisplaySelectedUnit(gbjSelectedUnit);
                }
                //Si seleccionamos una unidad y es diferente a la unidad previamente seleccionada y No tenemos una tile Seleccionada
                else if (gbjHitted.tag == "Friendly" && gbjSelectedUnit != gbjHitted && gbjStoredClicked == null) 
                {
                    gbjSelectedUnit = gbjHitted;
                    DisplaySelectedUnit(gbjSelectedUnit);
                }
                //Si seleccionamos la misma unidad, deseleccionala y No tenemos una tile Seleccionada
                else if (gbjHitted.tag == "Friendly" && gbjSelectedUnit == gbjHitted && gbjStoredClicked == null)
                {
                    gbjSelectedUnit = null;
                    DisplaySelectedUnit(null);
                }

                #endregion
                ///////Clicking Friendly END///////////
            }

        }
    }



    //FUNCTIONS///

    /*////////////////////////////////////////////////////////////////////
    // DisplaySelectedTile
    //
    //  Funcion que recibe un Objeto tile y despliega en la consola
    //  
    //
    //  Parametros:
    //
    //  GameObject    gbjObj     Objecto a desplegar   
    //
    //  Reegresa:
    //
    //  Nada, La funcion es void
    //
    /////////////////////////////////////////////////////////////////////*/
    public static void DisplaySelectedTile (GameObject gbjObj)
    {
        if(gbjObj != null)
        {
            Debug.Log("Currently Selected Tile: " + gbjObj.name);
        }
        else
        {
            Debug.Log("Currently Selected Tile: None");
        }
    }

    public static void DisplaySelectedUnit (GameObject gbjObj)
    {
        if(gbjObj == null)
        {
            Debug.Log("Currently Selected Unit: None");
        }
        else
        {
            Debug.Log("Currently Selected Unit " + gbjObj.name);
        }
    }


}
