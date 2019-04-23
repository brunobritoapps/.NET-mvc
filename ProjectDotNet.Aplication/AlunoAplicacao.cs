using System.Collections.Generic;
// INTERNAL DLL
using ProjectDotNet.Repository;
using ProjectDotNet.Domain;


namespace ProjectDotNet.Aplication
{
    public class AlunoAplicacao
    {
        private readonly AlunoRepositorioADO repositorio;

        public AlunoAplicacao()
        {
            repositorio = new AlunoRepositorioADO();
        }
      
        public void Delete(int id)
        {
            repositorio.Delete(id);
        }
        
        public void Save(Aluno aluno)
        {
            repositorio.Save(aluno);
        }

        public List<Aluno> SelectAll()
        {
            return repositorio.SelectAll();
        }

        public Aluno SelectById(int id)
        {
            return repositorio.SelectById(id);
        }

              
    }
}
