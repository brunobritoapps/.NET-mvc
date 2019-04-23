using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
// INTERNAL DLL
using ProjectDotNet.Domain;


namespace ProjectDotNet.Repository
{
    public class AlunoRepositorioADO
    {
        private Contexto contexto;
      
        private void Insert(Aluno aluno)
        {
            var strQuery = "";
            strQuery += "INSERT INTO Aluno (Nome,Mae,DataNascimento)";
            strQuery += string.Format("VALUES('{0}','{1}','{2}')",aluno.Nome, aluno.Mae, aluno.DataNascimento);
            using(contexto = new Contexto())
            {
                contexto.ExecutaComando(strQuery);
            }
        }

        private void Update(Aluno aluno)
        {
            var strQuery = "";
            strQuery += "UPDATE Aluno SET ";
            strQuery += string.Format("Nome='{0}',", aluno.Nome);
            strQuery += string.Format("Mae='{0}',", aluno.Mae);
            strQuery += string.Format("DataNAscimento='{0}'", aluno.DataNascimento);
            strQuery += string.Format("WHERE AlunoId='{0}'", aluno.Id);
            using (contexto = new Contexto())
            {
                contexto.ExecutaComando(strQuery);
            }
        }

        public void Delete(int id)
        {
            var strQuery = "";
            strQuery += string.Format("DELETE FROM Aluno WHERE AlunoId='{0}'",id);
            using(contexto=new Contexto())
            {
                contexto.ExecutaComando(strQuery);
            }
        }
        
        public void Save(Aluno aluno)
        {
            if (aluno.Id>0)
              Update(aluno);
            else
             Insert(aluno);
        }

        public List<Aluno> SelectAll()
        {
            using (contexto = new Contexto())
            {
                var strQuery = "SELECT * FROM Aluno";
                var retornaDataReader = contexto.ExecutaComandoComRetorno(strQuery);
                return TransformaReaderEmListaDeObjeto(retornaDataReader);
            }
        }

        public Aluno SelectById(int id)
        {
            using (contexto = new Contexto())
            {
                var strQuery =string.Format("SELECT * FROM Aluno WHERE AlunoId={0}",id);
                var retornaDataReader = contexto.ExecutaComandoComRetorno(strQuery);
                return TransformaReaderEmListaDeObjeto(retornaDataReader).FirstOrDefault();
            }
        }

        private List<Aluno> TransformaReaderEmListaDeObjeto(SqlDataReader reader)
        {
            var alunos = new List<Aluno>();
            while (reader.Read())
            {
                var tempObjeto = new Aluno()
                {
                    Id = int.Parse(reader["AlunoId"].ToString()),
                    Nome = reader["Nome"].ToString(),
                    Mae = reader["Mae"].ToString(),
                    DataNascimento = DateTime.Parse(reader["DataNascimento"].ToString())
                };
                alunos.Add(tempObjeto);
            }
            reader.Close();
            return alunos;
        }
       
    }
}
