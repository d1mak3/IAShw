using System;

namespace ProgToTranslate
{
	[Serializable]
	class Task
	{
		public int Id { get; set; }
		public string Title { get; set; }
		public string Description { get; set; }
		public DateTime CreationDate { get; set; }
		public DateTime ExpirationDate { get; set; }
		public string Status { get; set; } // In process, done, deleted
		public int ProjectId { get; set; } // Saving id of project, because it won't be displayed
		public string RequesterLogin { get; set; } // Saving login of requester, because it will be displayed
		public string CarryLogin { get; set; }

		public override string ToString()
		{
			string convertedTask = String.Empty;

			if (Description == String.Empty)
			{
				if (ExpirationDate == DateTime.MinValue)
				{
					if (CarryLogin == String.Empty)
					{
						convertedTask = $"Название: {Title}\n" +
										$"Дата создания: {CreationDate.ToLocalTime()}\n" +
										$"Статус: {Status}\n" +
										$"Создатель: {RequesterLogin}";
					}
					else
					{
						convertedTask = $"Название: {Title}\n" +
										$"Дата создания: {CreationDate.ToLocalTime()}\n" +
										$"Статус: {Status}\n" +
										$"Создатель: {RequesterLogin}\n" +
										$"Должен выполнить: {CarryLogin}\n";
					}
				}
				else
				{
					if (CarryLogin == String.Empty)
					{
						convertedTask = $"Название: {Title}\n" +
										$"Дата создания: {CreationDate.ToLocalTime()}\n" +
										$"Сделать до: {ExpirationDate.ToLocalTime()}\n" +
										$"Статус: {Status}\n" +
										$"Создатель: {RequesterLogin}";
					}
					else
					{
						convertedTask = $"Название: {Title}\n" +
										$"Дата создания: {CreationDate.ToLocalTime()}\n" +
										$"Сделать до: {ExpirationDate.ToLocalTime()}\n" +
										$"Статус: {Status}\n" +
										$"Создатель: {RequesterLogin}\n" +
										$"Должен выполнить: {CarryLogin}";
					}
				}
			}
			else
			{
				if (ExpirationDate == DateTime.MinValue)
				{
					if (CarryLogin == String.Empty)
					{
						convertedTask = $"Название: {Title}\n" +
										$"Описание: {Description}\n" +
										$"Дата создания: {CreationDate.ToLocalTime()}\n" +
										$"Статус: {Status}\n" +
										$"Создатель: {RequesterLogin}";
					}
					else
					{
						convertedTask = $"Название: {Title}\n" +
										$"Описание: {Description}\n" +
										$"Дата создания: {CreationDate.ToLocalTime()}\n" +
										$"Статус: {Status}\n" +
										$"Создатель: {RequesterLogin}\n" +
										$"Должен выполнить: {CarryLogin}";
					}
				}
				else
				{
					if (CarryLogin == String.Empty)
					{
						convertedTask = $"Название: {Title}\n" +
										$"Описание: {Description}\n" +
										$"Дата создания: {CreationDate.ToLocalTime()}\n" +
										$"Сделать до: {ExpirationDate.ToLocalTime()}\n" +
										$"Статус: {Status}\n" +
										$"Создатель: {RequesterLogin}";
					}
					else
					{
						convertedTask = $"Название: {Title}\n" +
										$"Описание: {Description}\n" +
										$"Дата создания: {CreationDate.ToLocalTime()}\n" +
										$"Сделать до: {ExpirationDate.ToLocalTime()}\n" +
										$"Статус: {Status}\n" +
										$"Создатель: {RequesterLogin}\n" +
										$"Должен выполнить: {CarryLogin}";
					}
				}
			}

			return convertedTask;
		}
	}
}
