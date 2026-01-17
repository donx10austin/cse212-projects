using System;

public class Person
{
    public string Name { get; set; }
    public int Turns { get; set; }

    /// <summary>
    /// Initializes a new person with a name and number of turns.
    /// </summary>
    /// <param name="name">The name of the person</param>
    /// <param name="turns">Number of turns. 0 or negative indicates infinite turns.</param>
    public Person(string name, int turns)
    {
        Name = name;
        Turns = turns;
    }

    // DO NOT MODIFY THE CODE IN THIS METHOD
    // Graders use this to check the internal state of your queue.
    public override string ToString()
    {
        return $"{Name} (Turns:{Turns})";
    }
}