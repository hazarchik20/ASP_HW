namespace _2_ASP_HW.DB
{
    public class DopServices
    {
        private string[] WrongWord = new string[] { "Cat", "Dog", "Hitler" };
        public string CheckText(string text)
        {
            foreach (var word in WrongWord)
            {
                if (text.Contains(word))
                {
                    text = text.Replace(word, "*****");
                }
            }
            return text;
        }
    }
}
