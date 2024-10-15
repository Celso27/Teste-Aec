using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using ProjetoBusca.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProjetoBusca.Services
{
    public class CursoAutomationService
    {
        public async Task<List<Curso>> BuscarCursosAsync(string termoBusca)
        {
            // Inicializar o WebDriver do Chrome
            var options = new ChromeOptions();
            options.AddArgument("--headless"); // Executa o Chrome sem interface
            using IWebDriver driver = new ChromeDriver(options);

            // Acessar a página de busca da Alura
            driver.Navigate().GoToUrl($"https://www.alura.com.br/busca?query={termoBusca}");

            Console.WriteLine($"Realizando busca por: {termoBusca}");

            // Esperar que os resultados sejam carregados
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(driver => driver.FindElement(By.CssSelector(".busca-resultado-nome")));

            // Coletar os cursos listados
            var cursos = new List<Curso>();
            var elementosCursos = driver.FindElements(By.CssSelector(".busca-resultado"));

            Console.WriteLine($"{elementosCursos.Count} cursos encontrados.");

            foreach (var elemento in elementosCursos)
            {
                var titulo = elemento.FindElement(By.CssSelector(".busca-resultado-nome")).Text;
                var descricao = elemento.FindElement(By.CssSelector(".busca-resultado-descricao")).Text;
                var link = elemento.FindElement(By.CssSelector(".busca-resultado-link")).GetAttribute("href");

                var curso = new Curso
                {
                    Titulo = titulo,
                    Descricao = descricao,
                    Professor = "Não disponível", // Alura não mostra o professor diretamente na busca
                    CargaHoraria = "Não disponível", // A carga horária também não está disponível
                   
                };

                cursos.Add(curso);
                Console.WriteLine($"Curso capturado: {titulo}, Link: {link}");
            }

            return cursos;
        }
    }
}
