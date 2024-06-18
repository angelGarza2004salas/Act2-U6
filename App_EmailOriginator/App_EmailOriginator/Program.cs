using System.Text;


namespace Program
{
	class Program
	{
		static void Main(string[] args)
		{


			string[,] user = new string[10, 3];
			int user_counter = 0;

			bool salir = false;

			while (!salir)
			{
				// Menú de opciones
				Console.WriteLine("1. Register new user");
				Console.WriteLine("2. Exit and save data");
				Console.Write("Select an option: ");
				string option = Console.ReadLine();

				switch (option)
				{
					case "1":
						Console.Write("Enter your name: ");
						string name = Console.ReadLine();

						Console.Write("Enter your last name: ");
						string last_name = Console.ReadLine();


						string email = $"{name.ToLower()}.{last_name.ToLower()}@gmail.com";

						string password = Generatepassword();

						Console.WriteLine($"Email generated:{email} and Password: {password}");
						user[user_counter, 0] = name;
						user[user_counter, 1] = email;
						user[user_counter, 2] = password;

						user_counter++;

						Console.WriteLine("User successfully registered.");
						break;

					case "2":
						
						Save_Data(user, user_counter);


						salir = true;
						break;

					default:
						Console.WriteLine("Invalid option. Please select again.");
						break;
				}
			}
		}

		static string Generatepassword()
		{
			const string charactersValid = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";

			StringBuilder password = new StringBuilder();
			Random rnd = new Random();
			for (int i = 0; i < 8; i++)
			{
				int index = rnd.Next(charactersValid.Length);
				password.Append(charactersValid[index]);
			}

			return password.ToString();
		}

		static void Save_Data(string[,] dates, int numberUsers)
		{
			string path = @"C:\Users\user.txt";
			using (StreamWriter writer = new StreamWriter(path))
			{
				for (int i = 0; i < numberUsers; i++)
				{
					writer.WriteLine($"Name: {dates[i, 0]}, Email: {dates[i, 1]}, Password: {dates[i, 2]}");
				}
			}

			Console.WriteLine($"Data of  {numberUsers} users stored in {path}");
		}


	}
}

