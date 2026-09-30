Console.WriteLine("Please enter your firstname: ");
string firstName = Console.ReadLine();

Console.WriteLine("Please enter your last name: ");
string lastName = Console.ReadLine();

Console.WriteLine($"\nName on badge: {firstName} {lastName}.");

char firstInitial = firstName[0];
string formattedName = $"{firstInitial}{lastName}";
Console.WriteLine("Username:" + formattedName);

char lastInitial = lastName[0];
string formattedInitials = $"{firstInitial}.{lastInitial}.";
Console.WriteLine("Initials:" + formattedInitials);

int letterCount = lastName.Count(char.IsLetter);
Console.WriteLine($"Letters in last name:" + letterCount);

Random rand = new Random();
int studentID = rand.Next(100000,1000000);
int lockerNumber = rand.Next(1,501);
Console.WriteLine($"Student ID:" + studentID);
Console.WriteLine($"Locker:" + lockerNumber);

Console.Write("Dorm's x:");
Double Dormx = Convert.ToDouble(Console.ReadLine());
Console.Write("Dorm's y:");
Double DormY = Convert.ToDouble(Console.ReadLine());
Console.Write("Class's x:");
Double ClassX = Convert.ToDouble(Console.ReadLine());
Console.Write("Class's y:");
Double ClassY = Convert.ToDouble(Console.ReadLine());

Math.Sqrt(Dormx);

Math.Sqrt(ClassX);

Math.Sqrt(DormY);

Math.Sqrt(ClassX);











Console.ReadLine();

