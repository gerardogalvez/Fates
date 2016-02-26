using UnityEngine;
using System.Collections;

public class TileControl : MonoBehaviour {

    //ESTE SCRIPT ESTA DEPRECADO!! EL CONTROL DE ESTAS FUNCIONES AHORA SE ENCUENTRA EN EL SCRIPT RAYCAST.

 /*

  
   //Booleano para control de los clicks del mouse
    public bool bIsSelected = false;



    //Si el Mouse esta sobre la tile
    void OnMouseOver()
    {
        //Si la tile no esta selecionada
        if(!bIsSelected)
        {
            //Highligtea la tile 
            this.GetComponent<Renderer>().material.color = Color.red;
        }

    }

    //Si el mouse sale de la tile
    void OnMouseExit()
    {
        //Si la tile no esta selecionada
        if (!bIsSelected)
        {
            //DesHighligtea la tile 
            this.GetComponent<Renderer>().material.color = Color.white;
        }
    }

    void OnMouseDown()
    {
        //Si la tile no esta Seleccionada
        if (!bIsSelected)
        {
            //Seleccionala
            bIsSelected = true;

            //Si una ya estaba seleccionada antes de esta
            if(MacroPlayer.gbjStoredTile != null)
            {
                //Has la tile seleccionada pasada blanca
                MacroPlayer.gbjStoredTile.GetComponent<TileControl>().bIsSelected = false;
                MacroPlayer.gbjStoredTile.GetComponent<Renderer>().material.color = Color.white;
            }
       
            //Guarda esta tile como la tile seleccionada
            MacroPlayer.gbjStoredTile = this.gameObject;

            //Cambiale el color a azul
            this.GetComponent<Renderer>().material.color = Color.blue;
        }
        //Si la tile ya estaba seleccionada
        else
        {
            //Deseleccionala
            bIsSelected = false;

            //Guarda la tile seleccionada como ninguna, puesto a que no hay tile seleccionada
            MacroPlayer.gbjStoredTile = null;

            //Cambiale el color a blanco
            this.GetComponent<Renderer>().material.color = Color.white;
        }
        MacroPlayer.bCheckTileOnce = true;
    }


    */


}
