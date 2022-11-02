using EM.Domain;
using FirebirdSql.Data.FirebirdClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;

namespace EM.Repository
{
    public class RepositorioAluno : RepositorioAbstrato<Aluno>
    {
        private readonly string strConn = @"DataSource=localhost; Database=C:\Users\Escolar Manager\Desktop\Banco\BANCOVAZIO.fdb; port = 3050;username= SYSDBA; password = masterkey";
        FbConnection conn;
        public override void Add(Aluno aluno)
        {
            using (conn = new FbConnection(strConn))
            {
                string sqlIncluir = @"INSERT INTO ALUNO (MATRICULA, NOME, SEXO, NASCIMENTO, CPF)
                                    VALUES(@matricula, @nome, @sexo, @nascimento, @cpf);";

                var fbCmd = conn.CreateCommand();
                fbCmd.CommandText = sqlIncluir;                
                fbCmd.Parameters.AddWithValue("@nome", aluno.Nome);
                fbCmd.Parameters.AddWithValue("@matricula", aluno.Matricula);
                fbCmd.Parameters.AddWithValue("@sexo", (int)aluno.Sexo);
                fbCmd.Parameters.AddWithValue("@nascimento", aluno.Nascimento);
                fbCmd.Parameters.AddWithValue("@cpf", aluno.CPF);
                conn.Open();
                fbCmd.ExecuteNonQuery();
            }
        }
        public override void Remove(Aluno aluno)
        {
            using (conn = new FbConnection(strConn))
            {
                string sqlExcluir = 
                    $@"DELETE FROM ALUNO 
                       WHERE MATRICULA = {aluno.Matricula}";
                FbCommand cmd = new FbCommand(sqlExcluir, conn);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }
        public override void Update(Aluno aluno)
        {
            using (conn = new FbConnection(strConn))
            {
                if (aluno != null)
                {
                    string sqlUpdate =
                            $@"UPDATE ALUNO SET NOME= @nome, NASCIMENTO= @nascimento, 
                                SEXO= @sexo, CPF= @cpf 
                                WHERE MATRICULA ={aluno.Matricula};";
                    var fbCmd = conn.CreateCommand();
                    fbCmd.CommandText = sqlUpdate;
                    fbCmd.Parameters.AddWithValue("@nome", aluno.Nome);
                    fbCmd.Parameters.AddWithValue("@nascimento", aluno.Nascimento);
                    fbCmd.Parameters.AddWithValue("@sexo", (int)aluno.Sexo);
                    fbCmd.Parameters.AddWithValue("@cpf", aluno.CPF);
                    conn.Open();
                    fbCmd.ExecuteNonQuery();
                }
            }
        }
        public override IEnumerable<Aluno> Get(Expression<Func<Aluno, bool>> predicate)
        {
            return GetAll().Where(predicate.Compile());
        }
        public Aluno GetByMatricula(int matricula)
        {
            return Get(x => x.Matricula == matricula).FirstOrDefault();
        }
        public IEnumerable<Aluno> GetByContendoNoNome(string parteDoNome)
        {
            return Get(x => x.Nome.ToLowerInvariant().Contains(parteDoNome.ToLowerInvariant())).ToList();
        }
        public override IEnumerable<Aluno> GetAll()
        {
            List<Aluno> alunos = new List<Aluno>();
            conn = new FbConnection(strConn);
            string sqlReaderCommand = "SELECT * FROM ALUNO";
            FbCommand cmd = new FbCommand(sqlReaderCommand, conn);
            conn.Open();
            FbDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Aluno aluno = new Aluno()
                {
                    Nome = reader.GetString(1),
                    CPF = reader.GetString(4),
                    Matricula = Convert.ToInt32(reader.GetString(0)),
                    Nascimento = Convert.ToDateTime(reader.GetString(3)),
                    Sexo = (EnumeradorSexo)Convert.ToInt32(reader.GetString(2))
                };
                alunos.Add(aluno);
            }
            reader.Close();
            conn.Close();
            return alunos.OrderBy(a=> a.Matricula);
        }
    }
}
