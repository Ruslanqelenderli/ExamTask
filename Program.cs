

using LoginRegisterSystem.Entity;
using LoginRegisterSystem.Enum;
using LoginRegisterSystem.Manage.Abstract;
using LoginRegisterSystem.Manage.Concrete;

IUserService userService = new UserService();

bool programTime = true;

while (programTime)
{
    Console.WriteLine("Login olmaq üçün 1 \n Register olmaq üçün 2 düyməsinə basın");

    var userResult = int.Parse(Console.ReadLine());

    if(userResult == 1)
    {
        Console.Write("Email daxil edin:");
        var email=Console.ReadLine();

        Console.Write("Password daxil edin:");
        var password = Console.ReadLine();

        var loginResult = userService.Login(email, password);
        Console.WriteLine(loginResult.ErrorMessage);

    }
    else if(userResult == 2)
    {
        User user = new User();
        Console.Write("Name daxil edin:");
        user.Name = Console.ReadLine();

        Console.Write("Surname daxil edin:");
        user.Surname = Console.ReadLine();

        Console.Write("Email daxil edin:");
        user.Email = Console.ReadLine();

        Console.Write("Password daxil edin:");
        user.Password = Console.ReadLine();
        var registerResult = userService.Register(user);    

        Console.WriteLine(registerResult.ErrorMessage); 



    }

    Console.WriteLine("Geri 1 düyməsilə qayıt");
    var returnResult = int.Parse(Console.ReadLine());

    if (returnResult != 1) programTime = false;


}
