using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace ProgToTranslate
{
	static class Menu
	{
		private static List<Project> projects = new();
		private static List<Task> tasks = new();
		private static List<User> users = new();
	
		private static bool CreateProject(Project newProject)
		{
			// Check if there already is project with the same title
			if (
				(from project in projects
				 where project.Title == newProject.Title
				 select project).Any()
				)
			{
				Console.WriteLine("Проект с таким названием уже создан!");
				return false;
			}

			if (newProject.Title == String.Empty || newProject.AccessToken == String.Empty)
			{
				Console.WriteLine("Вы обязательно должны указать название и ключ доступа проекта!");
				return false;
			}

			projects.Add(newProject);
			return true;
		}

		private static bool CheckAuthorizationInProjectData(string projectTitle, string projectToken)
		{
			return (from project in projects
					where project.Title == projectTitle
					&& project.AccessToken == projectToken
					select project).Any();
		}

		private static bool RegisterUserInProject(int idOfUserToAuthorize, string projectTitle, string projectToken)
		{
			// Check if there is project with title and token from parameters
			IEnumerable<Project> projectsToRegisterUserIn =  // Actually there is only one (or zero) project with the same title, but it's more readable, if IEnumerable named in plural 
				from project in projects
				where project.Title == projectTitle
				&& project.AccessToken == projectToken
				select project;

			if (!projectsToRegisterUserIn.Any())
			{
				return false;
			}
			else
			{
				projects[projectsToRegisterUserIn.First().Id].UsersInProject.Add(users[idOfUserToAuthorize]);
				return true;
			}
		}

		private static bool RegisterNewUser(User newUser)
		{
			// Check if there already is user with the same nickname 
			if (
				(from user in users
				where user.Login == newUser.Login
				select user).Any()
			   )			
				return false;

			users.Add(newUser);
			return true;
		}

		private static bool AuthorizeUser(User userToAuthorize)
		{
			// Check if there is user with the same nickname and password
			if (
				(from user in users
				 where user.Login == userToAuthorize.Login 
				 && user.Password == userToAuthorize.Password
				 select user).Any()
				)
				return true;

			return false;
		}

		private static bool CreateTask(Task newTask)
		{
			if (newTask.ProjectId == -1 || newTask.RequesterLogin == String.Empty
				|| newTask.Status == String.Empty || newTask.CreationDate == DateTime.MinValue)
				return false;

			tasks.Add(newTask);
			return true;
		}		

		// Get and check input 
		private static int AskMenu(string menu, int numberOfItems)
		{
			Console.WriteLine(menu);
			string userInput = Console.ReadLine();			

			if (!Int32.TryParse(userInput, out int chosenItem))
			{
				Console.WriteLine("Вы должны ввести целое число!");
				return 0;
			}

			if (chosenItem < 1 || chosenItem > numberOfItems)
			{
				Console.WriteLine($"Вы должны ввести число от 1 до {numberOfItems}");
				return 0;
			}

			return chosenItem;
		}

		public static bool LoadDataFromFile(string filePath = "./dXt4")
		{
			try
			{
				JObject allDataInObject = new();

				using (var fileReader = new System.IO.StreamReader(filePath))
				{
					allDataInObject = JObject.Parse(fileReader.ReadToEnd());
				}

				projects = JsonConvert.DeserializeObject<List<Project>>(allDataInObject["projects"].ToString());
				tasks = JsonConvert.DeserializeObject<List<Task>>(allDataInObject["tasks"].ToString());
				users = JsonConvert.DeserializeObject<List<User>>(allDataInObject["users"].ToString());
				return true;
			}
			catch
			{
				return false;
			}
		}

		public static bool SaveDataInFile(string filePath = "./dXt4")
		{
			try
			{
				JObject allDataInObject = new JObject();
				allDataInObject["projects"] = JsonConvert.SerializeObject(projects);
				allDataInObject["tasks"] = JsonConvert.SerializeObject(tasks);
				allDataInObject["users"] = JsonConvert.SerializeObject(users);

				using (var fileWriter = new System.IO.StreamWriter(filePath))
				{
					fileWriter.WriteLine(allDataInObject.ToString());
				}

				return true;
			}
			catch
			{
				return false;
			}
		}


		// Main method, which will make our Taskmanager work!
		public static void Execute()
		{
			int userId = 0;
			int userChoice = 0;
			int projectId = -1;
			bool isUserAuthorized = false;			

			while (true)
			{				
				string menu = "";

				// Account authentication
				if (!isUserAuthorized)
				{
					menu =
					"Выберите пункт меню:\n" +
					"1. Авторизация;\n" +
					"2. Регистрация;\n" +
					"3. Выход из приложения.";

					userChoice = AskMenu(menu, 3);
					if (userChoice == 0) // If input is invalid
						continue;						
					
					switch (userChoice)
					{
						case 1: // Authorization choice
							Console.Write("Логин: ");
							string userLogin = Console.ReadLine();

							Console.Write("Пароль: ");
							string userPassword = Console.ReadLine();

							if (!AuthorizeUser(new User { Login = userLogin, Password = userPassword }))
							{
								Console.WriteLine("Неправильный логин или пароль!");
								continue;
							}
							else
							{
								isUserAuthorized = true;
								userId = (from u in users
										  where u.Login == userLogin
										  select u).First().Id;
								Console.WriteLine("Вы успешно авторизированы!");
							}
							break;

						case 2: // Registration choice
							Console.Write("Логин: ");
							userLogin = Console.ReadLine();

							Console.Write("Пароль: ");
							userPassword = Console.ReadLine();							

							if (!RegisterNewUser(new User { Id = users.Count, Login = userLogin, 
								Password = userPassword}))
							{
								Console.WriteLine("Пользователь с таким логином уже существует!");
								continue;
							}
							else
							{
								isUserAuthorized = true;
								userId = users.Count - 1;
								Console.WriteLine("Вы успешно зарегистрированы!");
							}
							break;

						case 3: // App exit
							Console.WriteLine("Выход из приложения...");
							return;

						default:
							Console.WriteLine("Вы должны ввести число, которое есть в меню!");
							break;
					}					
				}

				// Project authentication
				if (projectId == -1)
				{
					menu =
					"Выберите пункт меню:\n" +
					"1. Создание проекта;\n" +
					"2. Подключение к проекту;\n" +
					"3. Регистрация в проекте;\n" +
					"4. Выход из аккаунта;\n" +
					"5. Выход из приложения.";

					menuResult = AskMenu(menu, 5);
					if (menuResult == 0)  // If input is invalid
						continue;
					
					userChoice = Convert.ToInt32(menuResult); 						
					

					switch(userChoice)
					{
						case 1: // Project creation choice
							Project newProject = new Project() { Id = projects.Count };
							newProject.UsersInProject = new List<User>() { users[userId] };

							Console.WriteLine("Введите название проекта:");
							newProject.Title = Console.ReadLine();

							Console.WriteLine("Введите описание проекта:");
							newProject.Description = Console.ReadLine();

							Console.WriteLine("Введите ключ доступа проекта:");
							newProject.AccessToken = Console.ReadLine();

							if (!CreateProject(newProject))
							{								
								continue;
							}
							else
							{
								projectId = newProject.Id;
								Console.WriteLine("Проект успешно создан!");
							}	

							break;

						case 2: // Project connection choice
							Console.WriteLine("Введите название проекта:");
							string projectTitle = Console.ReadLine();

							Console.WriteLine("Введите ключ доступа проекта:");
							string projectToken = Console.ReadLine();

							if (!CheckAuthorizationInProjectData(projectTitle, projectToken))
							{
								Console.WriteLine("Неправильное название проекта или ключ доступа!");
								continue;
							}
							else
							{
								Console.WriteLine("Успешное подключение к проекту!");

								Project projectAuthorizedIn = (from project in projects
															   where project.Title == projectTitle
															   select project).First();
								
								projectId = projectAuthorizedIn.Id;
							}

							break;

						case 3: // Project authorization choice
							Console.WriteLine("Введите название проекта:");
							projectTitle = Console.ReadLine();

							Console.WriteLine("Введите ключ доступа проекта:");
							projectToken = Console.ReadLine();
							
							if (!RegisterUserInProject(userId, projectTitle, projectToken))
							{
								Console.WriteLine("Проект не найден!");
								continue;
							}
							
							Console.WriteLine("Регистрация успешно пройдена!");

							for (int i = 0; i < projects.Count; ++i)
								if (projects[i].Title == projectTitle)
									projectId = i;
							
							break;

						case 4: // Relog
							isUserAuthorized = false;
							projectId = -1;
							userId = 0;
							Console.WriteLine("Выход из аккаунта произведен успешно!");
							continue;

						case 5: // App exit
							Console.WriteLine("Выход из приложения...");
							return;

						default:
							Console.WriteLine("Вы должны ввести число, которое есть в меню!");
							break;
					}
				}
				
				// Tasks handling
				menu =
					"Выберите пункт меню:\n" +
					"1. Просмотр задач;\n" +
					"2. Создание задачи;\n" +
					"3. Изменение задачи;\n" +
					"4. Удаление задачи;\n" +
					"5. Выход из проекта;\n" +
					"6. Выход из аккаунта;\n" +
					"7. Выход из приложения.";

				userChoice = AskMenu(menu, 7);
				if (userChoice == 0) // If input is invalid
					continue;

				IEnumerable<Task> tasksFromProject = from task in tasks
													 where task.ProjectId == projectId
													 select task;

				switch (userChoice)
				{
					case 1: // Task view						
						if (!tasksFromProject.Any())
						{
							Console.WriteLine("В этом проекте нет задач!");
							break;
						}	

						for(int i = 0; i < tasksFromProject.Count(); ++i)
						{
							Console.WriteLine($"Id задачи: {i}\n" + tasksFromProject.ElementAt(i).ToString());
							Console.WriteLine();
						}

						break;

					case 2: // Task creation
						Task newTask = new Task();

						Console.WriteLine("Введите название задачи:");
						newTask.Title = Console.ReadLine();

						if (newTask.Title == String.Empty)
						{
							Console.WriteLine("Название задачи не может быть пустым!");
							continue;
						}

						Console.WriteLine("Введите описание задачи (необязательно):");
						newTask.Description = Console.ReadLine();

						Console.WriteLine("Введите конечный срок выполнения задачи (в формате '2015 7 20')(необязательно):");
												
						try
						{
							string[] splittedDate = Console.ReadLine().Split();
							newTask.ExpirationDate = new DateTime(Convert.ToInt32(splittedDate[0]),
							Convert.ToInt32(splittedDate[1]), Convert.ToInt32(splittedDate[2])).ToUniversalTime();							
						}
						catch
						{
							Console.WriteLine("Неправильный ввод даты!");
							continue;
						}

						Console.WriteLine("Введите логин того, кто должен выполнить задачу:");
						newTask.CarryLogin = Console.ReadLine();

						if (!projects[projectId].ContainsUser(newTask.CarryLogin) && newTask.CarryLogin != String.Empty)
						{
							Console.WriteLine("Пользователь с таким логином не зарегистрирован в проекте!");
							continue;
						}

						newTask.Id = tasks.Count;
						newTask.CreationDate = DateTime.UtcNow;
						newTask.Status = "In process";
						newTask.RequesterLogin = users[userId].Login;
						newTask.ProjectId = projectId;

						if (!CreateTask(newTask))
						{
							Console.WriteLine("Неправильные данные задачи!");
							continue;
						}
						else
						{
							Console.WriteLine("Задача успешно создана!");
						}

						break;
					case 3: // Task edition
						Console.WriteLine("Введите id задачи:");
						int taskToEditId = 0;

						if (!Int32.TryParse(Console.ReadLine(), out taskToEditId))
						{
							Console.WriteLine("Вы должны ввести целое число!");
							continue;
						}

						tasksFromProject = from task in tasks
										   where task.ProjectId == projectId
										   select task;

						if (taskToEditId < 0 || taskToEditId > tasksFromProject.Count() - 1)
						{
							Console.WriteLine("Такой задачи в проекте нет!");
							continue;
						}

						Console.WriteLine("Введите название изменяемого поля (Title/Description/ExpirationDate/Status/CarryLogin):");
						string field = Console.ReadLine().ToLower();

						if (!new List<string> { "title", "description", "expirationdate", "status", "carrylogin" }.Contains(field))
						{
							Console.WriteLine("Такого поля у задач нет!");
							continue;
						}

						Console.WriteLine("Введите новые данные:");
						string newData = Console.ReadLine();
						int taskToEditGlobalId = tasksFromProject.ElementAt(taskToEditId).Id;

						if (field == "title")
						{
							tasks[taskToEditGlobalId].Title = newData;
							Console.WriteLine("Поле успешно изменено!");
							continue;
						}

						if (field == "description")
						{
							tasks[taskToEditGlobalId].Description = newData;
							Console.WriteLine("Поле успешно изменено!");
							continue;
						}

						if (field == "expirationdate")
						{
							try
							{
								string[] splittedDate = newData.Split();
								tasks[taskToEditGlobalId].ExpirationDate = new DateTime(Convert.ToInt32(splittedDate[0]),
									Convert.ToInt32(splittedDate[1]), Convert.ToInt32(splittedDate[2])).ToUniversalTime();
							}
							catch
							{
								Console.WriteLine("Неправильный ввод даты!");
								continue;
							}
						}

						if (field == "status" && !new List<string> { "in process", "done" }.Contains(newData.ToLower()))
						{
							Console.WriteLine("Неизвестный статус!");
							continue;
						}

						if (field == "status")
						{
							tasks[taskToEditGlobalId].Status = newData;
							Console.WriteLine("Поле успешно изменено!");
							continue;
						}

						if (field == "carrylogin" && !projects[projectId].ContainsUser(newData))
						{
							Console.WriteLine("Пользователь с таким логином не зарегистрирован в проекте!");
							continue;
						}

						if (field == "carrylogin")
						{
							tasks[taskToEditGlobalId].CarryLogin = newData;
							Console.WriteLine("Поле успешно изменено!");
							continue;
						}

						break;
					case 4: // Task deletion
						Console.WriteLine("Введите id задачи:");
						int taskToDeleteId = 0;

						if (!Int32.TryParse(Console.ReadLine(), out taskToDeleteId))
						{
							Console.WriteLine("Вы должны ввести целое число!");
							continue;
						}

						tasksFromProject = from task in tasks
										   where task.ProjectId == projectId
										   select task;

						if (taskToDeleteId < 0 || taskToDeleteId > tasksFromProject.Count() - 1)
						{
							Console.WriteLine("Такой задачи в проекте нет!");
							continue;
						}

						tasks.Remove(tasks[taskToDeleteId]);

						for (int i = taskToDeleteId; i < tasks.Count; ++i)
							--tasks[i].Id;

						Console.WriteLine("Задача успешно удалена!");

						break;
					case 5: // Project exit
						projectId = -1;
						Console.WriteLine("Успешный выход из проекта!");

						break;
					case 6: // Relog
						userId = 0;
						Console.WriteLine("Успешный выход из пользователя!");

						break;
					case 7: // App exit
						Console.WriteLine("Выход из приложения...");

						return;
					default:
						Console.WriteLine("Вы должны выбрать пункт из меню!");

						break;
				}
			}			
		}
	}
}