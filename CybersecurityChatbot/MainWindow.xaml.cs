using System.Windows;
using System.Windows.Input;

namespace CybersecurityChatbot
{
    public partial class MainWindow : Window
    {
        private ChatBot _chatBot;

        public MainWindow()
        {
            InitializeComponent();

            _chatBot = new ChatBot();
            _chatBot.PlayVoiceGreeting();
            AppendBotMessage(_chatBot.GetGreeting());
            UserInputBox.Focus();
        }

        private void SendButton_Click(object sender, RoutedEventArgs e)
        {
            SendMessage();
        }

        private void UserInputBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                SendMessage();
            }
        }

        private void SendMessage()
        {
            string userInput = UserInputBox.Text.Trim();

            if (string.IsNullOrWhiteSpace(userInput))
                return;

            ChatDisplay.Text += $"You: {userInput}\n\n";
            string response = _chatBot.ProcessInput(userInput);
            ChatDisplay.Text += $"Bot: {response}\n\n";

            UserInputBox.Clear();
            ChatScrollViewer.ScrollToBottom();
            UserInputBox.Focus();
        }

        private void AppendBotMessage(string message)
        {
            ChatDisplay.Text += $"Bot: {message}\n\n";
            ChatScrollViewer.ScrollToBottom();
        }
    }
}