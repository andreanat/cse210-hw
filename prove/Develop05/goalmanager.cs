using System;
using System.Collections.Generic;

public class GoalManager
{
    private List<Goal> _goals = new List<Goal>();
    private int _score = 0;

    public GoalManager()
    {
        
    }

    public void Start()
    {
        Console.WriteLine("Goal Manager started.");

        while (true)
        {
            Console.WriteLine("Menu option:");
            Console.WriteLine("1. Display User's Score");
            Console.WriteLine("2. List Goals Details");
            Console.WriteLine("3. Create New Goal");
            Console.WriteLine("4. Record Event");
            Console.WriteLine("5. Save Goals to File");
            Console.WriteLine("6. Load Goals from File");
            Console.WriteLine("7. Exit");

            if (int.TryParse(Console.ReadLine(), out int option))
            {
                switch (option)
                {
                    case 1:
                        DisplayPlayerInfo();
                        break;
                    case 2:
                        ListGoalNames();
                        break;
                    case 3:
                        ListGoalDetails();
                        break;
                    case 4:
                        CreateGoal();
                        break;
                    case 5:
                        RecordEvent();
                        break;
                    case 6:
                        SaveGoals();
                        break;
                    case 7:
                        LoadGoals();
                        break;
                    case 8:
                        Console.WriteLine("Exiting...");
                        return;
                    default:
                        Console.WriteLine("Invalid option. Please choose a valid option.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a number.");
            }

            Console.WriteLine(); 
        }
    }

    public void DisplayPlayerInfo()
    {
        Console.WriteLine($"Player's Score: {_score} points");
    }

    public void ListGoalNames()
    {
        Console.WriteLine("List of Goal Names:");
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i}. {_goals[i]._shortName} - [{(_goals[i].IsComplete() ? 'X' : ' ')}]");
        }
    }

    public void ListGoalDetails()
    {
        Console.WriteLine("List of Goal Details:");
        foreach (var goal in _goals)
        {
            string completionStatus = goal.IsComplete() ? "Completed" : "Not Completed";
            string checklistStatus = "";

            if (goal is ChecklistGoal checklistGoal)
            {
                checklistStatus = $" - {completionStatus} {checklistGoal._amountCompleted}/{checklistGoal._target} times";
            }

            Console.WriteLine($"{goal.GetDetailsString()} - {completionStatus}{checklistStatus}");
        }
    }

    public void CreateGoal()
    {
        Console.WriteLine("Choose the type of goal to create:");
        Console.WriteLine("1. Simple Goal");
        Console.WriteLine("2. Eternal Goal");
        Console.WriteLine("3. Checklist Goal");

        if (int.TryParse(Console.ReadLine(), out int goalType))
        {
            switch (goalType)
            {
                case 1:
                    CreateSimpleGoal();
                    break;
                case 2:
                    CreateEternalGoal();
                    break;
                case 3:
                    CreateChecklistGoal();
                    break;
                default:
                    Console.WriteLine("Invalid option. Please choose a valid goal type.");
                    break;
            }
        }
        else
        {
            Console.WriteLine("Invalid input. Please enter a number.");
        }
    }

    public void CreateSimpleGoal()
    {
        Console.WriteLine("Enter the name of the simple goal:");
        string name = Console.ReadLine();
        Console.WriteLine("Enter the description of the simple goal:");
        string description = Console.ReadLine();
        Console.WriteLine("Enter the points for the simple goal:");
        if (int.TryParse(Console.ReadLine(), out int points))
        {
            _goals.Add(new SimpleGoal(name, description, points));
            Console.WriteLine($"Simple goal '{name}' created.");
        }
        else
        {
            Console.WriteLine("Invalid input. Please enter a valid number for points.");
        }
    }

    public void CreateEternalGoal()
    {
        Console.WriteLine("Enter the name of the eternal goal:");
        string name = Console.ReadLine();
        Console.WriteLine("Enter the description of the eternal goal:");
        string description = Console.ReadLine();
        Console.WriteLine("Enter the points for the eternal goal:");
        if (int.TryParse(Console.ReadLine(), out int points))
        {
            _goals.Add(new EternalGoal(name, description, points));
            Console.WriteLine($"Eternal goal '{name}' created.");
        }
        else
        {
            Console.WriteLine("Invalid input. Please enter a valid number for points.");
        }
    }

    public void CreateChecklistGoal()
    {
        Console.WriteLine("Enter the name of the checklist goal:");
        string name = Console.ReadLine();
        Console.WriteLine("Enter the description of the checklist goal:");
        string description = Console.ReadLine();
        Console.WriteLine("Enter the points for the checklist goal:");
        if (int.TryParse(Console.ReadLine(), out int points))
        {
            Console.WriteLine("Enter the target amount for the checklist goal:");
            if (int.TryParse(Console.ReadLine(), out int target))
            {
                Console.WriteLine("Enter the bonus points for achieving the checklist goal:");
                if (int.TryParse(Console.ReadLine(), out int bonus))
                {
                    _goals.Add(new ChecklistGoal(name, description, points, target, bonus));
                    Console.WriteLine($"Checklist goal '{name}' created.");
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a valid number for bonus points.");
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a valid number for the target amount.");
            }
        }
        else
        {
            Console.WriteLine("Invalid input. Please enter a valid number for points.");
        }
    }

    public void RecordEvent()
    {
        Console.WriteLine("Enter the number of the goal you completed:");
        ListGoalNames();
        if (int.TryParse(Console.ReadLine(), out int goalIndex) && goalIndex >= 0 && goalIndex < _goals.Count)
        {
            Goal completedGoal = _goals[goalIndex];
            completedGoal.RecordEvent();
            _score += completedGoal._points;
            Console.WriteLine($"Event recorded for {completedGoal._shortName}. You gained {completedGoal._points} points!");
        }
        else
        {
            Console.WriteLine("Invalid input. Please enter a valid goal number.");
        }
    }

    public void SaveGoals()
    {
        try
        {
            using (StreamWriter outputFile = new StreamWriter("goals.txt"))
            {
                foreach (var goal in _goals)
                {
                    outputFile.WriteLine(goal.GetStringRepresentation());
                }

                outputFile.WriteLine($"Score: {_score}");
            }

            Console.WriteLine("Goals saved to file.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error saving goals: {ex.Message}");
        }
    }

    public void LoadGoals()
    {
        _goals.Clear();

        try
        {
            string[] lines = System.IO.File.ReadAllLines("goals.txt");

            foreach (string line in lines)
            {
                if (line.StartsWith("Score:"))
                {
                    if (int.TryParse(line.Split(':')[1], out int loadedScore))
                    {
                        _score = loadedScore;
                        Console.WriteLine($"Score loaded: {_score}");
                    }
                }
                else
                {
                    
                }
            }

            Console.WriteLine("Goals loaded from file.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error loading goals: {ex.Message}");
        }
    }
}
