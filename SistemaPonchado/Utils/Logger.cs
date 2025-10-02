using System.Text;

namespace SistemaPonchado.Utils
{
    public static class Logger
    {
        private static readonly object _lock = new object();

        public static string LogDirectory
            => Path.Combine(AppContext.BaseDirectory, "logs");

        public static string LogFile
            => Path.Combine(LogDirectory, $"app_{DateTime.Now:yyyyMMdd}.log");

        public static void LogError(Exception ex, string? context = null)
        {
            try
            {
                Directory.CreateDirectory(LogDirectory);
                var sb = new StringBuilder();
                sb.AppendLine("==== ERROR ====");
                sb.AppendLine($"Fecha: {DateTime.Now:yyyy-MM-dd HH:mm:ss}");
                if (!string.IsNullOrWhiteSpace(context))
                {
                    sb.AppendLine($"Contexto: {context}");
                }
                sb.AppendLine(ex.ToString());
                sb.AppendLine();

                lock (_lock)
                {
                    File.AppendAllText(LogFile, sb.ToString());
                }
            }
            catch
            {
                // Evitar que el logging cause nuevas excepciones visibles
            }
        }
    }
}

