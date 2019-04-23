using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnviromentTest
{
    public class AlunoAplicacao
    {
        private Contexto contexto;
        public void Insert(Aluno aluno)
        {
            var strQuery = "INSERT INTO Aluno (Nome)";
            strQuery += string.Format("VALUES('{0}')", aluno.Nome);
            using (contexto=new Contexto())
            {
                contexto.ExecutaComando(strQuery);
            }
        }
    }
}
