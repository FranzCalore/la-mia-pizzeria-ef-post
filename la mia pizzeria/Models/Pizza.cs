using System.ComponentModel.DataAnnotations;

namespace la_mia_pizzeria.Models
{
    public class Pizza
    {
        public int Id { get; set; }

        [Required]       
        public string nome { get; set; }
        [Required]
        public string descrizione { get; set; }

        [Required]
        [Range(1,100)]
        public double prezzo { get; set; }

        [Required]
        [Url]
        public string immagine { get; set; }

        public Pizza()
        {

        }

        public Pizza (string nome, string descrizione, double prezzo, string immagine)
        {
            this.nome = nome;
            this.descrizione = descrizione;
            this.prezzo = prezzo;
            this.immagine = immagine;
        }
    }
}
