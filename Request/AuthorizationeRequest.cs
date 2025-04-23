using Library.Request;
using System.Reflection.PortableExecutable;
using System.Text;
using static System.Net.Mime.MediaTypeNames;
using System.Threading;

namespace Library.Request
{
    public class AuthorizationeRequest
    {
        public string Login { get; set; } = null!;

        public string? Password { get; set; }
    }
}
const string baseUrl = "http://localhost:5292/api";
HttpClient apiClient = new HttpClient();
var user = new AuthorizationeRequest { Login = loginTextBox.Text, Password = passwordTextbox.Text };
var json = System.Text.Json.JsonSerializer.Serialize(user);
var content = new StringContent(json, Encoding.UTF8, "application/json");
var request = new HttpRequestMessage(HttpMethod.Get, $"{baseUrl}/User/authorize")
{
    Content = content
};
var window = new reader();
window.Show();
this.Close();
 < Label x: Name = "lb1" Grid.Column = "1" Content = "Библиотека" HorizontalAlignment = "Center" Margin = "0,94,0,0" VerticalAlignment = "Top" Foreground = "#FF5643B3" Height = "40" Width = "130" FontSize = "20" />
        < Label Grid.Column = "1" Content = "Логин" HorizontalAlignment = "Left" Margin = "26,161,0,0" VerticalAlignment = "Top" FontSize = "15" RenderTransformOrigin = "0,0.502" Height = "30" Width = "52" Foreground = "#FF5643B3" />
        < Label Grid.Column = "1" Content = "Пароль" HorizontalAlignment = "Left" Margin = "17,214,0,0" VerticalAlignment = "Top" FontSize = "15" Height = "30" Width = "61" Foreground = "#FF5643B3" />
        < TextBox x: Name = "loginTextBox" Grid.Column = "1" HorizontalAlignment = "Left" Margin = "140,161,0,0" TextWrapping = "Wrap" Text = "" VerticalAlignment = "Top" Width = "200" Height = "30" TextChanged = "TextBox_TextChanged" />
        < TextBox x: Name = "passwordTextbox" Grid.Column = "1" HorizontalAlignment = "Left" Margin = "140,217,0,0" TextWrapping = "Wrap" Text = "" VerticalAlignment = "Top" Width = "200" Height = "27" />
        < Button Content = "Войти" HorizontalAlignment = "Center" Margin = "0,279,0,0" VerticalAlignment = "Top" Grid.Column = "1" Width = "90" Background = "White" Foreground = "#FF5643B3" BorderThickness = "0,0,0,0" Click = "Button_Click" />
