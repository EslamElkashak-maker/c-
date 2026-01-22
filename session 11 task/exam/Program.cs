namespace exam
{
    internal class Program
    {
        static void DoctorMode()
        {
            Console.Write("Enter number of questions: ");
            int count = Convert.ToInt32(Console.ReadLine());

            for (int i = 0; i < count; i++)
            {
                Console.WriteLine("Choose Question Type:");
                Console.WriteLine("1- True/False question");
                Console.WriteLine("2- Choose One question");
                Console.WriteLine("3- Multiple Choice question");

                int type = Convert.ToInt32(Console.ReadLine());

                Console.Write("Enter Level (Easy/Hard): ");
                string level = Console.ReadLine();

                Console.Write("Enter Degree: ");
                int degree = Convert.ToInt32(Console.ReadLine());

                if (type == 1)
                {
                    TrueFalseQuestion question = new TrueFalseQuestion();
                    Console.Write("Enter Question: ");
                    question.Text = Console.ReadLine();
                    Console.Write("Correct Answer (1-True, 2-False): ");
                    question.CorrectAnswer = Convert.ToInt32(Console.ReadLine()) == 1;
                    question.Level = level;
                    question.Degree = degree;

                    Exam.Questions.Add(question);
                }
                else if (type == 2)
                {
                    ChooseOneQuestion question = new ChooseOneQuestion();
                    Console.Write("Enter Question: ");
                    question.Text = Console.ReadLine();

                    question.Choices = new string[4];
                    for (int j = 0; j < 4; j++)
                    {
                        Console.Write($"Choice {j+1 }: ");
                        question.Choices[j] = Console.ReadLine();
                    }

                    Console.Write("Correct Choice Number: ");
                    question.CorrectIndex = Convert.ToInt32(Console.ReadLine()) - 1;

                    question.Level = level;
                    question.Degree = degree;

                    Exam.Questions.Add(question);
                }
                else if(type == 3)
                {
                    MultipleChoiceQuestion question = new MultipleChoiceQuestion();
                    Console.Write("Enter Question: ");
                    question.Text = Console.ReadLine();

                    question.Choices = new string[4];
                    for (int j = 0; j < 4; j++)
                    {
                        Console.Write($"Choice {j+1}: ");
                        question.Choices[j] = Console.ReadLine();
                    }

                    Console.Write("Correct answers (ex: 1 4): ");
                    string[] parts = Console.ReadLine().Split(' ');
                    question.CorrectIndexes = Array.ConvertAll(parts, x =>Convert.ToInt32(x) - 1);

                    question.Level = level;
                    question.Degree = degree;

                    Exam.Questions.Add(question);
                }
                else
                {     Console.WriteLine("Invalid Question Type!"); }
            }
        }

        static void StudentMode()
        {
            int totalScore = 0;
            foreach (var question in Exam.Questions)
            {
                bool correct = question.AskQuestion();
                if (correct)
                {
                    totalScore += question.Degree;
                    Console.WriteLine("Correct!");
                }
                else
                {
                    Console.WriteLine("Wrong!");
                }
            }
            Console.WriteLine($"Your Total Score: {totalScore}");
        }
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Choose Mode:");
                Console.WriteLine("1- Doctor");
                Console.WriteLine("2- Student");
                Console.WriteLine("3- Exit");

                int choice = int.Parse(Console.ReadLine());

                if (choice == 1)
                    DoctorMode();
                else if (choice == 2)
                    StudentMode();
                else
                    break;
            }
            
        }
    }
}
