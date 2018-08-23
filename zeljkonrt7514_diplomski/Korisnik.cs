using System;

namespace zeljkonrt7514_diplomski
{
    public class Korisnik
    {
        public int id { get; set; }
        public int visina { get; set; }
        public int tezina { get; set; }
        public int godine { get; set; }
        public int smanjiKilazu { get; set; }
        public int pdu { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string imePrezime { get; set; }
        public string pol { get; set; }
        public string aktivnost { get; set; }
        public string slika { get; set; }      
        public Korisnik(int id, string username, string password, string imePrezime, string pol, int godine, int visina, int tezina, string aktivnost, int smanjiKilazu, int pdu, string slika)
        {
            this.id = id;
            this.username = username;
            this.password = password;
            this.imePrezime = imePrezime;
            this.pol = pol;
            this.godine = godine;
            this.visina = visina;
            this.tezina = tezina;
            this.aktivnost = aktivnost;
            this.smanjiKilazu = smanjiKilazu;
            this.pdu = pdu;
            this.slika = slika;           
        }
        public override string ToString()
        {
            return this.id + "|"+this.username +"|" + this.password + "|" + this.imePrezime + "|" + this.pol + "|" + this.godine + "|" + this.visina + "|" + this.tezina + "|" + this.pdu;
        }
    }
}
