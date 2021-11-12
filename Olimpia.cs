namespace k_infoismfor_17maj_fl
{
    internal class Olimpia
    {
        /*−  Az elért helyezés. Például: „3” 
        −  A helyezést elérő sportoló vagy csapat esetén sportolók száma. Például: „4” 
        −  A sportág neve. Például: „atletika” 
        −  A versenyszám neve. Például: „4x100m_valtofutas” */

        public int helyezes;
        public string sportolo_vagy_csapat;
        public string sportag;
        public string versenyszam;

        public Olimpia(int helyezes, string sportolo_vagy_csapat, string sportag, string versenyszam)
        {
            this.helyezes = helyezes;
            this.sportolo_vagy_csapat = sportolo_vagy_csapat;
            this.sportag = sportag;
            this.versenyszam = versenyszam;
        }

        public override string ToString()
        {
            return helyezes+" "+sportolo_vagy_csapat+" "+sportag+" "+versenyszam;
        }
    }
}