using UnityEngine;
public class KeyDefensa
{
    public string[] buttons;

	public KeyCode[] keys;
    private int currentIndex = 0; //moves along the array as buttons are pressed
 
    public float allowedTimeBetweenButtons = 0.8f; //tweak as needed
    private float timeLastButtonPressed;

 //propiedades de ataque

    public int defensa;
 
	 public KeyDefensa(KeyCode[] b, int defensa)
    {
        keys = b;
        this.defensa = defensa;
    }
 
 

	    public bool CheckKey()
    {
        if (Time.time > timeLastButtonPressed + allowedTimeBetweenButtons) currentIndex = 0;
        {
            if (currentIndex < keys.Length)
            {
                if (Input.GetKeyDown(keys[currentIndex]) && keys[currentIndex] == KeyCode.I ||
                Input.GetKeyDown(keys[currentIndex]) && keys[currentIndex] == KeyCode.A  ||
                Input.GetKeyDown(keys[currentIndex]) && keys[currentIndex] == KeyCode.B  ||
				Input.GetKeyDown(keys[currentIndex]) && keys[currentIndex] == KeyCode.C ||
				Input.GetKeyDown(keys[currentIndex]) && keys[currentIndex] == KeyCode.D ||
				Input.GetKeyDown(keys[currentIndex]) && keys[currentIndex] == KeyCode.E ||
                Input.GetKeyDown(keys[currentIndex]) && keys[currentIndex] == KeyCode.F ||
                Input.GetKeyDown(keys[currentIndex]) && keys[currentIndex] == KeyCode.G ||
                Input.GetKeyDown(keys[currentIndex]) && keys[currentIndex] == KeyCode.H ||
                Input.GetKeyDown(keys[currentIndex]) && keys[currentIndex] == KeyCode.I ||
                Input.GetKeyDown(keys[currentIndex]) && keys[currentIndex] == KeyCode.J ||
                Input.GetKeyDown(keys[currentIndex]) && keys[currentIndex] == KeyCode.K||
                Input.GetKeyDown(keys[currentIndex]) && keys[currentIndex] == KeyCode.L ||
                Input.GetKeyDown(keys[currentIndex]) && keys[currentIndex] == KeyCode.M ||
                Input.GetKeyDown(keys[currentIndex]) && keys[currentIndex] == KeyCode.N ||
                Input.GetKeyDown(keys[currentIndex]) && keys[currentIndex] == KeyCode.O ||
                Input.GetKeyDown(keys[currentIndex]) && keys[currentIndex] == KeyCode.P||
                Input.GetKeyDown(keys[currentIndex]) && keys[currentIndex] == KeyCode.Q||
                Input.GetKeyDown(keys[currentIndex]) && keys[currentIndex] == KeyCode.R ||
                Input.GetKeyDown(keys[currentIndex]) && keys[currentIndex] == KeyCode.S ||
                Input.GetKeyDown(keys[currentIndex]) && keys[currentIndex] == KeyCode.T ||
                Input.GetKeyDown(keys[currentIndex]) && keys[currentIndex] == KeyCode.W ||
                Input.GetKeyDown(keys[currentIndex]) && keys[currentIndex] == KeyCode.V ||
                Input.GetKeyDown(keys[currentIndex]) && keys[currentIndex] == KeyCode.U ||
                Input.GetKeyDown(keys[currentIndex]) && keys[currentIndex] == KeyCode.X ||
                Input.GetKeyDown(keys[currentIndex]) && keys[currentIndex] == KeyCode.Y ||
                Input.GetKeyDown(keys[currentIndex]) && keys[currentIndex] == KeyCode.Z  )

				//(keys[currentIndex] != KeyCode.I && keys[currentIndex] != KeyCode.O && keys[currentIndex] != KeyCode.J))


                {
                    timeLastButtonPressed = Time.time;
                    currentIndex++;
                }
 
                if (currentIndex >= keys.Length)
                {
                    currentIndex = 0;
                    return true;
                }
                else return false;
            }
        }
 
        return false;
    }
}