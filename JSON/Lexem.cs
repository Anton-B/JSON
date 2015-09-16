namespace JSON
{
    sealed class Lexem
    {
        public JToken Token { get; set; }
        public string Text { get; set; }

        public Lexem(JToken token, string text)
        {
            Token = token;
            Text = text;
        }
    }
}
