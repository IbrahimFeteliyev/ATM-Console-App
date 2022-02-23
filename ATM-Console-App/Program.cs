using ATM_Consol_Final.Users;

User user1 = new()
{
    Id = 1,
    Name = "Gülzar",
    Password = 1111,
    Balance = 230.54
};
User user2 = new()
{
    Id = 2,
    Name = "Orxan",
    Password = 2222,
    Balance = 999999.99
};
User user3 = new()
{
    Id = 3,
    Name = "İbrahim",
    Password = 3333,
    Balance = 30.54
};
User user4 = new()
{
    Id = 4,
    Name = "Sanan",
    Password = 4444,
    Balance = 999999.99
};

List<User> users = new();
users.Add(user1);
users.Add(user2);
users.Add(user3);
users.Add(user4);


Evvele:

Console.WriteLine("1. Sisteme daxil olun");
Console.WriteLine("2. Exit");
string CardEnter = Console.ReadLine();


if (Convert.ToInt32(CardEnter) == 1)
{
    User currentuser = null;
    Console.Clear();
retype:
    Console.WriteLine("Adinizi daxil edin:");
    string name = Console.ReadLine();
    bool check = false;
    foreach (User item in users)
    {
        if (item.Name.ToLower() == name.ToLower())
        {
            check = true;
            currentuser = item;
        }
    }
    if (!check)
    {
        Console.WriteLine("Istifadeci adi movcud deyil!");
        goto retype;
    }
    Console.Clear();
repass:
    Console.WriteLine("Parolunuzu daxil edin:");
    int password;
    string input = Console.ReadLine();
    bool checkPass = int.TryParse(input, out password);
    if (input.Length != 4 || !checkPass)
    {
        Console.WriteLine("Duzgun daxil et!");
        goto repass;
    }
    Console.Clear();
    bool passwordValidated = false;
    if (password == currentuser.Password)
    {
        passwordValidated = true;
    }
    if (!passwordValidated)
    {
        Console.WriteLine("Parol sehvdir! Yeniden daxil et.");
        goto repass;
    }
    Console.WriteLine($"Xosgeldiniz, {currentuser.Name}!");
    Console.WriteLine($"Balansiniz: {currentuser.Balance}");
menu:
    Console.WriteLine();
    Console.WriteLine("Emeliyyatlar:");
    Console.WriteLine("1. Pul transfer et");
    Console.WriteLine("2. Hesabdan cix");
again:
    string numStr = Console.ReadLine();
    int num;
    bool checkMenuOperation = int.TryParse(numStr, out num);
    if (!checkMenuOperation)
    {
        Console.WriteLine("Duzgun daxil et!");
        goto again;
    }
    switch (num)
    {
        case 1:
            Transfer(currentuser, users);
            goto menu;
        case 2:
            Console.Clear();
            goto Evvele;
        default:
            break;
    }


}
else if (Convert.ToInt32(CardEnter) == 2)
{
    Console.WriteLine("Spasiba!");
}
else
{
    Console.WriteLine("Zehmet olmasa duzgun daxil edin!!!");

    Console.Clear();
    goto Evvele;
}


static void Transfer(User currentUser, List<User> users)
{
    User user = null;
    Console.WriteLine("Transfer etmek istediyiniz meblegi daxil edin:");
reamount:
    double amount;
    string input = Console.ReadLine();
    bool inputValidated = double.TryParse(input, out amount);
    if (!inputValidated)
    {
        Console.WriteLine("Duzgun daxil et!");
        goto reamount;
    }
    if (currentUser.Balance < amount)
    {
        Console.WriteLine("Balansinizda kifayet qeder vesait yoxdur! Yeniden daxil et!");
        goto reamount;
    }
    Console.WriteLine("Meblegi transfer etmek istediyiniz istifadecinin id-sini daxil edin:");
    Console.WriteLine("----------------------------------");
    foreach (User item in users)
    {
        if (currentUser != item)
        {
            Console.WriteLine(item);
            Console.WriteLine("--------------");
        }
    }
reid:
    string idInput = Console.ReadLine();
    int id;
    bool validateId = int.TryParse(idInput, out id);
    if (!validateId)
    {
        Console.WriteLine("Duzgun daxil et!");
        goto reid;
    }
    bool idExists = false;
    foreach (User item in users)
    {
        if (item.Id == id && item.Id != currentUser.Id)
        {
            idExists = true;
            user = item;
        }
    }
    if (!idExists)
    {
        Console.WriteLine("Bele user movcud deyil! Yeniden daxil et!");
        goto reid;
    }
    currentUser.Balance = Math.Round(currentUser.Balance - amount, 2);
    user.Balance = Math.Round(user.Balance + amount, 2);
    Console.WriteLine($"Transfer ugurla yerine yetirildi! Yeni balansiniz: {currentUser.Balance}");
}