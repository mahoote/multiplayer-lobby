[System.Serializable]
public class Question
{
    //these variables are case sensitive and must match the strings "firstName" and "lastName" in the JSON.
    public int id;
    public string name;
    public string[] answers;
    public int correct_answer;

}
