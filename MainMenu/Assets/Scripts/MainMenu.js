#pragma strict

function QuitGame(){
    Debug.Log("Game is Quiting");
    Application.Quit();
}

function StartGame(){
    Application.LoadLevel("level1");
}