using System.IO;

namespace rockmvc.Models
{

    public class Usuario
    {
        public void CreateFolderAndFile(string _path)
        {

            string folder = _path.Split("/")[0];

            if (!Directory.Exists(folder))
            {
                Directory.CreateDirectory(folder);
            }

            if (!File.Exists(_path))
            {
                File.Create(_path).Close();
            }
        }
        private const string PATH = "Database/Usuario.csv";

        /// <param name="u">Usuario</param>
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }

        public Usuario()
        {
            CreateFolderAndFile(PATH);
        }

        public void Create(Usuario u)
        {
            string[] linha = { PrepararLinha(u) };
            File.AppendAllLines(PATH, linha);
        }

        private string PrepararLinha(Usuario u)
        {
            return $"{u.Nome};{u.Email};{u.Senha};";
        }
        public void Delete(string Nome)
        {
            List<string> linhas = ReadAllLinesCSV(PATH);
            // 1;FLA;fla.png
            linhas.RemoveAll(x => x.Split(";")[0] == Nome.ToString());
            RewriteCSV(PATH, linhas);
        }

        public List<Usuario> ReadAll()
        {
            List<Usuario> usuario = new List<Usuario>();
            string[] linhas = File.ReadAllLines(PATH);

            foreach (var item in linhas)
            {
                string[] linha = item.Split(";");

                Usuario jogador = new Usuario();
                
                usuario.Nome = linha[1];
                usuario.Email = linha[2];
                usuario.Senha = linha[3];
                
                usuario.Add(jogador);
            }
            return usuario;
        }

        public void Update(Usuario u)
        {
            List<string> linhas = ReadAllLinesCSV(PATH);
            linhas.RemoveAll(x => x.Split(";")[0] == j.IdJogador.ToString());
            linhas.Add( PrepararLinha(u) );                        
            RewriteCSV(PATH, linhas); 
        }

    }
}