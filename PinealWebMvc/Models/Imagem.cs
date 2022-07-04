namespace PinealWebMvc.Models
{
    public class Imagem
    {
        public int Id { get; set; }
        public string Img { get; set; }

        public Imagem()
        {
        }

        public Imagem(int id, string img)
        {
            Id = id;
            Img = img;
        }
    }
}
