using ConsoleTables;
using Dapper;
using Npgsql;

internal class Program
{
	public static void Main(string[] args)
	{
		var connectionString =
			"Server=192.168.150.2;Port=5432;Database=university;User Id=postgres;Password=def555;Pooling=true;";

		List<Student> students = new List<Student>();
		
		using (var connection = new NpgsqlConnection(connectionString))
		{
			var query = @$"
SELECT * 
FROM students 
ORDER BY date_of_birth";

			var t = connection.Query<Student>(query);

			students = t.ToList();
		}

		var table = new ConsoleTable("id", "student_name", "study_group", "date_of_birth");

		foreach (var student in students)
		{
			table.AddRow(student.id, student.student_name, student.study_group, DateOnly.FromDateTime(student.date_of_birth));
		}

		table.Write(Format.Alternative);
		Console.WriteLine();
	}
	
	public class Student
	{
		public int id { get; set; }
		public string student_name { get; set; }
		public string study_group { get; set; }
		public DateTime date_of_birth { get; set; }
	}
}