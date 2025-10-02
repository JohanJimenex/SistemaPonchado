// 🎯 PUNTO DE ENTRADA DE LA APLICACIÓN
// Este archivo es donde inicia toda la aplicación Windows Forms

using SistemaPonchado.Forms;

namespace SistemaPonchado;

static class Program
{
    /// <summary>
    /// 🚀 Método principal que se ejecuta cuando abres la aplicación
    /// Es el primer código que se ejecuta en todo el programa
    /// </summary>
    [STAThread] // 📝 Atributo necesario para Windows Forms (Single Thread Apartment)
    static void Main()
    {
        // 🔧 Configuración inicial de la aplicación Windows Forms
        // Esto prepara el entorno gráfico y las configuraciones por defecto
        ApplicationConfiguration.Initialize();
        
        // 🏠 Abrir la primera ventana: LoginForm
        // Application.Run() mantiene la aplicación ejecutándose hasta que se cierre
        Application.Run(new LoginForm());
        
        // 💡 CONCEPTO CLAVE: 
        // Todo inicia aquí → LoginForm → luego AdminMainForm o EmpleadoMainForm
        // según el tipo de usuario que inicie sesión
    }    
}