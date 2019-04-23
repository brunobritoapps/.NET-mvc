using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace EnviromentTest
{
    class Program 
    {
        static void Main(string[] args)
        {
            var conn = new SqlConnection();
            conn.ConnectionString = @"data source='DESKTOP-ERL7S97\SQLEXPRESS';Integrated Security='SSPI';Initial Catalog='dotNetDemo01'";
            conn.Open();

            //string strQueryInsert = "INSERT INTO Aluno (Nome,Mae,DataNascimento) VALUES ('Erinaldo','Eduarda','10/10/2000')";
            //var cmdInsert = new SqlCommand(strQueryInsert, conn);
            //cmdInsert.ExecuteNonQuery();

            Aluno aluno1 = new Aluno();
            aluno1.Nome = "Josefaldo";
            AlunoAplicacao app = new AlunoAplicacao();
            app.Insert(aluno1);
            
            string strQuerySelect = "SELECT * FROM Aluno";
            var cmdSelect = new SqlCommand(strQuerySelect, conn);
            var dados = cmdSelect.ExecuteReader();

            while (dados.Read())
            {
                Console.WriteLine(string.Format("Nome:{0} - Mae:{1} - DataNascimento:{2}", dados["Nome"], dados["Mae"],dados["DataNascimento"].ToString()));
            }

            
        }

    }
}
