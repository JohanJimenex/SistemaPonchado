namespace SistemaPonchado.Forms
{
    public partial class CredencialesUsuarioForm : Form
    {
        private readonly string _usuario;
        private readonly string _password;

        public CredencialesUsuarioForm(string usuario, string password)
        {
            InitializeComponent();
            _usuario = usuario;
            _password = password;
            txtContenido.Text = $"Credenciales de acceso:\r\nUsuario: {_usuario}\r\nContraseña: {_password}\r\n\r\nEl usuario deberá cambiar su contraseña al iniciar sesión.";
        }

        private void btnCopiar_Click(object sender, EventArgs e)
        {
            try
            {
                Clipboard.SetText($"Usuario: {_usuario}\r\nContraseña: {_password}");
                btnCopiar.Text = "Copiado";
            }
            catch
            {
                MessageBox.Show("No se pudo copiar al portapapeles.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}

